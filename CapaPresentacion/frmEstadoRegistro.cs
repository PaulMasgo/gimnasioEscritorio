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
    public partial class frmEstadoRegistro : Form
    {
        public frmEstadoRegistro()
        {
            InitializeComponent();
        }

        public Cliente cliente { get; set; }

        private void FrmEstadoRegistro_Load(object sender, EventArgs e)
        {

        }

        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            DCliente dcliente = new DCliente();

            cliente = dcliente.listarClienteDni(txtDNI.Text);
            if (cliente == null)
            {
                MessageBox.Show("El cliente no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                txtApellidos.Text = cliente.apellido;
                txtNombres.Text = cliente.nombre;
            }

        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            bool estado ;

            if (nudBiceps.Value <= 0 ||
                nudTriceps.Value <= 0 ||
                nudPeso.Value <= 0 ||
                nudTalla.Value <= 0 ||
                nudPecho.Value <= 0 ||
                nudCintura.Value <= 0 ||
                nudPantorrila.Value <= 0)
            {
                estado = false;
            }
            else
            {
                estado = true;
            }

            if (cliente == null)
            {
                MessageBox.Show("No hay ningun cliente seleccionado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (estado == false)
                {
                    MessageBox.Show("Todos los campos a exepción de las obervaciones son obligatorios", "Campo vacios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    DEstado destado = new DEstado();
                    Estado status = new Estado(0, nudTalla.Value, nudPeso.Value, txtObservaciones.Text, nudPecho.Value, nudBiceps.Value, nudCintura.Value, nudTriceps.Value, nudPantorrila.Value, cliente, DateTime.Now);
                    DialogResult pregunta = MessageBox.Show("Desea Registrar el avance del cliente", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (pregunta == DialogResult.Yes)
                    {
                        bool realizado;
                        realizado = destado.NuevoEstado(status);
                        if (realizado == false)
                        {
                            MessageBox.Show("Algo salio mal intentalo nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Avanze Registrado", "Realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }





        }

        private void BtnVerEstados_Click(object sender, EventArgs e)
        {
            frmEstadoListar estadolistar = new frmEstadoListar();
            if (this.cliente == null)
            {
                MessageBox.Show("No hay ningun participante seleccionado", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                estadolistar.cliente = this.cliente;
                estadolistar.ShowDialog();
            }
            
        }
    }
}
