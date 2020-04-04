using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;
using CapaClases;

using System.Data;
using System.Data.SqlClient;

namespace CapaNegocio
{
    public class DEstado
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["miconexion"].ConnectionString);

        public bool NuevoEstado(Estado estado)
        {

            SqlCommand cmd = new SqlCommand("usp_estado_registrar", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@parTalla", estado.talla);
            cmd.Parameters.AddWithValue("@parPeso", estado.peso);
            cmd.Parameters.AddWithValue("@parObservaciones", estado.observaciones);
            cmd.Parameters.AddWithValue("@parPecho", estado.pecho);
            cmd.Parameters.AddWithValue("@parBiceps", estado.biceps);
            cmd.Parameters.AddWithValue("@parCintura", estado.cintura);
            cmd.Parameters.AddWithValue("@parTriceps", estado.triceps);
            cmd.Parameters.AddWithValue("@parPantorrilla", estado.pantorrilla);
            cmd.Parameters.AddWithValue("@parCliente", estado.cliente.id);
            cmd.Parameters.AddWithValue("@parFecha", estado.fecha);

            conexion.Open();
            try
            {
                Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception)
            {
                
                return false;
                throw;
            }

            conexion.Close();
            return true;

        }

        public List<Estado> listarEstados(int idCliente)
        {
            List<Estado> listaestados = new List<Estado>();


            SqlCommand cmd = new SqlCommand("usp_estado_listar", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            conexion.Open();

            cmd.Parameters.AddWithValue("@parCliente", idCliente);

            SqlDataReader data = cmd.ExecuteReader();

            while (data.Read() == true)
            {
                Estado estado = new Estado(Convert.ToInt32(data["IdEstado"]),
                                           Convert.ToDecimal(data["Talla"]),
                                           Convert.ToDecimal(data["Peso"]),
                                           Convert.ToString(data["Observaciones"]),
                                           Convert.ToDecimal(data["Pecho"]),
                                           Convert.ToDecimal(data["Biceps"]),
                                           Convert.ToDecimal(data["Cintura"]),
                                           Convert.ToDecimal(data["Triceps"]),
                                           Convert.ToDecimal(data["Pantorrilla"]),
                                           Convert.ToDateTime(data["FechaRegistro"])
                                           );
                listaestados.Add(estado);
            }

            conexion.Close();
            return listaestados;

        }
    }
}
