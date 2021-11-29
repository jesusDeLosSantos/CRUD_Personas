using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using BL;
using CRUD_Personas_Entities;


namespace Ejercicio2.Models
{
    public class VM_ListadoPersona
    {

        private clsListadoPersonasBL listaBL;

        public VM_ListadoPersona()
        {
            listaBL = new clsListadoPersonasBL();
        }

        public ObservableCollection<clsPersona> GetListadoClsPersonas() {
            return listaBL.Personas;
        }
    }
}
