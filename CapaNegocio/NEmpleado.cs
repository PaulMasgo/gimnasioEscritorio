﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;
using CapaClases;

using System.Data;
using System.Data.SqlClient;

namespace CapaNegocio
{
    public class NEmpleado
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString);

        public void NuevoEmpleado(Empleado empleado)
        {
            SqlCommand cmd = new SqlCommand("usp_empleado_insertar", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@parNombres", empleado.nombres);
            cmd.Parameters.AddWithValue("@parApellidos", empleado.apellidos);
            cmd.Parameters.AddWithValue("@parCorreo", empleado.correo);
            cmd.Parameters.AddWithValue("@parDni", empleado.dni);
            cmd.Parameters.AddWithValue("@parDireccion", empleado.direccion);
            cmd.Parameters.AddWithValue("@parCelular", empleado.celular);
            cmd.Parameters.AddWithValue("@parContraseña", empleado.contrasenia);

            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();

        }

        public List<Empleado> ListarEmpleados()
        {
            List<Empleado> listaEmpleados = new List<Empleado>();

            SqlCommand cmd = new SqlCommand("usp_listar_empleados", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            conexion.Open();

            SqlDataReader lector;
            lector = cmd.ExecuteReader();

            while (lector.Read() == true)
            {
                Empleado fila = new Empleado(Convert.ToInt32(lector["IdEmpleado"]),
                                             Convert.ToString(lector["Nombres"]),
                                             Convert.ToString(lector["Apellidos"]),
                                             Convert.ToString(lector["DNI"]),
                                             Convert.ToString(lector["Direccion"]),
                                             Convert.ToString(lector["Celular"]),
                                             null,
                                             Convert.ToString(lector["Correo"]),
                                             Convert.ToString(lector["Tipo"])
                                             );
                listaEmpleados.Add(fila);
            }
            conexion.Close();
            return listaEmpleados;

        }

        public void ActualizarEmpleado(Empleado empleado)
        {
            SqlCommand cmd = new SqlCommand("usp_empleado_actualizar", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@parID", empleado.id);
            cmd.Parameters.AddWithValue("@parNombres", empleado.nombres);
            cmd.Parameters.AddWithValue("@parApellidos", empleado.apellidos);
            cmd.Parameters.AddWithValue("@parCorreo", empleado.correo);
            cmd.Parameters.AddWithValue("@parDni", empleado.dni);
            cmd.Parameters.AddWithValue("@parDireccion", empleado.direccion);
            cmd.Parameters.AddWithValue("@parCelular", empleado.celular);
            cmd.Parameters.AddWithValue("@parTipo", empleado.tipo);

            conexion.Open();
            cmd.ExecuteNonQuery();
            conexion.Close();

        }

        public List<Empleado> ListarEmpleadosTermino(string termino)
        {
            List<Empleado> listaEmpleados = new List<Empleado>();

            SqlCommand cmd = new SqlCommand("usp_empleado_listar_termino", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@parTermino", termino);

            conexion.Open();

            SqlDataReader data;
            data = cmd.ExecuteReader();

            while (data.Read() == true)
            {
                Empleado fila = new Empleado(Convert.ToInt32(data["IdEmpleado"]),
                                             Convert.ToString(data["Nombres"]),
                                             Convert.ToString(data["Apellidos"]),
                                             Convert.ToString(data["DNI"]),
                                             Convert.ToString(data["Direccion"]),
                                             Convert.ToString(data["Celular"]),
                                             null,
                                             Convert.ToString(data["Correo"]),
                                             Convert.ToString(data["Tipo"])
                                             );
                listaEmpleados.Add(fila);
            }
            conexion.Close();
            return listaEmpleados;

        }

      

    }
}
