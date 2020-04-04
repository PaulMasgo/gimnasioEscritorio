using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
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
            
             
            pdImpresionBoleta = new PrintDocument();
            pdImpresionBoleta.PrintPage += Print;

            printPreviewDialog.Document = pdImpresionBoleta;


            DMatricula dMatricula = new DMatricula();
            DPago dpago = new DPago();
            Matricula matricula = new Matricula(0, cliente, mdlVariableAplicacion.EmpleadoActivo, total, DateTime.Now, dtpInicio.Value, dtpFinal.Value, Convert.ToInt32(nudPagos.Value), planElejido, promocionElejida);

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
                            Pago pago = new Pago(0, Convert.ToDecimal(nudInicial.Value) , DateTime.Now, matricula);
                            dpago.NuevaPago(pago);
                            MessageBox.Show("Matricula Registrada con Exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            printPreviewDialog.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Algo salio mal !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }


        }

        private void Print(object sender,PrintPageEventArgs e)
        {
;
            //Logo
            Bitmap bmp = Properties.Resources.Captura;
            Image imagenlogo = bmp;
            e.Graphics.DrawImage(imagenlogo, 30, 30, imagenlogo.Width, imagenlogo.Height);

            //Datos del cliente
            e.Graphics.DrawString($"Cliente: {this.cliente.nombre} {this.cliente.apellido} ", new Font("Arial Narrow", 12, FontStyle.Regular), Brushes.Black, new Point(45 ,180));
            e.Graphics.DrawString($"Fecha: {DateTime.Now.Date.ToString("dd/MM/yyyy")} ", new Font("Arial Narrow", 12, FontStyle.Regular), Brushes.Black, new Point(45, 210));
            e.Graphics.DrawString($"DNI: {this.cliente.dni} ", new Font("Arial Narrow", 12, FontStyle.Regular), Brushes.Black, new Point(450, 180));

            //Descripcion

            //--CABECERA
            string line = "-------------------------------------------------------------------------------------------------------------------------------------";
            string items = "   CANTIDAD                        DESCRIPCION                                                                        SUBTOTAL  ";
            e.Graphics.DrawString(line, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(45, 250));
            e.Graphics.DrawString(items, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(45, 270));
            e.Graphics.DrawString(line, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(45, 285));

            //--CONTENIDO
            e.Graphics.DrawString("01", new Font("Arial Narrow", 12, FontStyle.Regular), Brushes.Black, new Point(73, 305));
            e.Graphics.DrawString($"Matricula por {this.planElejido.cantidadMeses} meses", new Font("Arial Narrow", 12, FontStyle.Regular), Brushes.Black, new Point(200, 305));
            e.Graphics.DrawString($"S/.{this.planElejido.precio}", new Font("Arial Narrow", 12, FontStyle.Regular), Brushes.Black, new Point(605, 305));


            //Pie
            e.Graphics.DrawString(line, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(45, 500));
            e.Graphics.DrawString($"Descuento S/. - {this.descuento}", new Font("Arial Narrow", 12, FontStyle.Regular), Brushes.Black, new Point(615, 520));
            e.Graphics.DrawString($"    Total S/. {this.total}", new Font("Arial Narrow", 12, FontStyle.Regular), Brushes.Black, new Point(615, 545));


        }
    }
}
