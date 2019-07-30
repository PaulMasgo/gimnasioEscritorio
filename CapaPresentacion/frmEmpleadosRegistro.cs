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
using System.Security.Cryptography;

namespace CapaPresentacion
{
    public partial class frmEmpleadosRegistro : Form
    {
        public frmEmpleadosRegistro()
        {
            InitializeComponent();
        }

        Config config = new Config();

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {

            Close();

        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {

            //====================== Encriptando Contraseña ==========================

            string contraseña;
            string hash = "Gim@5i0";

            byte[] data = UTF8Encoding.UTF8.GetBytes(txtContraseña1.Text);
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

            // ==================================================================================


            // ======================== Relizando registro de empleado ============================


            if (txtContraseña1.Text != txtContraseña2.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden", "No se pudo completa la operación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult pregunta = MessageBox.Show("Desea Registrar al nuevo empleado", "Aviso", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if(pregunta == DialogResult.Yes)
                {
                    Empleado empleado = new Empleado(0,txtNombres.Text,txtApellidos.Text,txtDNI.Text,txtDireccion.Text,txtCelular.Text,contraseña,txtCorreo.Text,null);
                    NEmpleado Negocio = new NEmpleado();
                    Negocio.NuevoEmpleado(empleado);
                    MessageBox.Show("Empleado Registrado", "Realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //============ Limpiar cuadros de texto ==================
                        config.limpiarTextbox(this.Controls);
                    //=========================================================
                }
               
            }
            
            // ==============================================================================================================


        }

        private void FrmEmpleadosRegistro_Load(object sender, EventArgs e)
        {

        }
    }
}
