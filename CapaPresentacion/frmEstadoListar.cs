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
    public partial class frmEstadoListar : Form
    {
        public frmEstadoListar()
        {
            InitializeComponent();
        }


        public Cliente cliente  { get; set; }
        
        List<Estado> estados = new List<Estado>();


        private void FrmEstadoListar_Load(object sender, EventArgs e)
        {
            lbTitulo.Text = "Progreso de " + cliente.nombre;

            DEstado dEstado = new DEstado();

            foreach (Estado item in dEstado.listarEstados(cliente.id))
            {
                dgvEstados.Rows.Add(item.fecha.ToShortDateString(),
                                    item.talla,item.peso,item.biceps,
                                    item.triceps,item.pecho,item.cintura,
                                    item.pantorrilla,item.observaciones);
            }
        }
    }
}
