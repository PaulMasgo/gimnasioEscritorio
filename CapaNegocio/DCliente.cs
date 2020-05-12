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
    public class DCliente
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["miconexion"].ConnectionString);

        public bool NuevoCliente(Cliente cliente)
        {
        
            SqlCommand cmd = new SqlCommand("usp_cliente_registrar", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@parNombre", cliente.nombre);
            cmd.Parameters.AddWithValue("@parApellidos", cliente.apellido);
            cmd.Parameters.AddWithValue("@parDni ", cliente.dni);
            cmd.Parameters.AddWithValue("@parTelefono", cliente.telefono);
            cmd.Parameters.AddWithValue("@parTelefonoEmer", cliente.telefonoEmergencia);
            cmd.Parameters.AddWithValue("@parFecha", cliente.nacimiento);

            conexion.Open();
            try
            {
                 Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2601)
                {
                    return false;
                } 
            }
            
            conexion.Close();
            return true;


        }

        public List<Cliente> listarClientes()
        {
            List<Cliente> listaClientes = new List<Cliente>();

            SqlCommand cmd = new SqlCommand("usp_cliente_listar", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            conexion.Open();

            SqlDataReader data = cmd.ExecuteReader();

            while (data.Read() == true)
            {
                Cliente fila = new Cliente(Convert.ToInt32(data["IdCliente"]),
                                           Convert.ToString(data["Nombre"]),
                                           Convert.ToString(data["Apellido"]),
                                           Convert.ToString(data["DNI"]),
                                           Convert.ToString(data["Telefono"]),
                                           Convert.ToString(data["TelefonoEmergencia"]),
                                           Convert.ToDateTime(data["FechaNacimiento"])
                                           );
                listaClientes.Add(fila);
            }

            conexion.Close();
            return listaClientes;

        }


        public List<Cliente> listarClientesPrametro(string parametro)
        {
            List<Cliente> listaClientes = new List<Cliente>();

            SqlCommand cmd = new SqlCommand("usp_cliente_listar_termino", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            conexion.Open();
            cmd.Parameters.AddWithValue("@param", parametro);

            SqlDataReader data = cmd.ExecuteReader();

            while (data.Read() == true)
            {
                Cliente fila = new Cliente(Convert.ToInt32(data["IdCliente"]),
                                           Convert.ToString(data["Nombre"]),
                                           Convert.ToString(data["Apellido"]),
                                           Convert.ToString(data["DNI"]),
                                           Convert.ToString(data["Telefono"]),
                                           Convert.ToString(data["TelefonoEmergencia"]),
                                           Convert.ToDateTime(data["FechaNacimiento"])
                                           );
                listaClientes.Add(fila);
            }

            conexion.Close();
            return listaClientes;

        }

        public List<Cliente> listarReporteasistencia(DateTime fechainicio,DateTime fechafin)
        {
            List<Cliente> listaClientes = new List<Cliente>();

            SqlCommand cmd = new SqlCommand("sp_ReporteFechas", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            conexion.Open();
            cmd.Parameters.AddWithValue("@paramFecInicio", fechainicio); 
            cmd.Parameters.AddWithValue("@paramFecFin", fechafin);

            SqlDataReader data = cmd.ExecuteReader();

            while (data.Read() == true)
            {
                Cliente fila = new Cliente(Convert.ToDateTime(data["Fecha"]),
                                           Convert.ToString(data["Nombre"]),
                                           Convert.ToString(data["Apellido"]),
                                           Convert.ToString(data["DNI"]));
                                                                          
                listaClientes.Add(fila);
            }

            conexion.Close();
            return listaClientes;

        }

        public void ActualizarCliente(Cliente cliente)
        {
            SqlCommand cmd = new SqlCommand("usp_cliente_actualizar", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@parId", cliente.id);
            cmd.Parameters.AddWithValue("@parNombre", cliente.nombre);
            cmd.Parameters.AddWithValue("@parApellidos", cliente.apellido);
            cmd.Parameters.AddWithValue("@parDni ", cliente.dni);
            cmd.Parameters.AddWithValue("@parTelefono", cliente.telefono);
            cmd.Parameters.AddWithValue("@parTelefonoEmer", cliente.telefonoEmergencia);
            cmd.Parameters.AddWithValue("@parFecha", cliente.nacimiento);

            conexion.Open();
            cmd.ExecuteScalar();
            conexion.Close();

        }

        public Cliente listarClienteDni(string dni)
        {
            Cliente Cliente = null;

            SqlCommand cmd = new SqlCommand("usp_cliente_buscar_dni", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            conexion.Open();
            cmd.Parameters.AddWithValue("@param", dni);

            SqlDataReader data = cmd.ExecuteReader();

            while (data.Read() == true)
            {
                Cliente = new Cliente(Convert.ToInt32(data["IdCliente"]),
                                            Convert.ToString(data["Nombre"]),
                                            Convert.ToString(data["Apellido"]),
                                            Convert.ToString(data["DNI"]),
                                            Convert.ToString(data["Telefono"]),
                                            Convert.ToString(data["TelefonoEmergencia"]),
                                            Convert.ToDateTime(data["FechaNacimiento"])
                                            );
                           }

            conexion.Close();
            return Cliente;

        }

        public List<Cliente> listarClienteMatriculaActiva()
        {
            List<Cliente> Clientes = new List<Cliente>();

            SqlCommand cmd = new SqlCommand("usp_cliente_listar_asistencia", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            conexion.Open();

            SqlDataReader data = cmd.ExecuteReader();

            while (data.Read() == true)
            {
                Cliente cliente = new Cliente(Convert.ToInt32(data["IdCliente"]),
                                            Convert.ToString(data["Nombre"]),
                                            Convert.ToString(data["Apellido"]),
                                            Convert.ToString(data["DNI"]),
                                            Convert.ToString(data["Telefono"]),
                                            Convert.ToString(data["TelefonoEmergencia"]),
                                            Convert.ToDateTime(data["FechaNacimiento"])
                                            );

                Clientes.Add(cliente);

            }

            conexion.Close();
            return Clientes;
        }


    }
    
}
