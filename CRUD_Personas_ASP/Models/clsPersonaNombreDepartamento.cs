using CRUD_Personas_Entities;

namespace CRUD_Personas_ASP.Models
{
    public class clsPersonaNombreDepartamento : clsPersona
    {
        private string nombreDepartamento;

        public string NombreDepartamento { get { return nombreDepartamento; } set { nombreDepartamento = value;} }
    }
}
