using Microsoft.AspNetCore.Mvc;

namespace CRUD_Personas_ASP.Controllers
{
    public class CreateController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
    }
}
