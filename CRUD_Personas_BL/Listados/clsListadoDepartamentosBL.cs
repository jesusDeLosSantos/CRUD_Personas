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
        public clsDepartamento Departamento { get; set; }

        public clsListadoDepartamentosBL(int id)
        {
            Departamentos = new clsListadoDepartamentosDAL().getDepartamentosCompletos();
            Departamento = new clsListadoDepartamentosDAL().getDepartamento(id);
        }

        public clsListadoDepartamentosBL()
        {
            Departamentos = new clsListadoDepartamentosDAL().getDepartamentosCompletos();
        }
    }
}
