using System;
using System.Collections.Generic;
using DAL;
using System.Collections.ObjectModel;
using CRUD_Personas_Entities;

namespace BL
{
    public class clsListadoPersonasBL
    {
        public ObservableCollection <clsPersona> Personas { get; set; }
        public clsPersona Persona { get; set; }

        public clsListadoPersonasBL(int id)
        {
            Personas = new ClaseListadoPersonasDAL().getUsuariosCompletos();
            Persona = new ClaseListadoPersonasDAL().getUsuario(id);
        }

        public clsListadoPersonasBL()
        {
            Personas = new ClaseListadoPersonasDAL().getUsuariosCompletos();
        }
    }
}
