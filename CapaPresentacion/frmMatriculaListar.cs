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
        public List<Pago> MyProperty { get; set; }



        public void Listar()
        {
            DMatricula dmatricula = new DMatricula();
            DPago dpago = new DPago();

            listamatriculas.Clear();
            dgvMatriculas.Rows.Clear();

            foreach (Matricula matricula in dmatricula.listarMatriculas())
            {
                this.listamatriculas.Add(matricula);

                List<Pago> pagos = dpago.listarPagos(matricula.idMatricula);
                decimal montopagado = 0 ;

                foreach (Pago item in pagos)
                {
                    montopagado = montopagado + item.monto; 
                }

                string estado = montopagado == matricula.total ? "Completado" : "No completado";
                string finalizacion = DateTime.Now > matricula.fechaFin ? "Finalizado" : "En curso";

                dgvMatriculas.Rows.Add(matricula.cliente.nombre,
                                       matricula.fecha.ToShortDateString(),
                                       matricula.fechaInicio.ToShortDateString(),
                                       matricula.fechaFin.ToShortDateString(),
                                       $"S/. {matricula.total}" ,
                                       $"{matricula.plan.cantidadMeses} meses" ,
                                       estado, finalizacion
                                       );

                foreach (DataGridViewRow item in dgvMatriculas.Rows)
                {
                    if (item.Cells[6].Value.Equals("No completado"))
                    {
                        item.Cells[6].Style.BackColor = Color.Red;
                        item.Cells[6].Style.ForeColor = Color.White;
                    }
                    else
                    {
                        item.Cells[6].Style.BackColor = Color.Yellow;
                    }
                }

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

            if (detalles.ShowDialog() == DialogResult.Cancel)
            {
                Listar();
            }

        }
    }
}
