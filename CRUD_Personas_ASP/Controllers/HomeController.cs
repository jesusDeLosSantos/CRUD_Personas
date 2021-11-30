using CRUD_Personas_ASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BL;
using CRUD_Personas_Entities;
using CRUD_Personas_BL.Listados;
using Ejercicio2.Models;
using CRUD_Personas_ASP.Models.ViewModels;

namespace CRUD_Personas_ASP.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        
    }
}
