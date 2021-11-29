using BL;
using CRUD_Personas_BL.Listados;
using CRUD_Personas_Entities;
using System.Collections.ObjectModel;

namespace CRUD_Personas_ASP.Models.ViewModels
{
    public class VM_CreatePersonaListaDepartamentos
    {
        private clsPersona persona;
        private ObservableCollection<clsDepartamento> departamentos;

        public VM_CreatePersonaListaDepartamentos()
        {
            persona = new clsPersona();
            departamentos = new clsListadoDepartamentosBL().Departamentos;
        }

        public VM_CreatePersonaListaDepartamentos(int id)
        {
            persona = clsListadoPersonasBL(id);
            departamentos = new clsListadoDepartamentosBL().Departamentos;
        }

        public clsPersona Persona
        {
            get { return persona; }
            set { persona = value; }
        }

        public ObservableCollection<clsDepartamento> Departamentos
        {
            get { return departamentos; }
            set { departamentos = value; }
        }
    }
}
