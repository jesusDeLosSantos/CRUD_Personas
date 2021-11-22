using CRUD_Personas_Entities;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CRUD_Personas_DAL.Gestoras
{
    public class GestoraAccionesDepartamentosDAL
    {
        /// <summary>
        /// Este metodo borra el departamento que coincida con el id introducido
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve un entero que corresponde a las filas afectadas</returns>
        public static int deleteDepartamentoDAL(int id)
        {

            int resultado = 0;

            SqlConnection conexion = new SqlConnection();
            clsMyConnection miConexion = new clsMyConnection();
            SqlCommand miComando = new SqlCommand();

            conexion = miConexion.getConnection();

            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

            try
            {
                miComando.CommandText = "DELETE FROM Departamentos WHERE IDDepartamento=@id";
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
        /// <param name="id"></param>
        /// <returns>Devuelve un entero que corresponde a las filas afectadas</returns>
        public static int addDepartamentoDAL(clsDepartamento departamento)
        {

            int resultado = 0;

            SqlConnection conexion = new SqlConnection();
            clsMyConnection miConexion = new clsMyConnection();
            SqlCommand miComando = new SqlCommand();

            conexion = miConexion.getConnection();

            try
            {
                miComando.Parameters.Add(new SqlParameter("@nombreDepartamento", departamento.Nombre));
                miComando.CommandText = "INSERT INTO Departamentos VALUES (@nombreDepartamento)";
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
        public static int alterDepartamentoDAL(clsDepartamento departamento)
        {

            int resultado = 0;

            SqlConnection conexion = new SqlConnection();
            clsMyConnection miConexion = new clsMyConnection();
            SqlCommand miComando = new SqlCommand();

            conexion = miConexion.getConnection();

            try
            {
                //miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = departamento.Id;
                miComando.Parameters.Add(new SqlParameter("@nombreDepartamento", departamento.Nombre));
                miComando.Parameters.Add(new SqlParameter("@id", departamento.Id));
                miComando.CommandText = "UPDATE Departamentos SET nombreDepartamento = @nombreDepartamento WHERE IDDepartamento = @id";
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
