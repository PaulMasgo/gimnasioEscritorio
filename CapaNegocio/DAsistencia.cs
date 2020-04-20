using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using CapaClases;

namespace CapaNegocio
{
    public class DAsistencia
    {
        static SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["miconexion"].ConnectionString);

        public static void registrarAsistencia(Asistencia asistencia)
        {
            SqlCommand cmd = new SqlCommand("usp_asistencia_registrar", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@fecha", asistencia.fecha);
            cmd.Parameters.AddWithValue("@cliente", asistencia.cliente.id);
            cmd.Parameters.AddWithValue("@empleado", asistencia.empleado.id);

            conexion.Open();
            cmd.ExecuteScalar();
            conexion.Close();

        }

        public static Asistencia verificarAsistencia(DateTime fecha , int cliente)
        {
            Asistencia asistencia = null;

            SqlCommand cmd = new SqlCommand("usp_asistencia_verificar", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            conexion.Open();

            cmd.Parameters.AddWithValue("@cliente", cliente);
            cmd.Parameters.AddWithValue("@fecha", fecha);

            SqlDataReader data = cmd.ExecuteReader();

            while (data.Read() == true)
            {
                asistencia = new Asistencia(Convert.ToDateTime(data["Fecha"]));
            }

            conexion.Close();
            return asistencia;

        }


    }
}
