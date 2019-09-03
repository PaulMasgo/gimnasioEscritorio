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
    public partial class frmMatriculaListar : Form
    {
        public frmMatriculaListar()
        {
            InitializeComponent();
        }


        List<Matricula> listamatriculas = new List<Matricula>();
        public Matricula matriculaSeleccionada { get; set; }



        public void Listar()
        {
            DMatricula dmatricula = new DMatricula();
            listamatriculas.Clear();

            foreach (Matricula item in dmatricula.listarMatriculas())
            {
                this.listamatriculas.Add(item);
                dgvMatriculas.Rows.Add(item.cliente.nombre,
                                       item.fecha.ToShortDateString(),
                                       item.fechaInicio.ToShortDateString(),
                                       item.fechaFin.ToShortDateString(),
                                       "S/. " + item.total, item.numeroPagos,
                                       item.plan.cantidadMeses + " meses");
            }
        }

        private void FrmMatriculaListar_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void BtnDetalles_Click(object sender, EventArgs e)
        {
            this.matriculaSeleccionada = listamatriculas[dgvMatriculas.SelectedRows[0].Index];
            frmMatriculaDetalles detalles = new frmMatriculaDetalles();
            detalles.matricula = this.matriculaSeleccionada;
            detalles.ShowDialog();
        }
    }
}
