using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaClases
{
    public class Matricula
    {
        public int idMatricula { get; set; }
        public Cliente cliente { get; set; }
        public Empleado empleado { get; set; }
        public decimal total { get; set; }
        public DateTime fecha { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public int numeroPagos { get; set; }
        public Planes plan { get; set; }
        public Promociones promocion { get; set; }


        public Matricula(int Id, Cliente Cliente, Empleado Empleado, decimal Total, DateTime Fecha, DateTime FechaInicio, DateTime Fechafin, int NPagos, Planes Plan,Promociones Promocion)
        {
            this.idMatricula = Id;
            this.cliente = Cliente;
            this.empleado = Empleado;
            this.total = Total;
            this.fecha = Fecha;
            this.fechaInicio = FechaInicio;
            this.fechaFin = Fechafin;
            this.numeroPagos = NPagos;
            this.plan = Plan;
            this.promocion = Promocion;
        }

    } 

   
}
