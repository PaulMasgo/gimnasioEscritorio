using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaClases
{
    public class Empleado
    {
        public int id { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string dni { get; set; }
        public string direccion { get; set; }
        public string celular { get; set; }
        public string contrasenia { get; set; }
        public string estado { get; set; }
        public string correo { get; set; }
        public string tipo { get; set; }

        public Empleado (int ID,string Nombre,string Apellido,string Dni,string Direccion,string Celular,string Contrasenia,string Correo,string Tipo)
        {
            this.id = ID;
            this.nombres = Nombre;
            this.apellidos = Apellido;
            this.dni = Dni;
            this.direccion = Direccion;
            this.celular = Celular;
            this.contrasenia = Contrasenia;
            this.correo = Correo;
            this.tipo = Tipo;
        }

        public Empleado(int ID, string Nombre, string Apellido, string Dni, string Direccion, string Celular, string Contrasenia, string Correo, string Tipo,string Estado)
        {
            this.id = ID;
            this.nombres = Nombre;
            this.apellidos = Apellido;
            this.dni = Dni;
            this.direccion = Direccion;
            this.celular = Celular;
            this.contrasenia = Contrasenia;
            this.correo = Correo;
            this.tipo = Tipo;
            this.estado = Estado;
        }
    }
}
