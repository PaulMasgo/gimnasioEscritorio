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
    public partial class frmPagoRegistro : Form
    {
        public frmPagoRegistro()
        {
            InitializeComponent();
        }

        public Matricula matricula { get; set; }
        public decimal total { get; set; }
        public decimal restante { get; set; }



        private void FrmPagoRegistro_Load(object sender, EventArgs e)
        {
            nudMonto.Value = restante;
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {


            Pago pago = new Pago(0, nudMonto.Value, DateTime.Now, matricula);
            DPago dpago = new DPago();

            if (nudMonto.Value > restante)
            {
                MessageBox.Show("El monto ingresado es mayor a la deuda", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult pregunta = MessageBox.Show("Desesa regitrar el pago?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (pregunta == DialogResult.Yes)
                {
                    dpago.NuevaPago(pago);
                    MessageBox.Show("Pago realizado on exito", "Realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }



        }
    }
}
