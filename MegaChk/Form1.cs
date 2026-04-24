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
using CG.Web.MegaApiClient;

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

        private void ButtonLogin_Click(object sender, EventArgs e)
        {

            var client = new MegaApiClient();
            client.Login("asd@gmail.com", "asd");

            foreach (var node in client.GetNodes())
            {
                Console.WriteLine($"{node.Type} - {node.Name}");
            }


            var info = client.GetAccountInformation().UsedQuota;
            Console.WriteLine(info);
            client.Logout();
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
                    this.textBoxSalida.Text = textConsole;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            this.textBoxSalida.Text = this.textBoxLista.Text;


        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("HOLA");
            // exportar a .txt todo lo que hay en el datagridview
                
        }

        private void buttonExportarTxt_Click(object sender, EventArgs e)
        {
            Console.WriteLine("asdsadsadsa");
            // exportar a .txt todo lo que hay en el datagridview

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
