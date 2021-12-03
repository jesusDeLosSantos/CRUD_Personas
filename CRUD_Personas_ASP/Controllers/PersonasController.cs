using BL;
using CRUD_Personas_ASP.Models.ViewModels;
using CRUD_Personas_BL.Gestoras;
using CRUD_Personas_Entities;
using Ejercicio2.Models;
using Ejercicio2.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Personas_ASP.Controllers
{
    public class PersonasController : Controller
    {
        // GET: PersonasController
        public ActionResult Index()
        {
            ActionResult result = View();
            try
            {
                result = View(new VM_ListadoPersonas().GetListadoClsPersonas());
            }
            catch
            {
                result = View("Error");
            }
            return result;
        }

        // GET: PersonasController/Details/5
        public ActionResult Details(int idPersona)
        {
            ActionResult result = View();
            try
            {
                result = View(new VM_PersonaNombreDepartamento(idPersona));
            }
            catch
            {
                result = View("Error");
            }
            return result;
        }

        // GET: PersonasController/Create
        public ActionResult Create()
        {
            ActionResult result = View();
            try
            {
                result = View(new VM_PersonaListaDepartamentos());
            }
            catch
            {
                result = View("Error");
            }
            return result;
        }

        // POST: PersonasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(clsPersona persona)
        {
            ActionResult result = View();
            try
            {
                GestoraAccionesPersonasBL.addPersonaBL(persona);
                result = RedirectToAction(nameof(Index));
            }
            catch
            {
                result = View("Error");
            }
            return result;
        }

        // GET: PersonasController/Edit/5
        public ActionResult Edit(int idPersona)
        {
            ActionResult result = View();
            try
            {
                result= View(new VM_PersonaListaDepartamentos(idPersona));
            }
            catch
            {
                result= View("Error");
            }

            return result;            
        }

        // POST: PersonasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(clsPersona persona)
        {
            ActionResult result= View();
            try
            {
                GestoraAccionesPersonasBL.alterPersonaBL(persona);
                result= RedirectToAction(nameof(Index));
            }
            catch
            {
                result= View("Error");
            }
            return result;
        }

        // GET: PersonasController/Delete/5
        public ActionResult Delete(int idPersona)
        {
            ActionResult result = View();
            try
            {
                result = View(new VM_PersonaNombreDepartamento(idPersona));
            }
            catch
            {
                result = View("Error");
            }
            return result;
        }

        // POST: PersonasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult BtnDelete(int idPersona)
        {
            ActionResult result = View();
            try
            {
                GestoraAccionesPersonasBL.deletePersonaBL(idPersona);
                result = RedirectToAction(nameof(Index));
            }
            catch
            {
                result = View("Error");
            }
            return result;
        }
    }
}
