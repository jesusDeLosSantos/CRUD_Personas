using CRUD_Personas_DAL.Listados;
using CRUD_Personas_Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CRUD_Personas_BL.Listados
{
    public class clsListadoDepartamentosBL
    {
        public ObservableCollection<clsDepartamento> Departamentos { get; set; }

        public clsListadoDepartamentosBL()
        {
            Departamentos = new ClaseListadoDepartamentosDAL().getDepartamentosCompletos();
        }
    }
}
