﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;

namespace webApp.Controllers
{
    public class PartidoController : Controller
    {
        Administradora manager = Administradora.Instance;

        [HttpGet]
        public IActionResult Index()
        {
            return View(manager.Partidos);
        }
        [HttpGet]
        public IActionResult AltaJugador()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AltaJugador(Partido p)
        {
            if (p.Validar()) manager.Partidos.Add(p);
            return RedirectToAction("Index");
        }
    }
}
