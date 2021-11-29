﻿using CRUD_Personas_ASP.Models;
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
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new VM_ListadoPersona().GetListadoClsPersonas());
        }

        public IActionResult Create()
        {
            return View(new VM_CreatePersonaListaDepartamentos());
        }

        public IActionResult Delete()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            return View(new VM_CreatePersonaListaDepartamentos(id));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
