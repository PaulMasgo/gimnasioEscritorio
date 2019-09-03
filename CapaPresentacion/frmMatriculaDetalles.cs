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
    public partial class frmMatriculaDetalles : Form
    {
        public frmMatriculaDetalles()
        {
            InitializeComponent();
        }

        public Matricula matricula { get; set; }
        public decimal Aportado { get; set; }

        public decimal listarPagos()
        {
            decimal aportado = 0;
            DPago dpago = new DPago();

            foreach (Pago item in dpago.listarPagos(this.matricula.idMatricula))
            {
                aportado = aportado + item.monto;
                dgvPagos.Rows.Add(item.fecha.ToShortDateString(), "S/." + item.monto);
            }

            if (aportado == this.matricula.total)
            {
                txtEstado.Text = "Pago Completo";
            }
            else
            {
                txtEstado.Text = "No completado";
            }

            this.Aportado = aportado;
            return aportado;
        }

        private void FrmMatriculaDetalles_Load(object sender, EventArgs e)
        {
             txtAportado.Text = "S/." + listarPagos();

            decimal descuento = this.matricula.plan.precio - this.matricula.total;
            txtClientes.Text = this.matricula.cliente.nombre;
            txtEmpleado.Text = this.matricula.empleado.nombres;
            txtFecha.Text = this.matricula.fecha.ToShortDateString();
            txtFechaIni.Text = this.matricula.fechaInicio.ToShortDateString();
            txtFechaFin.Text = this.matricula.fechaFin.ToShortDateString();
            txtPlan.Text = this.matricula.plan.cantidadMeses + " meses";
            txtPromocion.Text = this.matricula.promocion.nombre;
            txtSubtotal.Text = "S/."+ this.matricula.plan.precio;
            txtTotal.Text = "S/." + this.matricula.total;
            txtDescuento.Text =  "S/." + descuento;

            if (txtEstado.Text == "Pago Completo")
            {
                btnRealizarPago.Visible = false;
            }
            else
            {
                btnRealizarPago.Visible = true;
            }
        }

        private void DgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnRealizarPago_Click(object sender, EventArgs e)
        {
            frmPagoRegistro pago = new frmPagoRegistro();
            pago.matricula = this.matricula;
            pago.total = this.matricula.total;
            pago.restante = this.matricula.total - this.Aportado;

            if (pago.ShowDialog()== DialogResult.Cancel)
            {
                this.Close();
            }
        }
    }
}
