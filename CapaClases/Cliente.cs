using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaClases
{
    public class Cliente
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string dni { get; set; }
        public string telefono { get; set; }
        public string telefonoEmergencia { get; set; }
        public DateTime nacimiento { get; set; }


        public Cliente(int Id,string Nombre,string Apellido,string Dni,string Telefono,string TelEmer,DateTime Nacimiento)
        {
            this.id = Id;
            this.nombre = Nombre;
            this.apellido = Apellido;
            this.dni = Dni;
            this.telefono = Telefono;
            this.telefonoEmergencia = TelEmer;
            this.nacimiento = Nacimiento;
        }

    }
}
