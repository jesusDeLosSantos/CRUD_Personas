using Entities;
using System;
using System.Collections.Generic;
using DAL;
using System.Collections.ObjectModel;

namespace BL
{
    public class clsListadoPersonasBL
    {
        public ObservableCollection <clsPersona> Personas { get; set; }

        public clsListadoPersonasBL()
        {
            Personas = new ClaseListadoPersonasDAL().getUsuariosCompletos();
        }
    }
}
