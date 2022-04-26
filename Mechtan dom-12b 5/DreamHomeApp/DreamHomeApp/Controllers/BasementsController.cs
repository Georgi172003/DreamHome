using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DreamHomeApp.Data;
using DreamHomeApp.Entites;

namespace DreamHomeApp.Controllers
{
    public class BasementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BasementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Basements
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Basements.Include(b => b.House).Include(b => b.Status);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Basements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basement = await _context.Basements
                .Include(b => b.House)
                .Include(b => b.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (basement == null)
            {
                return NotFound();
            }

            return View(basement);
        }

        // GET: Basements/Create
        public IActionResult Create()
        {
            ViewData["HouseId"] = new SelectList(_context.Houses, "Id", "Name");
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "StatusName");
            return View();
        }

        // POST: Basements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Number,Area,HouseId,StatusId")] Basement basement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(basement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HouseId"] = new SelectList(_context.Houses, "Id", "Name", basement.HouseId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "StatusName", basement.StatusId);
            return View(basement);
        }

        // GET: Basements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basement = await _context.Basements.FindAsync(id);
            if (basement == null)
            {
                return NotFound();
            }
            ViewData["HouseId"] = new SelectList(_context.Houses, "Id", "Name", basement.HouseId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "StatusName", basement.StatusId);
            return View(basement);
        }

        // POST: Basements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Number,Area,HouseId,StatusId")] Basement basement)
        {
            if (id != basement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(basement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BasementExists(basement.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["HouseId"] = new SelectList(_context.Houses, "Id", "Name", basement.HouseId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "StatusName", basement.StatusId);
            return View(basement);
        }

        // GET: Basements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basement = await _context.Basements
                .Include(b => b.House)
                .Include(b => b.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (basement == null)
            {
                return NotFound();
            }

            return View(basement);
        }

        // POST: Basements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var basement = await _context.Basements.FindAsync(id);
            _context.Basements.Remove(basement);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BasementExists(int id)
        {
            return _context.Basements.Any(e => e.Id == id);
        }
    }
}
