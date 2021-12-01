using CRUD_Personas_DAL.Gestoras;
using CRUD_Personas_Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD_Personas_BL.Gestoras
{
    public class GestoraAccionesPersonasBL
    {
        public static int addPersonaBL(clsPersona persona)
        {
            return GestoraAccionesPersonasDAL.addPersonaDAL(persona);
        }

        public static int alterPersonaBL(clsPersona persona)
        {
            return GestoraAccionesPersonasDAL.alterPersonaDAL(persona);
        }

        public static int deletePersonaBL(int id)
        {
            return GestoraAccionesPersonasDAL.deletePersonaDAL(id);
        }
    }
}
