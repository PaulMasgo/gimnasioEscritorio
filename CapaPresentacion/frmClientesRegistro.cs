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
            bool estado = true;

            int edad = DateTime.Now.Year - dtpNacimiento.Value.Year;

            if (txtNombres.Text == string.Empty ||
                txtApellidos.Text == string.Empty ||
                txtDNI.Text == string.Empty ||
                txtTelEmer.Text == string.Empty ||
                txtCelular.Text == string.Empty)
            {
                estado = false;
            }

            Cliente cliente = new Cliente(0, txtNombres.Text, txtApellidos.Text, txtDNI.Text, txtCelular.Text, txtTelEmer.Text, dtpNacimiento.Value);
            DCliente datoscliente = new DCliente();

            



            if (estado == false)
            {
                MessageBox.Show("Todos los campos son obligatorios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (edad <= 16)
                {
                    MessageBox.Show("Solo se permiten participnates de 16 a más", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult pregunta = MessageBox.Show("Desea registrar el nuevo cliente", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (pregunta == DialogResult.Yes)
                    {
                        bool error = datoscliente.NuevoCliente(cliente);
                        if (error == true)
                        {
                            MessageBox.Show("Cliente registrado", "Realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("El dni ingresado ya ha sido registrado anteriormente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
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
