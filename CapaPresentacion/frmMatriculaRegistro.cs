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
        private decimal precioTotal { get; set; }

        /// <summary>
        /// Calcula el descuento dependiendo del descuento en porcentaje
        /// </summary>
        /// <param name="subtotal"></param>
        /// <param name="descuentoPorcentaje"></param>
        /// <returns> Retorna el decuento en soles haciendo el calculo previo </returns>
        public decimal Descuento(decimal subtotal, decimal descuentoPorcentaje )
        {
            return decimal.Round(subtotal * (descuentoPorcentaje / 100), 2);
        }

        /// <summary>
        /// Calcula el total de la matricula 
        /// </summary>
        /// <param name="subtotal"></param>
        /// <param name="descuento"></param>
        /// <returns> Retorna la resta del subtotal y el descuento </returns>
        public decimal Total(decimal subtotal,decimal descuento)
        {
            return decimal.Round(subtotal - descuento, 2);
        }


        public void MostrarResultado()
        {
            decimal descuento = Descuento(this.planElejido.precio, this.promocionElejida.descuento);
            lbDescuento.Text = "Descuento :  S/." + descuento;

            decimal total = Total(this.planElejido.precio, descuento);
            lbTotal.Text = "Total     :  S/." + total;

            this.precioTotal = total;

            if (nudPagos.Value > 1)
            {
                nudInicial.Value = total / 2;
            }
            else
            {
                nudInicial.Value = total;
            }

        }


        public void SeleccionarPlan(int indice)
        {
            this.planElejido = listaPlanes[indice];
            txtcostoPlan.Text = planElejido.precio.ToString();
            lbSubtotal.Text = "Subtotal :  S/." + decimal.Round(this.planElejido.precio, 2);
        }

        public void SeleccionarPromocion(int indice)
        {
            this.promocionElejida = listaPromociones[indice];
            txtDescuentoPromocion.Text = $"{promocionElejida.descuento}%";
        }

        public bool verficarMatriculasPrevias()
        {
            DMatricula dmatricula = new DMatricula();
            List<Matricula> matriculas = dmatricula.listarMatriculasActivas(this.cliente.id);
            bool activo = matriculas.Count == 0 ? false : true ;
            return activo;
        }

        public void nuevaMatricula()
        {
            this.precioTotal = 0;
            cmbPlanes.SelectedItem = "1 Meses";
            cmbPromocion.SelectedItem = "Ninguno";
            this.cliente = null;
            txtNombres.Text = "";
            txtDNI.Text = "";
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
                if (item.cantidadMeses == 1)
                {
                    planElejido = item;
                }
            }

            foreach (Promociones item in dpromociones.listarPromociones())
            {
                cmbPromocion.Items.Add(item.nombre);
                listaPromociones.Add(item);
                if (item.descuento == 0)
                {
                    promocionElejida = item;
                }
            }


            cmbPlanes.SelectedItem = "1 Meses";
            cmbPromocion.SelectedItem = "Ninguno";

            
            MostrarResultado();
         
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
            SeleccionarPlan(cmbPlanes.SelectedIndex);
            MostrarResultado();
            DateTime fechaFin = dtpInicio.Value.AddMonths(this.planElejido.cantidadMeses);
            dtpFinal.Value = fechaFin;

        }

        private void CmbPromocion_SelectedIndexChanged(object sender, EventArgs e)
        {
            SeleccionarPromocion(cmbPromocion.SelectedIndex);
            MostrarResultado();
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            pdImpresionBoleta = new PrintDocument();
            pdImpresionBoleta.PrintPage += Print;

            printPreviewDialog.Document = pdImpresionBoleta;


            DMatricula dMatricula = new DMatricula();
            int pagos = nudInicial.Value < precioTotal ? 2 : 1;

            Matricula matricula = new Matricula(0, cliente, mdlVariableAplicacion.EmpleadoActivo, precioTotal, DateTime.Now, dtpInicio.Value, dtpFinal.Value, pagos , planElejido, promocionElejida);

            if (cliente == null)
            {
                MessageBox.Show("Debe seleccionar un cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (verficarMatriculasPrevias() == true)
                {
                    MessageBox.Show("El cliente aun cuenta con una matricula activa", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    decimal pagoMin = nudPagos.Value == 1 ? precioTotal : precioTotal / 2;

                    if (nudInicial.Value < pagoMin)
                    {
                        MessageBox.Show($"El pago no debe ser menor a $/.{pagoMin}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                Pago pago = new Pago(0, Convert.ToDecimal(nudInicial.Value), DateTime.Now, matricula);
                                DPago.NuevaPago(pago);
                                MessageBox.Show("Matricula Registrada con Exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                printPreviewDialog.ShowDialog();
                                nuevaMatricula();
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


            //--Mensaje
            if (nudInicial.Value < this.precioTotal)
            {
                e.Graphics.DrawString("PAGO POR COMPLETAR", new Font("Arial Narrow", 17, FontStyle.Bold), Brushes.Black, new Point(300, 400));
                e.Graphics.DrawString($"  Pagado S/.  {nudInicial.Value}", new Font("Arial Narrow", 12, FontStyle.Regular), Brushes.Black, new Point(615, 570));
            }
            else
            {
                e.Graphics.DrawString("PAGO COMPLETO", new Font("Arial Narrow", 17, FontStyle.Bold), Brushes.Black, new Point(615, 400));
            }

            //Pie
            e.Graphics.DrawString(line, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(45, 500));

            decimal descuento = Descuento(this.planElejido.precio, this.promocionElejida.descuento);

            e.Graphics.DrawString($"Descuento S/. -{descuento}", new Font("Arial Narrow", 12, FontStyle.Regular), Brushes.Black, new Point(615, 520));
            e.Graphics.DrawString($"    Total S/.  {this.precioTotal}", new Font("Arial Narrow", 12, FontStyle.Regular), Brushes.Black, new Point(615, 545));


        }

        private void nudPagos_ValueChanged(object sender, EventArgs e)
        {
            MostrarResultado();
        }
    }
}
