using CRUD_Personas_Entities;
using DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Text;

namespace CRUD_Personas_DAL.Listados
{
    public class clsListadoDepartamentosDAL
    {
        private clsMyConnection myConnection;
        private SqlConnection sqlConnection;
        private ObservableCollection<clsDepartamento> listaDepartamentos;

        public clsListadoDepartamentosDAL()
        {
            myConnection = new clsMyConnection();
            listaDepartamentos = new ObservableCollection<clsDepartamento>();
        }

        public ObservableCollection<clsDepartamento> getDepartamentosCompletos()
        {
            clsDepartamento oDepartamento;
            SqlCommand command = new SqlCommand();
            sqlConnection = myConnection.getConnection();
            SqlDataReader reader;
            command.CommandText = "SELECT * FROM Departamentos";
            command.Connection = sqlConnection;
            reader = command.ExecuteReader();

            try
            {
                if (reader.Read())
                {
                    while (reader.Read())
                    {
                        oDepartamento = new clsDepartamento();
                        oDepartamento.Id = (int)reader["IDDepartamento"];
                        oDepartamento.Nombre = (string)reader["nombreDepartamento"];
                        listaDepartamentos.Add(oDepartamento);
                    }
                }
                reader.Close();
                sqlConnection.Close();
            }
            catch (Exception e) { }

            return listaDepartamentos;
        }


        public clsDepartamento getDepartamento(int id)
        {
            clsDepartamento oDepartamento;
            SqlCommand command = new SqlCommand();
            sqlConnection = myConnection.getConnection();
            SqlDataReader reader;
            command.Parameters.Add(new SqlParameter("@id", id));
            command.CommandText = "SELECT * FROM Departamentos WHERE IDDepartamento= @id";
            command.Connection = sqlConnection;
            oDepartamento = new clsDepartamento();
            reader = command.ExecuteReader();

            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        oDepartamento.Id = (int)reader["IDDepartamento"];
                        oDepartamento.Nombre = (string)reader["nombreDepartamento"];
                    }
                }
                reader.Close();
                sqlConnection.Close();
            }
            catch (Exception e) { }

            return oDepartamento;
        }
    }
}
