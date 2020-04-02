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
    public partial class frmAsistencia : Form
    {
        public frmAsistencia()
        {
            InitializeComponent();
        }

        private void lbTitulo_Click(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }

        private void txtDNI_TextChanged(object sender, EventArgs e)
        {
            Listar();
        }

        List<Asistencia> listaclientes = new List<Asistencia>();
        Config config = new Config();
        void Listar()
        {
            dgvClientes.Rows.Clear();
            listaclientes.Clear();

            DAsistencia dcliente = new DAsistencia();

            
                foreach (Asistencia item in dcliente.ListarAsistencias(txtDNI.Text))
                {
                    listaclientes.Add(item);
                    dgvClientes.Rows.Add(item.Apellido, item.Nombre, item.DNI, item.Estado);
                
            }
            config.enumerarDataGrid(dgvClientes);

        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
