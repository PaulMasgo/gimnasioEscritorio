using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaClases
{
    public class Pago
    {
        public int id { get; set; }
        public decimal monto { get; set; }
        public DateTime fecha { get; set; }
        public Matricula matricula { get; set; }

        public Pago(int Id,decimal Monto,DateTime Fecha,Matricula Matricula)
        {
            this.id = Id;
            this.monto = Monto;
            this.fecha = Fecha;
            this.matricula = Matricula;
        }

    }
}
