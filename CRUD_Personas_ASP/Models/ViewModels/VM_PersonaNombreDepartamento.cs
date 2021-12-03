namespace CRUD_Personas_ASP.Models.ViewModels
{
    /// <summary>
    /// Esta clase es un ViewModel que suministra una persona del Model clsPersonaNombreDepartamento.
    ///
    /// PROPIEDADES
    ///   _persona: clsPersonaNombreDepartamento. Consultable/modificable.
    /// </summary>

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
        public VM_PersonaNombreDepartamento(int idPersona)
        {
            persona = new clsPersonaNombreDepartamento(idPersona);
        }
        #endregion
    }
}
