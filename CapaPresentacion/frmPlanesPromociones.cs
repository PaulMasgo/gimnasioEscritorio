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
    public partial class frmPlanesPromociones : Form
    {
        public frmPlanesPromociones()
        {
            InitializeComponent();
        }


        public void listarPlanes()
        {
            dgvplanes.Rows.Clear();
            DPlanes dplanes = new DPlanes();
            foreach (Planes item in dplanes.listarPlanes())
            {
                dgvplanes.Rows.Add(item.cantidadMeses + " meses", "S/." + item.precio , item.pagosMaximos);
            }
        }


        public void listarPomociones()
        {
            dgvPromociones.Rows.Clear();
            DPromociones dprom = new DPromociones();
            foreach (Promociones item in dprom.listarPromociones())
            {
                dgvPromociones.Rows.Add(item.nombre, item.descuento + "%");
            }
        }

        private void FrmPlanesPromociones_Load(object sender, EventArgs e)
        {
            listarPlanes();
            listarPomociones();
        }

        private void BtnRegistrarPlan_Click(object sender, EventArgs e)
        {

            bool completos;

            if (nudmeses.Value <= 0 ||
                nudprecio.Value <= 0)
            {
                completos = false;
            }
            else
            {
                completos = true;
            }

            if (completos == true)
            {
                DialogResult pregunta = MessageBox.Show("Desea registrar el plan ingresado", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (pregunta == DialogResult.Yes)
                {
                    Planes plan = new Planes(0, Convert.ToInt32(nudmeses.Value), nudprecio.Value , Convert.ToInt32(nudpagos.Value));
                    DPlanes dplanes = new DPlanes();
                    bool respuesta;
                    respuesta = dplanes.NuevaPlan(plan);
                    if (respuesta)
                    {
                        MessageBox.Show("Plan registrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        listarPlanes();
                    }else
                    {
                        MessageBox.Show("Error ya existe un plan con la misma cantidad de meses", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }
            else
            {
                MessageBox.Show("No se aceptan valores en cero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
