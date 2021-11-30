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
            return View(new VM_ListadoPersonas().GetListadoClsPersonas());
        }

        // GET: PersonasController/Details/5
        public ActionResult Details(int id)
        {
            return View(new VM_PersonaNombreDepartamento(id));
        }

        // GET: PersonasController/Create
        public ActionResult Create()
        {
            return View(new VM_PersonaListaDepartamentos());
        }

        // POST: PersonasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(new VM_PersonaListaDepartamentos(id));
        }

        // POST: PersonasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(clsPersona persona)
        {
            try
            {
                GestoraAccionesPersonasBL.alterPersonaBL(persona);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(new VM_PersonaNombreDepartamento(id));
        }

        // POST: PersonasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
