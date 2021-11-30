using CRUD_Personas_Entities;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CRUD_Personas_DAL.Gestoras
{
    public class GestoraAccionesPersonasDAL
    {
        /// <summary>
        /// Este metodo borra la persona que coincida con el id introducido
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve un entero que corresponde a las filas afectadas</returns>
        public static int deletePersonaDAL(int id)
        {

            int resultado = 0;

            SqlConnection conexion = new SqlConnection();
            clsMyConnection miConexion = new clsMyConnection();
            SqlCommand miComando = new SqlCommand();

            conexion = miConexion.getConnection();

            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

            try
            {
                conexion.Open();
                miComando.CommandText = "DELETE FROM Personas WHERE IDPersona=@id";
                miComando.Connection = conexion;

                resultado = miComando.ExecuteNonQuery();
                miConexion.closeConnection(ref conexion);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;
        }





        /// <summary>
        /// Este metodo añade un nuevo departamento a la bbdd
        /// </summary>
        /// <param name="persona"></param>
        /// <returns>Devuelve un entero que corresponde a las filas afectadas</returns>
        public static int addPersonaDAL(clsPersona persona)
        {

            int resultado = 0;

            SqlConnection conexion;
            clsMyConnection miConexion = new clsMyConnection();
            SqlCommand miComando = new SqlCommand();
            conexion = miConexion.getConnection();

            

            try
            {
                if (persona.Nombre == null)
                {
                    miComando.Parameters.Add(new SqlParameter("@nombrePersona", System.DBNull.Value));
                }
                else
                {
                    miComando.Parameters.Add(new SqlParameter("@nombrePersona", persona.Nombre));
                }

                if (persona.Apellidos == null)
                {
                    miComando.Parameters.Add(new SqlParameter("@apellidosPersona", System.DBNull.Value));
                }
                else
                {
                    miComando.Parameters.Add(new SqlParameter("@apellidosPersona", persona.Apellidos));
                }
                
                if (persona.FechaNacimiento == DateTime.MinValue)
                {
                    miComando.Parameters.Add(new SqlParameter("@fechaNacimiento", System.DBNull.Value));
                }
                else
                {
                    miComando.Parameters.Add(new SqlParameter("@fechaNacimiento", persona.FechaNacimiento));
                }

                if (persona.Telefono == null)
                {
                    miComando.Parameters.Add(new SqlParameter("@telefono", System.DBNull.Value));
                }
                else
                {
                    miComando.Parameters.Add(new SqlParameter("@telefono", persona.Telefono));
                }

                if (persona.Direccion == null)
                {
                    miComando.Parameters.Add(new SqlParameter("@direccion", System.DBNull.Value));
                }
                else
                {
                    miComando.Parameters.Add(new SqlParameter("@direccion", persona.Direccion));
                }

                if (persona.IdDepartamento == 0)
                {
                    miComando.Parameters.Add(new SqlParameter("@IDDepartemento", System.DBNull.Value));
                }
                else
                {
                    miComando.Parameters.Add(new SqlParameter("@IDDepartamento", persona.IdDepartamento));
                }

                if (persona.Foto == null)
                {
                    miComando.Parameters.Add(new SqlParameter("@foto", System.DBNull.Value));
                }
                else
                {
                    miComando.Parameters.Add(new SqlParameter("@foto", persona.Foto));
                }
                
                miComando.CommandText = "INSERT INTO Personas VALUES (@nombrePersona, @apellidosPersona, @fechaNacimiento, @telefono, @direccion, @IDDepartamento, @foto)";
                
                miComando.Connection = conexion;

                resultado = miComando.ExecuteNonQuery();
                miConexion.closeConnection(ref conexion);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;
        }





        /// <summary>
        /// Este metodo modifica el departamento según su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve un entero que corresponde a las filas afectadas</returns>
        public static int alterPersonaDAL(clsPersona persona)
        {

            int resultado = 0;

            SqlConnection conexion = new SqlConnection();
            clsMyConnection miConexion = new clsMyConnection();
            SqlCommand miComando = new SqlCommand();
            miComando.Parameters.Add(new SqlParameter("@id", persona.Id));

            conexion = miConexion.getConnection();

            try
            {
                if (persona.Nombre == null)
                {
                    miComando.Parameters.Add(new SqlParameter("@nombrePersona", System.DBNull.Value));
                }
                else
                {
                    miComando.Parameters.Add(new SqlParameter("@nombrePersona", persona.Nombre));
                }

                if (persona.Apellidos == null)
                {
                    miComando.Parameters.Add(new SqlParameter("@apellidosPersona", System.DBNull.Value));
                }
                else
                {
                    miComando.Parameters.Add(new SqlParameter("@apellidosPersona", persona.Apellidos));
                }

                if (persona.FechaNacimiento == DateTime.MinValue)
                {
                    miComando.Parameters.Add(new SqlParameter("@fechaNacimiento", System.DBNull.Value));
                }
                else
                {
                    miComando.Parameters.Add(new SqlParameter("@fechaNacimiento", persona.FechaNacimiento));
                }

                if (persona.Telefono == null)
                {
                    miComando.Parameters.Add(new SqlParameter("@telefono", System.DBNull.Value));
                }
                else
                {
                    miComando.Parameters.Add(new SqlParameter("@telefono", persona.Telefono));
                }

                if (persona.Direccion == null)
                {
                    miComando.Parameters.Add(new SqlParameter("@direccion", System.DBNull.Value));
                }
                else
                {
                    miComando.Parameters.Add(new SqlParameter("@direccion", persona.Direccion));
                }

                if (persona.IdDepartamento == 0)
                {
                    miComando.Parameters.Add(new SqlParameter("@IDDepartemento", System.DBNull.Value));
                }
                else
                {
                    miComando.Parameters.Add(new SqlParameter("@IDDepartamento", persona.IdDepartamento));
                }

                if (persona.Foto == null)
                {
                    miComando.Parameters.Add(new SqlParameter("@foto", System.DBNull.Value));
                }
                else
                {
                    miComando.Parameters.Add(new SqlParameter("@foto", persona.Foto));
                }
                miComando.CommandText = "UPDATE Personas SET nombrePersona = @nombrePersona, apellidosPersona = @apellidosPersona, fechaNacimiento = @fechaNacimiento, telefono = @telefono, direccion = @direccion, IDDepartamento = @IDDepartamento, Foto = @foto WHERE IDPersona = @id";
                miComando.Connection = conexion;

                resultado = miComando.ExecuteNonQuery();
                miConexion.closeConnection(ref conexion);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;
        }

    }
}
