using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaClases
{
    public class Asistencia
    {
        public int idAsistencia { get; set; }
        public DateTime fecha { get; set; }
        public Cliente cliente { get; set; }
        public Empleado empleado { get; set; }

        public Asistencia(DateTime Fecha,Cliente Cliente,Empleado Empleado  )
        {
            this.fecha = Fecha;
            this.cliente = Cliente;
            this.empleado = Empleado;
        }

        public Asistencia(DateTime Fecha)
        {
            this.fecha = Fecha;
        }

    }
}
