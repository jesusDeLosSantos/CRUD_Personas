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
