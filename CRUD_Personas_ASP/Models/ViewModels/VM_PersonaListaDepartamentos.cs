using BL;
using CRUD_Personas_BL.Listados;
using CRUD_Personas_Entities;
using System.Collections.ObjectModel;

namespace CRUD_Personas_ASP.Models.ViewModels
{
    // Esta clase es un ViewModel que suministra una persona con la lista de todos los departamentos extraídos de la capa BL.
    //
    // PROPIEDADES
    //   _persona: clsPersona. Consultable/modificable.
    //   _departamentos: ObservableCollection<clsDepartamento>. Consultable/Modificable.
    public class VM_PersonaListaDepartamentos
    {
        #region atributos
        private clsPersona persona;
        private ObservableCollection<clsDepartamento> departamentos;
        #endregion

        #region getters y setters
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
        #endregion

        #region constructores
        public VM_PersonaListaDepartamentos()
        {
            persona = new clsPersona();
            departamentos = new clsListadoDepartamentosBL().Departamentos;
        }
        public VM_PersonaListaDepartamentos(int id)
        {
            persona = new clsListadoPersonasBL(id).Persona;
            departamentos = new clsListadoDepartamentosBL().Departamentos;
        }
        #endregion


    }
}
