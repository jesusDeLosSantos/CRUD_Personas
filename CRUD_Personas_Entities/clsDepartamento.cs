using System;

namespace CRUD_Personas_Entities
{
    public class clsDepartamento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public clsDepartamento() 
        {
            Id = 3;
            Nombre = "godd";
        }

        public clsDepartamento(string s)
        {
            Nombre = s;
        }
    }
}
