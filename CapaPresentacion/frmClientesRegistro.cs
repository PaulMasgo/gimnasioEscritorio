using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CapaNegocio;
using CapaClases;


namespace CapaPresentacion
{
    public partial class frmClientesRegistro : Form
    {
        public frmClientesRegistro()
        {
            InitializeComponent();
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente(0, txtNombres.Text, txtApellidos.Text, txtDNI.Text, txtCelular.Text, txtTelEmer.Text, dtpNacimiento.Value);
            DCliente datoscliente = new DCliente();

            DialogResult pregunta = MessageBox.Show("Desea registrar el nuevo cliente", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(pregunta == DialogResult.Yes)
            {
                datoscliente.NuevoCliente(cliente);
                MessageBox.Show("Cliente registrado","Realizado",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Close();
            }           

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
