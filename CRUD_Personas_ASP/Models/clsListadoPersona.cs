using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace Ejercicio2.Models
{
    public class clsListadoPersona
    {

        private ClaseListadoPersonaDAL listaDAL;

        public clsListadoPersona()
        {
            listaDAL = new ClaseListadoPersonaDAL();
        }

        public ObservableCollection<clsPersona> GetListadoClsPersonas() {
            return listaDAL.getUsuariosCompletos();
        }
    }
}
