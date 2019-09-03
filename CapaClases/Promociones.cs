using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaClases
{
    public class Promociones
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int descuento { get; set; }

        public Promociones(int Id,string Nombre,int Descuento)
        {
            this.id = Id;
            this.nombre = Nombre;
            this.descuento = Descuento;
        }
    }
}
