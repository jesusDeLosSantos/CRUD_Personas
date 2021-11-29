using System;
using System.Text;

namespace CRUD_Personas_Entities
{
    public class clsPersona
    {
        #region atributos privados
        private int id;
        private String nombre;
        private String apellidos;
        private DateTime fechaNacimiento;
        //Para fotos
        private string foto;
        //private byte[] foto;
        private String direccion;
        private String telefono;
        private int idDepartamento;
        #endregion
        #region propiedades publicas
        //public String Nombre(get; set;) estos son propiedades autoimplementadas, si ponemos esto, borramos el private String nombre de arriba
        public int Id {
            get { return id; }
            set { id = value; }
        }
        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }
        public String Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }
        public String Nombre
        {
            get => nombre;
            /*
             return nombre;
             */
            set => nombre = value;
            /* Otra manera:
            set
            {
                nombre = value;
            }
             */
        }

        public String Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public String Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public int IdDepartamento
        {
            get { return idDepartamento; }
            set { idDepartamento = value; }
        }


        public String Foto
        {
            get { return foto; }
            set { foto = value; }
        }
        #endregion



        #region constructores
        // constructor con parametors
        public clsPersona(String nombre)
        {
            Nombre = nombre; // se podria poner this.Nombre , pero no es necesario
        }

        public clsPersona()
        {

        }
        public clsPersona(String nombre, String apellidos)
        {
            Apellidos = apellidos;
            Nombre = nombre;
        }

        public clsPersona(int id, String nombre, String apellidos)
        {
            this.id= id;
            this.apellidos = apellidos;
            this.nombre = nombre;
            this.fechaNacimiento = DateTime.Now;
            this.telefono = "1";
        }

        public clsPersona(String nombre, String apellidos, DateTime fechaNacimiento, String foto, String direccion, String telefono, int idDepartamento) 
        {
            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.FechaNacimiento = fechaNacimiento;
            this.Foto = foto;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.idDepartamento = idDepartamento;
        }



        #endregion
        #region metodos
        public override string ToString()
        {
            StringBuilder strBld = new StringBuilder(nombre);
            strBld.Append(" ").Append(apellidos).Append(" ").Append(fechaNacimiento).Append(" ")
                .Append(direccion).Append(" ").Append(telefono);
            return strBld.ToString();
        }
        #endregion
    }
}
