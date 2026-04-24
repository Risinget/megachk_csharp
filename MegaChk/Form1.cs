using CG.Web.MegaApiClient;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaChk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void buttonImprimirLista_Click(object sender, EventArgs e)
        {
            Console.WriteLine(this.textBoxLista.Text);

            String contentLista = this.textBoxLista.Text;
            string[] lineas = contentLista.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

            int initCount = 0;
            foreach (var line in lineas ) {

                String[] acc = line.Split(new[] { ":" }, StringSplitOptions.None);

                try
                {
                    String textConsole = "SOY LA LINEA -> :" + line + " ACCOUNT_1: " + acc[0] + " ACCOUNT_2: " + acc[1];
                    this.dataGridView1.Rows.Add(initCount++, acc[0], acc[1], "AQUI USED", "AQUI QUOTA");    
                    Console.WriteLine(textConsole);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }



        }

        private void buttonExportTxt_click(object sender, EventArgs e)
        {
            // export to txt all the content of datagridview

            try
            {
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cuadro de diálogo para guardar archivo
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Archivo de texto (*.txt)|*.txt";
                    sfd.Title = "Guardar como";
                    sfd.FileName = "DatosExportados.txt";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        StringBuilder sb = new StringBuilder();

                        // Exportar encabezados
                        for (int i = 0; i < dataGridView1.Columns.Count; i++)
                        {
                            sb.Append(dataGridView1.Columns[i].HeaderText);
                            if (i < dataGridView1.Columns.Count - 1)
                                sb.Append("\t"); // Separador por tabulación
                        }
                        sb.AppendLine();

                        // Exportar filas
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (!row.IsNewRow) // Evitar fila vacía al final
                            {
                                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                                {
                                    var cellValue = row.Cells[i].Value != null ? row.Cells[i].Value.ToString() : "";
                                    sb.Append(cellValue);
                                    if (i < dataGridView1.Columns.Count - 1)
                                        sb.Append("\t");
                                }
                                sb.AppendLine();
                            }
                        }

                        // Guardar archivo
                        File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);

                        MessageBox.Show("Datos exportados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void textBoxLista_TextChanged(object sender, EventArgs e)
        {

        }



        private async void buttonStart_Click(object sender, EventArgs e)
        {
            const bool DEBUG_MODE = true;
            const int MAX_CONCURRENT_TASKS = 1; // primero prueba con 1

            void Log(string msg)
            {
                if (DEBUG_MODE)
                    Console.WriteLine($"[{DateTime.Now:HH:mm:ss.fff}] {msg}");
            }

            var semaphore = new SemaphoreSlim(MAX_CONCURRENT_TASKS);

            Log("==== INICIO buttonStart_Click ====");

            button1.Enabled = false;
            dataGridView1.Rows.Clear();

            int total = 0;
            int validos = 0;
            int errores = 0;
            int rowIndex = 0;

            try
            {
                string[] lineas = (textBoxLista.Text ?? "")
                    .Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .ToArray();

                total = lineas.Length;

                labelTotal.Text = $"TOTAL: {total}";
                labelValidos.Text = $"VALIDOS: {validos}";
                labelErrores.Text = $"ERRORES: {errores}";

                Log($"Total de líneas: {total}");

                var semaphore_ = new SemaphoreSlim(MAX_CONCURRENT_TASKS);
                var tasks = new List<Task>();

                foreach (string line in lineas)
                {
                    tasks.Add(ProcessLineAsync(line));
                }

                await Task.WhenAll(tasks);
                Log("Todas las tareas terminaron");
            }
            catch (Exception ex)
            {
                Log($"EXCEPCIÓN GENERAL: {ex}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                button1.Enabled = true;
                Log("buttonStart.Enabled = true");
                Log("==== FIN buttonStart_Click ====");
            }

            async Task ProcessLineAsync(string line)
            {
                await semaphore.WaitAsync();

                try
                {
                    Log("--------------------------------------------------");
                    Log($"Procesando línea: [{line}]");

                    string[] acc = line.Split(new[] { ':' }, 2);

                    if (acc.Length < 2)
                    {
                        Log("Formato inválido");
                        Interlocked.Increment(ref errores);
                        UpdateCounters(total, validos, errores);
                        return;
                    }

                    string email = acc[0].Trim();
                    string password = acc[1].Trim();

                    if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                    {
                        Log($"Email o password vacío: [{line}]");
                        Interlocked.Increment(ref errores);
                        UpdateCounters(total, validos, errores);
                        return;
                    }

                    MegaResult result = await ProcessMegaAccountWithTimeoutAsync(email, password, Log, 5000);

                    if (result == null)
                    {
                        Log($"Resultado nulo para {email}");
                        Interlocked.Increment(ref errores);
                        UpdateCounters(total, validos, errores);
                        return;
                    }

                    int currentRow = Interlocked.Increment(ref rowIndex) - 1;

                    BeginInvoke((Action)(() =>
                    {
                        try
                        {
                            Log($"Añadiendo fila a tabla para {email}");

                            dataGridView1.Rows.Add(
                                currentRow,
                                result.Email,
                                result.Password,
                                result.UsedQuotaMB,
                                result.TotalQuotaMB
                            );

                            Log($"Fila añadida OK para {email}");
                        }
                        catch (Exception ex)
                        {
                            Log($"ERROR al añadir fila para {email}: {ex}");
                        }
                    }));

                    Interlocked.Increment(ref validos);
                    UpdateCounters(total, validos, errores);

                    Log($"Cuenta OK: {email}");
                }
                catch (Exception ex)
                {
                    Log($"EXCEPCIÓN en ProcessLineAsync: {ex}");
                    Interlocked.Increment(ref errores);
                    UpdateCounters(total, validos, errores);
                }
                finally
                {
                    semaphore.Release();
                }
            }
        }

        private void UpdateCounters(int total, int validos, int errores)
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action)(() => UpdateCounters(total, validos, errores)));
                return;
            }

            labelTotal.Text = $"TOTAL: {total}";
            labelValidos.Text = $"VALIDOS: {validos}";
            labelErrores.Text = $"ERRORES: {errores}";
        }

        private async Task<MegaResult> ProcessMegaAccountWithTimeoutAsync(
            string email,
            string password,
            Action<string> log,
            int timeoutMs)
        {
            var workTask = Task.Run(() =>
            {
                MegaApiClient client = null;
                bool loggedIn = false;

                try
                {
                    log($"[Mega] Inicio para {email}");

                    client = new MegaApiClient();

                    log($"[Mega] Antes de Login({email})");
                    client.Login(email, password);
                    log($"[Mega] Después de Login({email})");

                    if (!client.IsLoggedIn)
                    {
                        log($"[Mega] IsLoggedIn = false para {email}");
                        return null;
                    }

                    loggedIn = true;
                    log($"[Mega] Login correcto para {email}");

                    log($"[Mega] Antes de GetAccountInformation({email})");
                    var info = client.GetAccountInformation();
                    log($"[Mega] Después de GetAccountInformation({email})");

                    long usedQuotaMB = info.UsedQuota / (1024 * 1024);
                    long totalQuotaMB = info.TotalQuota / (1024 * 1024);

                    log($"[Mega] used={usedQuotaMB}MB total={totalQuotaMB}MB para {email}");

                    return new MegaResult
                    {
                        Email = email,
                        Password = password,
                        UsedQuotaMB = usedQuotaMB,
                        TotalQuotaMB = totalQuotaMB
                    };
                }
                catch (Exception ex)
                {
                    log($"[Mega] EXCEPCIÓN para {email}: {ex}");
                    return null;
                }
                finally
                {
                    if (client != null && loggedIn)
                    {
                        try
                        {
                            log($"[Mega] Antes de Logout({email})");
                            client.Logout();
                            log($"[Mega] Logout OK para {email}");
                        }
                        catch (Exception ex)
                        {
                            log($"[Mega] Error en Logout para {email}: {ex}");
                        }
                    }
                }
            });

            var completed = await Task.WhenAny(workTask, Task.Delay(timeoutMs));

            if (completed != workTask)
            {
                log($"[Mega] TIMEOUT para {email} después de {timeoutMs} ms");
                return null;
            }

            return await workTask;
        }

    }
}

public class MegaResult
{
    public string Email { get; set; }
    public string Password { get; set; }
    public long UsedQuotaMB { get; set; }
    public long TotalQuotaMB { get; set; }
}