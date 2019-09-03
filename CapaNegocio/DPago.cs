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
   
    public class DPago
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["miconexion"].ConnectionString);

        public void NuevaPago(Pago pago)
        {
            SqlCommand cmd = new SqlCommand("usp_pago_registrar", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@parMonto", pago.monto );
            cmd.Parameters.AddWithValue("@parFecha", pago.fecha);
            cmd.Parameters.AddWithValue("@parMatricula", pago.matricula.idMatricula);

            conexion.Open();
            Convert.ToInt32(cmd.ExecuteScalar());
            conexion.Close();   

        }


        public List<Pago> listarPagos(int matricula)
        {
            List<Pago> listaPagos = new List<Pago>();

            SqlCommand cmd = new SqlCommand("usp_pago_listar", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            conexion.Open();
            cmd.Parameters.AddWithValue("@parIdmatricula", matricula);

            SqlDataReader data = cmd.ExecuteReader();

            while (data.Read() == true)
            {
                Pago fila = new Pago(Convert.ToInt32(data["IdPago"]),
                                     Convert.ToDecimal(data["Monto"]),
                                     Convert.ToDateTime(data["Fecha"]),
                                     null
                                     );
                listaPagos.Add(fila);
            }

            conexion.Close();
            return listaPagos;

        }

    }
}
