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

        private void buttonStart(object sender, EventArgs e)
        {

            String contentLista = this.textBoxLista.Text;
            string[] lineas = contentLista.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

            int initCount = 0;
            this.labelTotal.Text = "TOTAL: " + lineas.Length;
            int errors = 0;
            int valids = 0;
            foreach (var line in lineas)
            {
                String[] acc = line.Split(new[] { ":" }, StringSplitOptions.None);
                try
                {
                    var client = new MegaApiClient();
                    client.Login(acc[0], acc[1]);
                    // to MB
                    var usedQuota = client.GetAccountInformation().UsedQuota;
                    var usedQuotaMB = usedQuota / (1024 * 1024);
                    var totalQuota= client.GetAccountInformation().TotalQuota;
                    var totalQuotaMB = totalQuota / (1024 * 1024);
                    client.Logout();
                    this.dataGridView1.Rows.Add(initCount++, acc[0], acc[1], usedQuotaMB, totalQuotaMB);
                    this.labelTotal.Text = "TOTAL: " + lineas.Length;
                    valids++;
                    this.labelValidos.Text = "VALIDOS: " + valids;
                    this.labelErrores.Text = "ERRORES: " + errors;
                }
                catch (Exception ex)
                {
                    errors++;
                    this.labelTotal.Text = "TOTAL: " + lineas.Length;
                    this.labelValidos.Text = "VALIDOS: " + valids;
                    this.labelErrores.Text = "ERRORES: " + errors;
                    Console.WriteLine(ex.Message);
                }
            }
            
        }
    }
}
