using System;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using CRUD_Personas_Entities;
using DAL;



namespace DAL
{

    public class clsListadoPersonasDAL
    {
        private clsMyConnection myConnection;
        private SqlConnection sqlConnection;
        private ObservableCollection<clsPersona> listaPersonas;

        public clsListadoPersonasDAL()
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
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        oPersona = new clsPersona();
                        if (reader["IDPersona"] != System.DBNull.Value)
                        {
                            oPersona.Id = (int)reader["IDPersona"];
                        }
                        else { oPersona.Id = 0; }

                        if (reader["nombrePersona"] != System.DBNull.Value)
                        {
                            oPersona.Nombre = (string)reader["nombrePersona"];
                        }
                        else { oPersona.Nombre = null; }

                        if (reader["apellidosPersona"] != System.DBNull.Value)
                        {
                            oPersona.Apellidos = (string)reader["apellidosPersona"];
                        }
                        else { oPersona.Apellidos = null; }

                        if (reader["direccion"] != System.DBNull.Value)
                        {
                            oPersona.Direccion = (string)reader["direccion"];
                        }
                        else { oPersona.Direccion = null; }

                        if (reader["telefono"] != System.DBNull.Value)
                        {
                            oPersona.Telefono = (string)reader["telefono"];
                        }
                        else { oPersona.Telefono = null; }

                        if (reader["fechaNacimiento"] != System.DBNull.Value)
                        {
                            oPersona.FechaNacimiento = (DateTime)reader["fechaNacimiento"];
                        }
                        else { oPersona.FechaNacimiento = DateTime.MinValue; }

                        listaPersonas.Add(oPersona);
                    }
                }
                reader.Close();
                sqlConnection.Close();
            }
            catch (Exception e) { }

            return listaPersonas;
        }


        public clsPersona getUsuario(int id)
        {
            clsPersona oPersona;
            SqlCommand command = new SqlCommand();
            sqlConnection = myConnection.getConnection();
            SqlDataReader reader;
            command.Parameters.Add(new SqlParameter("@id", id));
            command.CommandText = "SELECT * FROM Personas WHERE IDPersona= @id";
            command.Connection = sqlConnection;
            oPersona = new clsPersona();
            reader = command.ExecuteReader();

            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {                    
                        oPersona.Id = (int)reader["IDPersona"];
                        oPersona.Nombre = (string)reader["nombrePersona"];
                        oPersona.Apellidos = (string)reader["apellidosPersona"];
                        oPersona.Direccion = (string)reader["direccion"];
                        oPersona.Telefono = (string)reader["telefono"];
                        if (reader["fechaNacimiento"] != System.DBNull.Value)
                        {
                            oPersona.FechaNacimiento = (DateTime)reader["fechaNacimiento"];
                        }
                       
                    }
                }
                reader.Close();
                sqlConnection.Close();
            }
            catch (Exception e) { }

            return oPersona;
        }
    }
}
