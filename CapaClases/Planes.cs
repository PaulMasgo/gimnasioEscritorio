using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaClases
{
    public class Planes
    {
        public int id { get; set; }
        public int cantidadMeses { get; set; }
        public decimal precio { get; set; }
        public int pagosMaximos { get; set; }


        public Planes (int Id,int CantidadMeses,decimal Precio,int PagosMaximos)
        {
            this.id = Id;
            this.cantidadMeses = CantidadMeses;
            this.precio = Precio;
            this.pagosMaximos = PagosMaximos;
        }
    }
}
