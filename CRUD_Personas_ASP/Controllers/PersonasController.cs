using BL;
using CRUD_Personas_ASP.Models.ViewModels;
using CRUD_Personas_BL.Gestoras;
using CRUD_Personas_Entities;
using Ejercicio2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Personas_ASP.Controllers
{
    public class PersonasController : Controller
    {
        // GET: PersonasController
        public ActionResult Index()
        {
            try
            {
                return View(new VM_ListadoPersonas().GetListadoClsPersonas());
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: PersonasController/Details/5
        public ActionResult Details(int idPersona)
        {
            return View(new VM_PersonaNombreDepartamento(idPersona));
        }

        // GET: PersonasController/Create
        public ActionResult Create()
        {
            return View(new VM_PersonaListaDepartamentos());
        }

        // POST: PersonasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(clsPersona persona)
        {
            try
            {
                GestoraAccionesPersonasBL.addPersonaBL(persona);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: PersonasController/Edit/5
        public ActionResult Edit(int idPersona)
        {
            return View(new VM_PersonaListaDepartamentos(idPersona));
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
            return View(new VM_PersonaNombreDepartamento(idPersona));
        }

        // POST: PersonasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult BtnDelete(int idPersona)
        {
            try
            {
                GestoraAccionesPersonasBL.deletePersonaBL(idPersona);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
