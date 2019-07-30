using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CapaClases;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmClientesActualizar : Form
    {
        public frmClientesActualizar()
        {
            InitializeComponent();
        }


        public Cliente cliente { get; set; }


        private void FrmClientesActualizar_Load(object sender, EventArgs e)
        {
            txtNombres.Text = cliente.nombre;
            txtApellidos.Text = cliente.apellido;
            txtCelular.Text = cliente.telefono;
            txtDNI.Text = cliente.dni;
            txtTelEmer.Text = cliente.telefonoEmergencia;
            dtpNacimiento.Value = cliente.nacimiento;
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            Cliente rcliente = new Cliente(cliente.id, txtNombres.Text, txtApellidos.Text, txtDNI.Text, txtCelular.Text, txtTelEmer.Text, dtpNacimiento.Value.Date);
            DialogResult pregunta = MessageBox.Show("Desea actualizar los datos del cliente?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(pregunta == DialogResult.Yes)
            {
                DCliente cliente = new DCliente();
                cliente.ActualizarCliente(rcliente);
                MessageBox.Show("Los datos del cliente han sido actualizados", "Realizado", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
