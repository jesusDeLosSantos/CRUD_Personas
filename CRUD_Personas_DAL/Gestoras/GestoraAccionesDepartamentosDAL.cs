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
                conexion.Open();
                miComando.CommandText = "DELETE FROM Departamentos WHERE IDDepartamento=@id";
                miComando.Connection = conexion;

                resultado = miComando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;
        }



    }
}
