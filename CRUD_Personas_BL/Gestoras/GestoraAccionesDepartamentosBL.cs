using CRUD_Personas_DAL.Gestoras;
using CRUD_Personas_Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Personas_BL.Gestoras
{
    public class GestoraAccionesDepartamentosBL
    {
        public static int addDepartamentosBL(clsDepartamento departamento)
        {
            return GestoraAccionesDepartamentosDAL.addDepartamentoDAL(departamento);
        }

        public static int alterDepartamentosBL(clsDepartamento departamento)
        {
            return GestoraAccionesDepartamentosDAL.alterDepartamentoDAL(departamento);
        }

        public static int deleteDepartamentosBL(int id)
        {
            return GestoraAccionesDepartamentosDAL.deleteDepartamentoDAL(id);
        }
    }
}
