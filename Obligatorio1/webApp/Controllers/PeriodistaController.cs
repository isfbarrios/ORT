using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webApp.Controllers
{
    public class PeriodistaController : Controller
    {
        // GET: PeriodistaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PeriodistaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PeriodistaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PeriodistaController/Create
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

        // GET: PeriodistaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PeriodistaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: PeriodistaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PeriodistaController/Delete/5
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
