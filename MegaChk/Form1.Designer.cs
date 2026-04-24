using System.Windows.Forms;

namespace MegaChk
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.labelLista = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxLista = new System.Windows.Forms.TextBox();
            this.buttonImprimirLista = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelTotal = new System.Windows.Forms.Label();
            this.labelValidos = new System.Windows.Forms.Label();
            this.labelErrores = new System.Windows.Forms.Label();
            this.buttonExportarTxt = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelLista
            // 
            this.labelLista.AutoSize = true;
            this.labelLista.ForeColor = System.Drawing.Color.Red;
            this.labelLista.Location = new System.Drawing.Point(20, 30);
            this.labelLista.Name = "labelLista";
            this.labelLista.Size = new System.Drawing.Size(37, 13);
            this.labelLista.TabIndex = 0;
            this.labelLista.Text = "LISTA";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(23, 220);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "INICIAR VERIFICACIÓN";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.buttonStart);
            // 
            // textBoxLista
            // 
            this.textBoxLista.BackColor = System.Drawing.Color.Black;
            this.textBoxLista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxLista.ForeColor = System.Drawing.Color.Red;
            this.textBoxLista.Location = new System.Drawing.Point(23, 56);
            this.textBoxLista.Multiline = true;
            this.textBoxLista.Name = "textBoxLista";
            this.textBoxLista.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxLista.Size = new System.Drawing.Size(319, 120);
            this.textBoxLista.TabIndex = 2;
            this.textBoxLista.Text = "acc1:pw1\r\nacc2:pw2";
            this.textBoxLista.TextChanged += new System.EventHandler(this.textBoxLista_TextChanged);
            // 
            // buttonImprimirLista
            // 
            this.buttonImprimirLista.BackColor = System.Drawing.SystemColors.ControlText;
            this.buttonImprimirLista.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.buttonImprimirLista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonImprimirLista.ForeColor = System.Drawing.Color.Red;
            this.buttonImprimirLista.Location = new System.Drawing.Point(369, 220);
            this.buttonImprimirLista.Name = "buttonImprimirLista";
            this.buttonImprimirLista.Size = new System.Drawing.Size(152, 23);
            this.buttonImprimirLista.TabIndex = 1;
            this.buttonImprimirLista.Text = "IMPRIMIR LISTA";
            this.buttonImprimirLista.UseVisualStyleBackColor = false;
            this.buttonImprimirLista.Click += new System.EventHandler(this.buttonImprimirLista_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Black;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 25;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column5});
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.GridColor = System.Drawing.Color.Red;
            this.dataGridView1.Location = new System.Drawing.Point(0, 262);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Red;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Black;
            this.dataGridView1.RowTemplate.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(965, 310);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column4
            // 
            this.Column4.FillWeight = 50.76142F;
            this.Column4.HeaderText = "#";
            this.Column4.Name = "Column4";
            // 
            // Column1
            // 
            this.Column1.FillWeight = 112.3096F;
            this.Column1.HeaderText = "ACCOUNT";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.FillWeight = 112.3096F;
            this.Column2.HeaderText = "PASSWORD";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.FillWeight = 112.3096F;
            this.Column3.HeaderText = "USED";
            this.Column3.Name = "Column3";
            // 
            // Column5
            // 
            this.Column5.FillWeight = 112.3096F;
            this.Column5.HeaderText = "QUOTA";
            this.Column5.Name = "Column5";
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.ForeColor = System.Drawing.Color.Red;
            this.labelTotal.Location = new System.Drawing.Point(782, 176);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(54, 13);
            this.labelTotal.TabIndex = 0;
            this.labelTotal.Text = "TOTAL: 0";
            // 
            // labelValidos
            // 
            this.labelValidos.AutoSize = true;
            this.labelValidos.ForeColor = System.Drawing.Color.Red;
            this.labelValidos.Location = new System.Drawing.Point(771, 199);
            this.labelValidos.Name = "labelValidos";
            this.labelValidos.Size = new System.Drawing.Size(65, 13);
            this.labelValidos.TabIndex = 0;
            this.labelValidos.Text = "VALIDOS: 0";
            // 
            // labelErrores
            // 
            this.labelErrores.AutoSize = true;
            this.labelErrores.ForeColor = System.Drawing.Color.Red;
            this.labelErrores.Location = new System.Drawing.Point(764, 225);
            this.labelErrores.Name = "labelErrores";
            this.labelErrores.Size = new System.Drawing.Size(72, 13);
            this.labelErrores.TabIndex = 0;
            this.labelErrores.Text = "ERRORES: 0";
            // 
            // buttonExportarTxt
            // 
            this.buttonExportarTxt.BackColor = System.Drawing.SystemColors.ControlText;
            this.buttonExportarTxt.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.buttonExportarTxt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExportarTxt.ForeColor = System.Drawing.Color.Red;
            this.buttonExportarTxt.Location = new System.Drawing.Point(199, 220);
            this.buttonExportarTxt.Name = "buttonExportarTxt";
            this.buttonExportarTxt.Size = new System.Drawing.Size(152, 23);
            this.buttonExportarTxt.TabIndex = 1;
            this.buttonExportarTxt.Text = "EXPORTAR .TXT";
            this.buttonExportarTxt.UseVisualStyleBackColor = false;
            this.buttonExportarTxt.Click += new System.EventHandler(this.buttonExportTxt_click);
            // 
            // Form1
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.IpAddress;
            this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.ClientSize = new System.Drawing.Size(965, 572);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBoxLista);
            this.Controls.Add(this.buttonExportarTxt);
            this.Controls.Add(this.buttonImprimirLista);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelErrores);
            this.Controls.Add(this.labelValidos);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.labelLista);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "MEGACHK - Made by @Kenuzx";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLista;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxLista;
        private System.Windows.Forms.Button buttonImprimirLista;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private Label labelTotal;
        private Label labelValidos;
        private Label labelErrores;
        private Button buttonExportarTxt;
    }
}

