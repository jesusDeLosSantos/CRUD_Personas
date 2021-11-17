using Entities;
using System;
using System.Collections.Generic;
using DAL;
using System.Collections.ObjectModel;

namespace BL
{
    public class clsListadoPersonas_BL
    {
        public ObservableCollection <clsPersona> Personas { get; set; }

        public clsListadoPersonas_BL()
        {
            Personas = new clsListadoPersonas().listado;
        }
    }
}
