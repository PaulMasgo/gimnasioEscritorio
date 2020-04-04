using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace CapaPresentacion
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hand,int wmsg,int wparam,int lparam);



        private void BtnSlide_Click(object sender, EventArgs e)
        {
            if(menuVertical.Width == 250)
            {
                menuVertical.Width = 70;
            }
            else
            {
                menuVertical.Width = 250;
            }
        }


        public void colores()
        {
            btnAsistencia.BackColor = Color.Green;
            btnMatricula.BackColor = Color.Green;
            button1.BackColor = Color.Green;
            btnControl.BackColor = Color.Green;
            btnEmpleados.BackColor = Color.Green;
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);

        }

        private void abrirFormularioenPaenl(object Hijo)
        {
            if(this.panelContenedor.Controls.Count > 0)
            {
                this.panelContenedor.Controls.RemoveAt(0);
            }


            Form formularioHijo = Hijo as Form;
            formularioHijo.TopLevel = false;
            this.panelContenedor.Controls.Add(formularioHijo);
            this.panelContenedor.Tag = formularioHijo;
            formularioHijo.Show();



        }

        private void BtnAsistencia_Click(object sender, EventArgs e)
        {
            colores();
            abrirFormularioenPaenl(new frmMatriculaListar());
            btnAsistencia.BackColor = Color.Black;
        }

        private void BtnEmpleados_Click(object sender, EventArgs e)
        {
            colores();
            abrirFormularioenPaenl(new frmEmpleados());
            btnEmpleados.BackColor = Color.Black;
        }

        private void PanelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnControl_Click(object sender, EventArgs e)
        {
            colores();
            abrirFormularioenPaenl(new frmEstadoRegistro());
            btnControl.BackColor = Color.Black;
        }

        private void BtnMatricula_Click(object sender, EventArgs e)
        {
            colores();
            abrirFormularioenPaenl(new frmMatriculaRegistro());
            btnMatricula.BackColor = Color.Black;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            colores();
            abrirFormularioenPaenl(new frmClientes());
            button1.BackColor = Color.Black;
        }

        private void BtnPlanes_Click(object sender, EventArgs e)
        {
            colores();
            abrirFormularioenPaenl(new frmPlanesPromociones());
            btnPlanes.BackColor = Color.Black;
        }
    }
}
