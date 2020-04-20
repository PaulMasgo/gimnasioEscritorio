namespace CapaPresentacion
{
    partial class frmMatriculaListar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMatriculaListar));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lbTermino = new System.Windows.Forms.Label();
            this.btnDetalles = new System.Windows.Forms.Button();
            this.dgvMatriculas = new System.Windows.Forms.DataGridView();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Correo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatriculas)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTitulo
            // 
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.Location = new System.Drawing.Point(352, 26);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(295, 28);
            this.lbTitulo.TabIndex = 21;
            this.lbTitulo.Text = "Ver estado de matricula";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.Black;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(951, 87);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(42, 26);
            this.btnBuscar.TabIndex = 20;
            this.btnBuscar.UseVisualStyleBackColor = false;
            // 
            // lbTermino
            // 
            this.lbTermino.AutoSize = true;
            this.lbTermino.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTermino.Location = new System.Drawing.Point(51, 92);
            this.lbTermino.Name = "lbTermino";
            this.lbTermino.Size = new System.Drawing.Size(174, 17);
            this.lbTermino.TabIndex = 19;
            this.lbTermino.Text = "Nombres o dni del cliente";
            // 
            // btnDetalles
            // 
            this.btnDetalles.BackColor = System.Drawing.Color.Green;
            this.btnDetalles.FlatAppearance.BorderSize = 0;
            this.btnDetalles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetalles.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalles.ForeColor = System.Drawing.Color.White;
            this.btnDetalles.Image = ((System.Drawing.Image)(resources.GetObject("btnDetalles.Image")));
            this.btnDetalles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDetalles.Location = new System.Drawing.Point(694, 524);
            this.btnDetalles.Name = "btnDetalles";
            this.btnDetalles.Size = new System.Drawing.Size(299, 33);
            this.btnDetalles.TabIndex = 17;
            this.btnDetalles.Text = "Ver todos los detalles";
            this.btnDetalles.UseVisualStyleBackColor = false;
            this.btnDetalles.Click += new System.EventHandler(this.BtnDetalles_Click);
            // 
            // dgvMatriculas
            // 
            this.dgvMatriculas.AllowUserToAddRows = false;
            this.dgvMatriculas.BackgroundColor = System.Drawing.Color.White;
            this.dgvMatriculas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMatriculas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvMatriculas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMatriculas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMatriculas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMatriculas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cliente,
            this.Fecha,
            this.DNI,
            this.Correo,
            this.Direccion,
            this.Column1,
            this.Estado,
            this.Column2});
            this.dgvMatriculas.EnableHeadersVisualStyles = false;
            this.dgvMatriculas.GridColor = System.Drawing.Color.Black;
            this.dgvMatriculas.Location = new System.Drawing.Point(23, 130);
            this.dgvMatriculas.Name = "dgvMatriculas";
            this.dgvMatriculas.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMatriculas.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dgvMatriculas.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvMatriculas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMatriculas.Size = new System.Drawing.Size(1015, 376);
            this.dgvMatriculas.TabIndex = 15;
            // 
            // Cliente
            // 
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.Width = 220;
            // 
            // Fecha
            // 
            this.Fecha.HeaderText = "Registro";
            this.Fecha.Name = "Fecha";
            // 
            // DNI
            // 
            this.DNI.HeaderText = "Fecha Inicio";
            this.DNI.Name = "DNI";
            this.DNI.Width = 120;
            // 
            // Correo
            // 
            this.Correo.HeaderText = "Fecha Fin";
            this.Correo.Name = "Correo";
            this.Correo.Width = 120;
            // 
            // Direccion
            // 
            this.Direccion.HeaderText = "Total";
            this.Direccion.Name = "Direccion";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Contrato";
            this.Column1.Name = "Column1";
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado Pago";
            this.Estado.Name = "Estado";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Estado";
            this.Column2.Name = "Column2";
            // 
            // frmMatriculaListar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 600);
            this.Controls.Add(this.lbTitulo);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lbTermino);
            this.Controls.Add(this.btnDetalles);
            this.Controls.Add(this.dgvMatriculas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMatriculaListar";
            this.Text = "frmMatriculaListar";
            this.Load += new System.EventHandler(this.FrmMatriculaListar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatriculas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lbTermino;
        private System.Windows.Forms.Button btnDetalles;
        private System.Windows.Forms.DataGridView dgvMatriculas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn Correo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}