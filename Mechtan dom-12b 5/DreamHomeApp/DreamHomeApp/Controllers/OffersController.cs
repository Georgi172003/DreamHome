using DreamHomeApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamHomeApp.Controllers
{
    public class OffersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OffersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OffersController
        public ActionResult Index()
        {
            return View(_context.Houses.ToList());
        }

        // GET: OffersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OffersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OffersController/Create
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

        // GET: OffersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OffersController/Edit/5
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

        // GET: OffersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OffersController/Delete/5
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
