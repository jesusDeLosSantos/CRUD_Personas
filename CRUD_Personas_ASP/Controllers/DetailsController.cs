using Microsoft.AspNetCore.Mvc;

namespace CRUD_Personas_ASP.Controllers
{
    public class DetailsController : Controller
    {
        public IActionResult Details()
        {
            return View();
        }
    }
}
