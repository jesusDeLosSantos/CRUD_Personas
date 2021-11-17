using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using DAL;
using Entities;



namespace DAL
{

    public class ClaseListadoPersonaDAL
    {
        private clsMyConnection myConnection;
        private SqlConnection sqlConnection;
        private ObservableCollection<clsPersona> listaPersonas;

        public ClaseListadoPersonaDAL()
        {
            myConnection = new clsMyConnection();
            listaPersonas = new ObservableCollection<clsPersona>();
        }

        public ObservableCollection<clsPersona> getUsuariosCompletos()
        {
            clsPersona oPersona;
            SqlCommand command = new SqlCommand();
            sqlConnection = myConnection.getConnection();
            SqlDataReader reader;
            command.CommandText = "SELECT * FROM Personas";
            command.Connection = sqlConnection;
            reader = command.ExecuteReader();

            try 
            {
                if (reader.Read())
                {
                    while (reader.Read())
                    {
                        oPersona = new clsPersona();
                        oPersona.Id = (int)reader["IDPersona"];
                        oPersona.Nombre = (string)reader["nombrePersona"];
                        oPersona.Apellidos = (string)reader["apellidosPersona"];
                        oPersona.Direccion = (string)reader["direccion"];
                        oPersona.Telefono = (string)reader["telefono"];
                        if (reader["fechaNacimiento"] != System.DBNull.Value)
                        {
                            oPersona.FechaNacimiento = (DateTime)reader["fechaNacimiento"];
                        }
                        listaPersonas.Add(oPersona);
                    }
                }
                reader.Close();
                sqlConnection.Close();
            }
            catch (Exception e) { }

            return listaPersonas;
        }
    }
}
