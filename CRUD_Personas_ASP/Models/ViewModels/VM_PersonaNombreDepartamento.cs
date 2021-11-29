namespace CRUD_Personas_ASP.Models.ViewModels
{
    // Esta clase es un ViewModel que suministra una persona del Model clsPersonaNombreDepartamento.
    //
    // PROPIEDADES
    //   _persona: clsPersonaNombreDepartamento. Consultable/modificable.

    public class VM_PersonaNombreDepartamento
    {
        #region atributos
        private clsPersonaNombreDepartamento persona;
        #endregion

        #region getters y setters
        public clsPersonaNombreDepartamento Persona
        {
            get { return persona; } 
            set { persona = value; }
        }
        #endregion

        #region constructores
        public VM_PersonaNombreDepartamento(int id)
        {
            persona = new clsPersonaNombreDepartamento(id);
        }
        #endregion
    }
}
