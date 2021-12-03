using BL;
using CRUD_Personas_BL.Listados;
using CRUD_Personas_Entities;
using System.ComponentModel;

namespace CRUD_Personas_ASP.Models
{
    /// <summary>
    /// Esta clase es un modelo que crea un nuevo objeto a raíz de una persona y un departamento extraídos de la capa BL.
    ///
    /// PROPIEDADES
    ///   _nombreDepartamento: cadena. Consultable/modificable. 
    ///   _persona: clsPersona. Consultable/modificable.
    /// </summary>

    public class clsPersonaNombreDepartamento
    {
        #region atributos
        private string nombreDepartamento;
        private clsPersona persona;
        #endregion

        #region getters y setters

        [DisplayName("Departamento")]
        public string NombreDepartamento { get { return nombreDepartamento; } set { nombreDepartamento = value; } }
        public clsPersona Persona { get { return persona; } set { persona = value; } }
        #endregion

        #region constructor
        public clsPersonaNombreDepartamento(int id) 
        {
            persona = new clsListadoPersonasBL(id).Persona;
            nombreDepartamento = new clsListadoDepartamentosBL(persona.IdDepartamento).Departamento.Nombre;
        }
        #endregion
    }
}
