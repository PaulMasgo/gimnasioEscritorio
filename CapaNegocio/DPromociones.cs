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
    public class DPromociones
    {

        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["miconexion"].ConnectionString);

        public List<Promociones> listarPromociones()
        {
            List<Promociones> listapromociones = new List<Promociones>();

            SqlCommand cmd = new SqlCommand("usp_promociones_listar", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            conexion.Open();

            SqlDataReader data = cmd.ExecuteReader();

            while (data.Read() == true)
            {
                Promociones fila = new Promociones(Convert.ToInt32(data["IdPromocion"]),
                                          Convert.ToString(data["Nombre"]),
                                          Convert.ToInt32(data["Descuento"])
                                           );
                listapromociones.Add(fila);
            }

            conexion.Close();
            return listapromociones;

        }
    }
}
