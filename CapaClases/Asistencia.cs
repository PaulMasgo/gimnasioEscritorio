using System;

namespace CapaClases
{
    public class Asistencia
    {
        public int Id { get; set; }
        public int IdMatricula { get; set; }
        public string RegistradoPor { get; set; }
        public string ActualizadoPor { get; set; }
        public string FecRegistro { get; set; }
        public DateTime? FecActualizado { get; set; }
        public bool Estado { get; set; }

        // Lo que falta 
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public string DNI { get; set; }

        public Asistencia(string nombre, string apellido,string dni,
            int idMatricula, string fecRegistro ,bool estado)
        {
            Nombre = nombre;
            Apellido = apellido;
            DNI = dni;
            IdMatricula = idMatricula;
            FecRegistro = fecRegistro;
            Estado = estado;
        }
    }
}
