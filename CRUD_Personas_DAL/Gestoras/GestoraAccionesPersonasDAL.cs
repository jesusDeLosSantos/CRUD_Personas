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
                miComando.Parameters.Add(new SqlParameter("@nombrePersona", persona.Nombre));
                miComando.Parameters.Add(new SqlParameter("@apellidosPersona", persona.Apellidos));
                miComando.Parameters.Add(new SqlParameter("@fechaNacimiento", persona.FechaNacimiento));
                miComando.Parameters.Add(new SqlParameter("@telefono", persona.Telefono));
                miComando.Parameters.Add(new SqlParameter("@direccion", persona.Direccion));
                miComando.Parameters.Add(new SqlParameter("@IDDepartamento", persona.IdDepartamento));
                miComando.Parameters.Add(new SqlParameter("@foto", persona.Foto));
                miComando.CommandText = "INSERT INTO Personas (nombrePersona, apellidosPersona, fechaNacimiento, telefono, direccion, IDDepartamento, foto) VALUES (@nombrePersona, @apellidosPersona, @fechaNacimiento, @telefono, @direccion, @IDDepartamento, @foto)";
                
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

            conexion = miConexion.getConnection();

            try
            {
                miComando.Parameters.Add(new SqlParameter("@id", persona.Id));
                miComando.Parameters.Add(new SqlParameter("@nombrePersona", persona.Nombre));
                miComando.Parameters.Add(new SqlParameter("@apellidosPersona", persona.Apellidos));
                miComando.Parameters.Add(new SqlParameter("@fechaNacimiento", persona.FechaNacimiento));
                miComando.Parameters.Add(new SqlParameter("@telefono", persona.Telefono));
                miComando.Parameters.Add(new SqlParameter("@direccion", persona.Direccion));
                miComando.Parameters.Add(new SqlParameter("@IDDepartamento", persona.IdDepartamento));
                miComando.Parameters.Add(new SqlParameter("@foto", persona.Foto));
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
