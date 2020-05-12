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
    public partial class frmEmpleadosActualizar : Form
    {
        public frmEmpleadosActualizar()
        {
            InitializeComponent();
        }

        public Empleado empleadoSeleccionado { get; set; }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            NEmpleado datos = new NEmpleado();
            Empleado empleado = new Empleado(empleadoSeleccionado.id,txtNombres.Text, txtApellidos.Text, txtDNI.Text,txtDireccion.Text, txtCelular.Text, null, txtCorreo.Text,Convert.ToString(cmbTipo.SelectedItem),Convert.ToString(cmbEstado.SelectedItem));

            DialogResult pregunta = MessageBox.Show("¿Desea actulizar los datos del empleado?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(pregunta == DialogResult.Yes)
            {
                datos.ActualizarEmpleado(empleado);
                MessageBox.Show("Empleado Actualizado con exito","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Close();
            }

             
        }

        private void FrmEmpleadosActualizar_Load(object sender, EventArgs e)
        {
            txtNombres.Text = empleadoSeleccionado.nombres;
            txtApellidos.Text = empleadoSeleccionado.apellidos;
            txtDireccion.Text = empleadoSeleccionado.direccion;
            txtCelular.Text = empleadoSeleccionado.celular;
            txtDNI.Text = empleadoSeleccionado.dni;
            txtCorreo.Text = empleadoSeleccionado.correo;
            cmbTipo.SelectedItem = empleadoSeleccionado.tipo;
            cmbEstado.SelectedItem = empleadoSeleccionado.estado;
        }
    }
}
