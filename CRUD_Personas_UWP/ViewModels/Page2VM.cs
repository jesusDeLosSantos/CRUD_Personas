using BL;
using CRUD_Personas_Entities;
using CRUD_Personas_UWP.ViewModels.utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Personas_UWP.ViewModels
{
    public class Page2VM : clsVMBase
    {
        #region atributos
        private ObservableCollection<clsPersona> lista;
        public ObservableCollection<clsPersona> ListaFiltrada { get; set; }
        private clsPersona persona;
        #endregion

        #region constructor
        public Page2VM()
        {
            lista = new clsListadoPersonasBL().Personas;
            ListaFiltrada = lista;

        }
        #endregion
    }
}
