using CapaClases;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmReporteAsistencia : Form
    {
        public FrmReporteAsistencia()
        {
            InitializeComponent();
        }

        private void dtpFinal_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscarAsistencia_Click(object sender, EventArgs e)
        {
            dgvClientes.Rows.Clear();

            DCliente dcliente = new DCliente();

            var  EmpleadosListados = new List<Cliente>();

            var asistencias = dcliente.listarReporteasistencia(dtpInicio.Value,dtpFinal.Value);

            foreach (var item in asistencias)
            {
                EmpleadosListados.Add(item);
                dgvClientes.Rows.Add(item.Fecha, item.nombre, item.apellido, item.dni);
            }

            //if (asistencia == 0)
            //{
            //    MessageBox.Show("El cliente no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else
            //{
            //   foreach (var item in asistencias)
            //{
            //    EmpleadosListados.Add(item);
            //    dgvClientes.Rows.Add(item.Fecha, item.nombre, item.apellido, item.dni);
            //}
            

        }

 
    }
}
