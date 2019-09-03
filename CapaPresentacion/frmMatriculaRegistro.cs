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
    public partial class frmMatriculaRegistro : Form
    {
        public frmMatriculaRegistro()
        {
            InitializeComponent();
        }


        public Cliente cliente { get; set; }

        List<Planes> listaPlanes = new List<Planes>();
        public Planes planElejido { get; set; }

        List<Promociones> listaPromociones = new List<Promociones>();
        public Promociones promocionElejida { get; set; }

        decimal subtotal = 0;
        decimal descuento = 0;
        decimal total = 0;

        public void resultado()
        {
            descuento = subtotal * ( descuento/100);
            total = subtotal - descuento;
            lbSubtotal.Text = "Subtotal :  S/." + subtotal;
            lbDescuento.Text = "Descuento :  S/." + descuento;
            lbTotal.Text = "Total :  S/." + total;
        }


        private void FrmMatriculaRegistro_Load(object sender, EventArgs e)
        {
            lbfecha.Text = "Fecha: " + DateTime.Now.ToLongDateString();

            DPlanes planes = new DPlanes();
            DPromociones dpromociones = new DPromociones();
            
            foreach (Planes item in planes.listarPlanes())  
            {
                cmbPlanes.Items.Add(item.cantidadMeses + " Meses");
                listaPlanes.Add(item);
            }

            foreach (Promociones item in dpromociones.listarPromociones())
            {
                cmbPromocion.Items.Add(item.nombre);
                listaPromociones.Add(item);

            }

            cmbPlanes.SelectedIndex = 0;
            subtotal = planElejido.precio;
            resultado();
            cmbPromocion.SelectedItem = "Ninguno";
            promocionElejida = listaPromociones[cmbPromocion.SelectedIndex];
         
        }

        private void TxtNombres_TextChanged(object sender, EventArgs e)
        {
         
            
        }

        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            frmClientes empleados = new frmClientes();
            empleados.seleccionar = true;
            empleados.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            if (empleados.ShowDialog() == DialogResult.Cancel && empleados.seleccionado != null )
            {
                this.cliente = empleados.seleccionado;
                txtNombres.Text = cliente.nombre;
                txtApellidos.Text = cliente.apellido;
                txtDNI.Text = cliente.dni;
            }

        }

        private void TxtDNI_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void TxtDNI_KeyDown(object sender, KeyEventArgs e)
        {

            DCliente dcliente = new DCliente();

            if (e.KeyCode == Keys.Enter)
            {
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
        }

        private void CmbPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.planElejido = listaPlanes[cmbPlanes.SelectedIndex];
            DateTime fechaFin = dtpInicio.Value.AddMonths(this.planElejido.cantidadMeses);
            dtpFinal.Value = fechaFin;
            txtcostoPlan.Text = planElejido.precio.ToString();
            subtotal = planElejido.precio;
            nudPagos.Maximum = planElejido.pagosMaximos;
            resultado();
        }

        private void CmbPromocion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPromocion.Text == "Ninguno")
            {
                descuento = 0;
                txtDescuentoPromocion.Text = "0%";
                resultado();
            }
            else
            {
                this.promocionElejida = listaPromociones[cmbPromocion.SelectedIndex];
                txtDescuentoPromocion.Text = promocionElejida.descuento.ToString() + "%";
                descuento = promocionElejida.descuento;
                resultado();
            }

            
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {



            DMatricula dMatricula = new DMatricula();
            DPago dpago = new DPago();
            Matricula matricula = new Matricula(0, cliente,mdlVariableAplicacion.EmpleadoActivo, total, DateTime.Now, dtpInicio.Value, dtpFinal.Value, Convert.ToInt32(nudPagos.Value), planElejido, promocionElejida);
 
            if (cliente == null)
            {
                MessageBox.Show("Debe seleccionar un cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (nudInicial.Value <= 0)
                {
                    MessageBox.Show("El pago no debe ser 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DialogResult pregunta = MessageBox.Show("Desea registrar la matricula?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (pregunta == DialogResult.Yes)
                    {
                        int codigomatricula = dMatricula.NuevaMatricula(matricula);
                        matricula.idMatricula = codigomatricula;
                        if (codigomatricula > 0)
                        {
                            Pago pago = new Pago(0, nudInicial.Value, DateTime.Now, matricula);
                            dpago.NuevaPago(pago);
                            MessageBox.Show("Matricula Registrada con Exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Algo salio mal !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }










        }
    }
}
