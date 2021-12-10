using BL;
using CRUD_Personas_BL.Listados;
using CRUD_Personas_Entities;
using CRUD_Personas_UWP.ViewModels.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Personas_UWP.Models
{

    /// <summary>
    /// Esta clase es un modelo que crea un nuevo objeto a raíz de una persona y un departamento extraídos de la capa BL.
    ///
    /// PROPIEDADES
    ///   _nombreDepartamento: cadena. Consultable/modificable. 
    ///   _persona: clsPersona. Consultable/modificable.
    /// </summary>
    public class PersonaNombreDepartamento : clsVMBase
    {
        #region atributos
        private string nombreDepartamento;
        private clsPersona persona;
        #endregion

        #region getters y setters
        public string NombreDepartamento { get { return nombreDepartamento; } set { nombreDepartamento = value; } }
        public clsPersona Persona { 
            get { return persona; } 
            set { persona = value; } 
        }
        #endregion

        #region constructores
        public PersonaNombreDepartamento(int id)
        {
            persona = new clsListadoPersonasBL(id).Persona;
            nombreDepartamento = new clsListadoDepartamentosBL(persona.IdDepartamento).Departamento.Nombre;
        }

        public PersonaNombreDepartamento(clsPersona persona)
        {
            this.persona = persona;
            nombreDepartamento = new clsListadoDepartamentosBL(persona.IdDepartamento).Departamento.Nombre;
        }

        public PersonaNombreDepartamento()
        {

        }
        #endregion
    }
}
