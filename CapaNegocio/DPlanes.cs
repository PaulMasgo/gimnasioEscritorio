using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaClases;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace CapaNegocio
{
    public class DPlanes
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["miconexion"].ConnectionString);

        public List<Planes> listarPlanes()
        {
            List<Planes> listaPlanes = new List<Planes>();

            SqlCommand cmd = new SqlCommand("usp_planes_listar", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            conexion.Open();

            SqlDataReader data = cmd.ExecuteReader();

            while (data.Read() == true)
            {
                Planes fila = new Planes(Convert.ToInt32(data["IdPlan"]),
                                          Convert.ToInt32(data["CantidadMeses"]),
                                          Convert.ToDecimal(data["Precio"]),
                                          Convert.ToInt32(data["PagosMaximos"])
                                           );
                listaPlanes.Add(fila);
            }

            conexion.Close();
            return listaPlanes;

        }


        public bool NuevaPlan(Planes plan)
        {
            SqlCommand cmd = new SqlCommand("usp_planes_registrar", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@parMeses", plan.cantidadMeses);
            cmd.Parameters.AddWithValue("@parPrecio", plan.precio);
            cmd.Parameters.AddWithValue("@parpagos", plan.pagosMaximos);

            conexion.Open();
            try
            {
                Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                return false;
                
            }
            
            conexion.Close();
            return true;

        }
    }
}
