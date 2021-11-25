using CRUD_Personas_Entities;
using System.Collections.ObjectModel;

namespace CRUD_Personas_ASP.Models
{
    public class clsPersonaListaDepartamentos : clsPersona
    {
        private ObservableCollection<clsDepartamento> listaDepartamentos;

        public ObservableCollection<clsDepartamento> ListaDepartamentos
        {
            get { return listaDepartamentos; }
            set { listaDepartamentos = value; }
        }

        public clsPersonaListaDepartamentos(ObservableCollection<clsDepartamento> departamentos)
        {
            listaDepartamentos= departamentos;
        }
    }
}
