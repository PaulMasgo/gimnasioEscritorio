using CapaClases;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CapaNegocio
{
    public class DAsistencia
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["miconexion"].ConnectionString);

        public bool AsistenciaRegistrar(Asistencia asistencia)
        {
            var cmd = new SqlCommand("usp_asistencia_registrar", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@parNombre", asistencia.IdMatricula);
            cmd.Parameters.AddWithValue("@parApellidos", asistencia.RegistradoPor);            ;

            conexion.Open();
          
            conexion.Close();
            return true;

        }

        public List<Asistencia> ListarAsistencias(string parametro)
        {
            List<Asistencia> asistencias = new List<Asistencia>();

            SqlCommand cmd = new SqlCommand("usp_asistencia_listar", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            conexion.Open();
            cmd.Parameters.AddWithValue("@parDNI", parametro);

            SqlDataReader data = cmd.ExecuteReader();

            while (data.Read() == true)
            {
                Asistencia fila = new Asistencia(Convert.ToString(data["Nombre"]),
                                           Convert.ToString(data["Apellido"]),
                                           Convert.ToString(data["DNI"]),
                                           Convert.ToInt32(data["IdMatricula"]),
                                           Convert.ToString(data["FecRegistro"]),
                                           Convert.ToBoolean(data["Estado"])
                                           );
                asistencias.Add(fila);
            }

            conexion.Close();
            return asistencias;

        }
    }
}
