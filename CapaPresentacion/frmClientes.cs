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
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }


        List<Cliente> listaclientes = new List<Cliente>();
        Config config = new Config();

        void Listar()
        {
            dgvClientes.Rows.Clear();
            listaclientes.Clear();

            DCliente dcliente = new DCliente();

            if(txtBusqueda.Text.Length <= 0)
            {
                foreach(Cliente item in dcliente.listarClientes())
                {
                    listaclientes.Add(item);
                    dgvClientes.Rows.Add(item.apellido,item.nombre,item.dni,item.telefono,item.telefonoEmergencia,item.nacimiento.ToShortDateString(),DateTime.Now.Year - item.nacimiento.Year);
                }
            }
            else
            {
                foreach (Cliente item in dcliente.listarClientesPrametro(txtBusqueda.Text))
                {
                    listaclientes.Add(item);
                    dgvClientes.Rows.Add(item.apellido, item.nombre, item.dni, item.telefono, item.telefonoEmergencia, item.nacimiento.ToShortDateString(), DateTime.Now.Year - item.nacimiento.Year);
                }
            }
            config.enumerarDataGrid(dgvClientes);
            
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void DgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TxtBusqueda_TextChanged(object sender, EventArgs e)
        {
            Listar();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            frmClientesRegistro registrocliente = new frmClientesRegistro();
            if(registrocliente.ShowDialog() == DialogResult.Cancel)
            {
                Listar();
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            frmClientesActualizar actualizar = new frmClientesActualizar();
            actualizar.cliente = listaclientes[dgvClientes.SelectedRows[0].Index];

            if(actualizar.ShowDialog() == DialogResult.Cancel)
            {
                Listar();
            }

        }
    }
}
