using System;
using System.Drawing;
using System.Drawing.Printing;
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
        public decimal restante { get; set; }


        private void FrmPagoRegistro_Load(object sender, EventArgs e)
        {
            nudMonto.Value = restante;
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {

            printDocument1 = new PrintDocument();
            printDocument1.PrintPage += Print;

            printPreviewDialog1.Document = printDocument1;


            DialogResult pregunta = MessageBox.Show("Desesa registrar la finalización del pago de la matricula?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (pregunta == DialogResult.Yes)
            {
                DPago.NuevaPago(new Pago(0, restante, DateTime.Now, matricula));
                MessageBox.Show("Pago realizado on exito", "Realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                printPreviewDialog1.ShowDialog();
                Close();
            }
            else
            {
                MessageBox.Show("Pago Cancelado", "No completado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

        }

        private void Print(object sender, PrintPageEventArgs e)
        {
            ;
            //Logo
            Bitmap bmp = Properties.Resources.Captura;
            Image imagenlogo = bmp;
            e.Graphics.DrawImage(imagenlogo, 30, 30, imagenlogo.Width, imagenlogo.Height);

            //Datos del cliente
            e.Graphics.DrawString($"Cliente: {matricula.cliente.nombre} {matricula.cliente.apellido} ", new Font("Arial Narrow", 12, FontStyle.Regular), Brushes.Black, new Point(45, 180));
            e.Graphics.DrawString($"Fecha: {DateTime.Now.Date.ToString("dd/MM/yyyy")} ", new Font("Arial Narrow", 12, FontStyle.Regular), Brushes.Black, new Point(45, 210));
            e.Graphics.DrawString($"DNI: {matricula.cliente.dni} ", new Font("Arial Narrow", 12, FontStyle.Regular), Brushes.Black, new Point(450, 180));

            //Descripcion

            //--CABECERA
            string line = "-------------------------------------------------------------------------------------------------------------------------------------";
            string items = "   CANTIDAD                        DESCRIPCION                                                                        SUBTOTAL  ";
            e.Graphics.DrawString(line, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(45, 250));
            e.Graphics.DrawString(items, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, new Point(45, 270));
            e.Graphics.DrawString(line, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(45, 285));

            //--CONTENIDO
            e.Graphics.DrawString("01", new Font("Arial Narrow", 12, FontStyle.Regular), Brushes.Black, new Point(73, 305));
            e.Graphics.DrawString($"Pago restante por {matricula.plan.cantidadMeses} meses", new Font("Arial Narrow", 12, FontStyle.Regular), Brushes.Black, new Point(200, 305));
            e.Graphics.DrawString($"S/.{restante}", new Font("Arial Narrow", 12, FontStyle.Regular), Brushes.Black, new Point(605, 305));


            //--Mensaje
            e.Graphics.DrawString("PAGO COMPLETO", new Font("Arial Narrow", 17, FontStyle.Bold), Brushes.Black, new Point(415, 400));
            

            //Pie
            e.Graphics.DrawString(line, new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(45, 500));
            e.Graphics.DrawString($"    Restante S/.  {restante}", new Font("Arial Narrow", 12, FontStyle.Regular), Brushes.Black, new Point(615, 520));


        }

        private void nudMonto_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
