using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using proyy;

namespace PruebasClase.Controllers
{
    public class PersonaController : Controller
    {
        public IActionResult Index()
        {
            LoadPersonas();
            return View(Sistema.Instance.Personas);
        }
        [HttpPost]
        public void EliminarPersona(int id)
        {
            foreach (Persona p in Sistema.Instance.Personas)
            {
                if (p.Id == id) Sistema.Instance.Personas.Remove(p);
            }
        }

        public IActionResult EliminarPersona()
        {
            return RedirectToAction("Index");
        }

        public void LoadPersonas()
        {
            Sistema aux = Sistema.Instance;
            aux.Personas.Add(new Persona("Fabricio Barrios", 27));
            aux.Personas.Add(new Persona("Federico Barrios", 27));
        }
    }
}
