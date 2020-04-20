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
    public class DMatricula
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["miconexion"].ConnectionString);
        public int NuevaMatricula(Matricula matricula)
        {
            SqlCommand cmd = new SqlCommand("usp_matricula_registrar", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@parCliente", matricula.cliente.id);
            cmd.Parameters.AddWithValue("@parEmpleado", matricula.empleado.id);
            cmd.Parameters.AddWithValue("@parTotal", matricula.total);
            cmd.Parameters.AddWithValue("@parFecha", matricula.fecha);
            cmd.Parameters.AddWithValue("@parFechaIni", matricula.fechaInicio);
            cmd.Parameters.AddWithValue("@parFechaFin", matricula.fechaFin);
            cmd.Parameters.AddWithValue("@parNPagos", matricula.numeroPagos);
            cmd.Parameters.AddWithValue("@parPlan", matricula.plan.id);
            cmd.Parameters.AddWithValue("@parPromocion", matricula.promocion.id);

            conexion.Open();
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            conexion.Close();

            return id;

        }

        public List<Matricula> listarMatriculas()
        {
            List<Matricula> listamatriculas = new List<Matricula>();

            SqlCommand cmd = new SqlCommand("usp_matricula_listar", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            conexion.Open();

            SqlDataReader data = cmd.ExecuteReader();

            while (data.Read() == true)
            {

                Planes planes = new Planes(Convert.ToInt32(data["IdPlan"]),
                                            Convert.ToInt32(data["CantidadMeses"]),
                                             Convert.ToDecimal(data["Precio"]),0);

                Empleado empleado = new Empleado(Convert.ToInt32(data["IdEmpleado"]),
                                             Convert.ToString(data["NombresEmpleado"]),
                                             null,
                                             Convert.ToString(data["DNI"]),
                                             null,null,null,null,null
                                             );

                Cliente cliente = new Cliente(Convert.ToInt32(data["IdCliente"]),
                                           Convert.ToString(data["nombresCliente"]),
                                           null,
                                           Convert.ToString(data["dniCliente"]),
                                           null,null,DateTime.Now
                                           );

                Promociones promocion = new Promociones(Convert.ToInt32(data["IdPromocion"]),
                                          Convert.ToString(data["Nombre"]),
                                          Convert.ToInt32(data["Descuento"])
                                           );

                Matricula matricula = new Matricula(Convert.ToInt32(data["IdMatricula"]),
                                                    cliente, empleado,
                                                    Convert.ToDecimal(data["Total"]),
                                                    Convert.ToDateTime(data["Fecha"]),
                                                    Convert.ToDateTime(data["FechaIni"]),
                                                    Convert.ToDateTime(data["FechaFin"]),
                                                    Convert.ToInt32(data["NPagos"]),
                                                    planes, promocion
                                                    );

                listamatriculas.Add(matricula);



            }

            conexion.Close();
            return listamatriculas;

        }


        public List<Matricula> listarMatriculasActivas (int idCliente)
        {
            List<Matricula> listamatriculas = new List<Matricula>();

            SqlCommand cmd = new SqlCommand("usp_matricula_activa", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idCliente", idCliente );

            conexion.Open();

            SqlDataReader data = cmd.ExecuteReader();

            while (data.Read() == true)
            {
                Matricula matricula = new Matricula(Convert.ToInt32(data["IdMatricula"]),
                                                   Convert.ToDecimal(data["Total"]),
                                                   Convert.ToDateTime(data["Fecha"]),
                                                   Convert.ToDateTime(data["FechaIni"]),
                                                   Convert.ToDateTime(data["FechaFin"]),
                                                   Convert.ToInt32(data["NPagos"])
                                                   );

                listamatriculas.Add(matricula);

            }

            conexion.Close();
            return listamatriculas;

        }

    }
}
