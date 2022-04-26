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
    public class ApartamentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApartamentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Apartaments
        public IActionResult Index()
        {
            var applicationDbContext = _context.Apartaments.Include(a => a.House).Include(a => a.Status).ToList();
            return View(applicationDbContext);
        }
        public async Task<IActionResult> All(int houseId)
        {
            var applicationDbContext = _context.Apartaments.Where(x=>x.HouseId==houseId).Include(a => a.House).Include(a => a.Status);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Apartaments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartament = await _context.Apartaments
                .Include(a => a.House)
                .Include(a => a.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (apartament == null)
            {
                return NotFound();
            }

            return View(apartament);
        }

        // GET: Apartaments/Create
        public IActionResult Create()
        {
            ViewData["HouseId"] = new SelectList(_context.Houses, "Id", "Name");
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "StatusName");
            return View();
        }

        // POST: Apartaments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Number,Area,Description,StatusId,HouseId,Image,Level,CountRooms,CountBath,Closet,Wardrobe")] Apartament apartament)
        {
            if (ModelState.IsValid)
            {
                _context.Add(apartament);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HouseId"] = new SelectList(_context.Houses, "Id", "Name", apartament.HouseId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "StatusName", apartament.StatusId);
            return View(apartament);
        }

        // GET: Apartaments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartament = await _context.Apartaments.FindAsync(id);
            if (apartament == null)
            {
                return NotFound();
            }
            ViewData["HouseId"] = new SelectList(_context.Houses, "Id", "Name", apartament.HouseId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "StatusName", apartament.StatusId);
            return View(apartament);
        }

        // POST: Apartaments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Number,Area,Description,StatusId,HouseId,Image,Level,CountRooms,CountBath,Closet,Wardrobe")] Apartament apartament)
        {
            if (id != apartament.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apartament);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApartamentExists(apartament.Id))
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
            ViewData["HouseId"] = new SelectList(_context.Houses, "Id", "Name", apartament.HouseId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "StatusName", apartament.StatusId);
            return View(apartament);
        }

        // GET: Apartaments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apartament = await _context.Apartaments
                .Include(a => a.House)
                .Include(a => a.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (apartament == null)
            {
                return NotFound();
            }

            return View(apartament);
        }

        // POST: Apartaments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apartament = await _context.Apartaments.FindAsync(id);
            _context.Apartaments.Remove(apartament);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApartamentExists(int id)
        {
            return _context.Apartaments.Any(e => e.Id == id);
        }
    }
}
