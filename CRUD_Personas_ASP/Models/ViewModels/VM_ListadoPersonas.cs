using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using BL;
using CRUD_Personas_Entities;


namespace Ejercicio2.Models.ViewModels
{
    /// <summary>
    /// Esta clase es un ViewModel que suministra un listado de personas de la capa BL.
    ///
    /// PROPIEDADES
    ///   _listaBL: clsListadoPersonasBL. Consultable.
    /// </summary>


    public class VM_ListadoPersonas
    {
        #region atributos
        private clsListadoPersonasBL listaBL;
        #endregion

        #region constructores
        public VM_ListadoPersonas()
        {
            listaBL = new clsListadoPersonasBL();
        }
        #endregion

        #region metodos
        public ObservableCollection<clsPersona> GetListadoClsPersonas() {
            return listaBL.Personas;
        }
        #endregion
    }
}
