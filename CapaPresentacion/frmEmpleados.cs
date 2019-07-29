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
    public partial class frmEmpleados : Form
    {
        public frmEmpleados()
        {
            InitializeComponent();
        }

        List<Empleado> EmpleadosListados = new List<Empleado>();
        Config config = new Config();

        void Listar()
        {
            NEmpleado empleado = new NEmpleado();
            dgvEmpleados.Rows.Clear();
            EmpleadosListados.Clear();


            if(txtBusqueda.Text.Length <= 0)
            {
                foreach (Empleado item in empleado.ListarEmpleados())
                {
                    EmpleadosListados.Add(item);
                    dgvEmpleados.Rows.Add(item.apellidos,item.nombres,item.dni,item.correo,item.direccion,item.celular,item.tipo); 
                }
            }
            else
            {
                foreach (Empleado item in empleado.ListarEmpleadosTermino(txtBusqueda.Text))
                {
                    EmpleadosListados.Add(item);
                    dgvEmpleados.Rows.Add(item.apellidos, item.nombres, item.dni, item.correo, item.direccion, item.celular);
                }
            }

            config.enumerarDataGrid(dgvEmpleados);

        }
                

        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            frmEmpleadosRegistro x = new frmEmpleadosRegistro();
            if(x.ShowDialog()== DialogResult.Cancel)
            {
                Listar();
            }
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            frmEmpleadosActualizar form = new frmEmpleadosActualizar();
            form.empleadoSeleccionado = EmpleadosListados[dgvEmpleados.SelectedRows[0].Index];
            if (form.ShowDialog() == DialogResult.Cancel)
            {
                Listar();
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            Listar();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Listar();
        }
    }
}
