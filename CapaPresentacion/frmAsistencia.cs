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
    public partial class frmAsistencia : Form
    {

        public List<Cliente> clientesActivos = new List<Cliente>();
        public Cliente clienteSelecionado  { get; set; }
        public Empleado empleadoActivo { get; set; }

        public frmAsistencia()
        {
            InitializeComponent();
        }

        
        void listarClientes()
        {
            clientesActivos.Clear();
            dgvClientes.Rows.Clear();
            DCliente dcliente = new DCliente();

            foreach (Cliente cliente in dcliente.listarClienteMatriculaActiva())
            {
                string resultado = DAsistencia.verificarAsistencia(DateTime.Now, cliente.id) != null ? "Asistencia Registrada" : "Asistencia no registrada";
                clientesActivos.Add(cliente);
                dgvClientes.Rows.Add(cliente.apellido, cliente.nombre, cliente.dni, resultado);
            }

        }

      

        private void FrmAsistencia_Load(object sender, EventArgs e)
        {
            listarClientes();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            clienteSelecionado = clientesActivos[dgvClientes.SelectedRows[0].Index];
            Asistencia asistencia = new Asistencia(DateTime.Now,clienteSelecionado,mdlVariableAplicacion.EmpleadoActivo);
            if (DAsistencia.verificarAsistencia(DateTime.Now, clienteSelecionado.id) == null)
            {
                DAsistencia.registrarAsistencia(asistencia);
                MessageBox.Show("Asistencia Registrada", "Operación realizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listarClientes();
            }
            else
            {
                MessageBox.Show("La asistencia del usuario ya fue registrada", "Error de registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

          
           

        }
    }
}
