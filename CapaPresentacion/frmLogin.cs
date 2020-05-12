using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using CapaNegocio;
using CapaClases;

namespace CapaPresentacion
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        public Empleado empleado { get; set; }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void BackgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            NEmpleado nempleado = new NEmpleado();

            string contraseña;

            string hash = "Gim@5i0";

            byte[] data = UTF8Encoding.UTF8.GetBytes(txtcontraseña.Text);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider Tripdes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = Tripdes.CreateEncryptor();
                    byte[] resultados = transform.TransformFinalBlock(data, 0, data.Length);
                    contraseña = Convert.ToBase64String(resultados, 0, resultados.Length);
                }
            }

            this.empleado = nempleado.login(txtDni.Text, contraseña);

            if(this.empleado == null)
            {
                MessageBox.Show("Compruebe que el Dni y la contraseña sean los coreectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (this.empleado.estado == "Inactivo  ")
                {
                    MessageBox.Show($"El empleado {this.empleado.nombres} no se encuentra activo", "Error", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
                else
                {
                    mdlVariableAplicacion.EmpleadoActivo = this.empleado;
                    MessageBox.Show("Bienvenido " + this.empleado.nombres, "Logeo Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmPrincipal principal = new frmPrincipal();
                    principal.Show();
                    Close();
                }
               
            }

        }
    }
}
