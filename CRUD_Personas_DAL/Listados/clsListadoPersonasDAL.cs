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

        /// <summary>
        /// Este metodo extrae todos los usuarios de la bbdd
        /// </summary>
        /// <returns>Devuelve una lista con todos los usuarios</returns>
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

                        if (reader["IDDepartamento"] != System.DBNull.Value)
                        {
                            oPersona.IdDepartamento = (int)reader["IDDepartamento"];
                        }
                        else { oPersona.IdDepartamento = 0; }

                        if (reader["Foto"] != System.DBNull.Value)
                        {
                            oPersona.Foto = (String)reader["Foto"];
                        }                                               //En vez de una foto de un icono, esta es la imagen por defecto
                        else { oPersona.Foto = "https://zeleb.publico.es/sites/default/files/styles/news_main_image/public/captura_de_pantalla_2016-08-17_a_las_14.15.02.png"; }

                        listaPersonas.Add(oPersona);
                    }
                }
                reader.Close();
                sqlConnection.Close();
            }
            catch (Exception e) {
                throw e;
            }

            return listaPersonas;
        }

        /// <summary>
        /// Este metodo extrae la persona que coincida con el id introducido
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve la persona que coincide con el id</returns>
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

                        if (reader["IDDepartamento"] != System.DBNull.Value)
                        {
                            oPersona.IdDepartamento = (int)reader["IDDepartamento"];
                        }
                        else { oPersona.IdDepartamento = 0; }

                        if (reader["Foto"] != System.DBNull.Value)
                        {
                            oPersona.Foto = (String)reader["Foto"];
                        }
                        else { oPersona.Foto = "https://zeleb.publico.es/sites/default/files/styles/news_main_image/public/captura_de_pantalla_2016-08-17_a_las_14.15.02.png"; }

                    }
                }
                reader.Close();
                sqlConnection.Close();
            }
            catch (Exception e) {
                throw e;
            }

            return oPersona;
        }
    }
}
