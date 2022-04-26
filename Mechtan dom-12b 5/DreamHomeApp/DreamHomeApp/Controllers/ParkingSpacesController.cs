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
    public class ParkingSpacesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParkingSpacesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ParkingSpaces
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ParkingSpaces.Include(p => p.House).Include(p => p.Status);
            return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> All(int houseId)
        {
            var applicationDbContext = _context.ParkingSpaces.Where(x=>x.HouseId==houseId).Include(p => p.House).Include(p => p.Status);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ParkingSpaces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkingSpace = await _context.ParkingSpaces
                .Include(p => p.House)
                .Include(p => p.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkingSpace == null)
            {
                return NotFound();
            }

            return View(parkingSpace);
        }

        // GET: ParkingSpaces/Create
        public IActionResult Create()
        {
            ViewData["HouseId"] = new SelectList(_context.Houses, "Id", "Name");
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "StatusName");
            return View();
        }

        // POST: ParkingSpaces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Number,Area,HouseId,StatusId")] ParkingSpace parkingSpace)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parkingSpace);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HouseId"] = new SelectList(_context.Houses, "Id", "Name", parkingSpace.HouseId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "StatusName", parkingSpace.StatusId);
            return View(parkingSpace);
        }

        // GET: ParkingSpaces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkingSpace = await _context.ParkingSpaces.FindAsync(id);
            if (parkingSpace == null)
            {
                return NotFound();
            }
            ViewData["HouseId"] = new SelectList(_context.Houses, "Id", "Name", parkingSpace.HouseId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "StatusName", parkingSpace.StatusId);
            return View(parkingSpace);
        }

        // POST: ParkingSpaces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Number,Area,HouseId,StatusId")] ParkingSpace parkingSpace)
        {
            if (id != parkingSpace.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parkingSpace);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkingSpaceExists(parkingSpace.Id))
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
            ViewData["HouseId"] = new SelectList(_context.Houses, "Id", "Name", parkingSpace.HouseId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "StatusName", parkingSpace.StatusId);
            return View(parkingSpace);
        }

        // GET: ParkingSpaces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkingSpace = await _context.ParkingSpaces
                .Include(p => p.House)
                .Include(p => p.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkingSpace == null)
            {
                return NotFound();
            }

            return View(parkingSpace);
        }

        // POST: ParkingSpaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parkingSpace = await _context.ParkingSpaces.FindAsync(id);
            _context.ParkingSpaces.Remove(parkingSpace);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParkingSpaceExists(int id)
        {
            return _context.ParkingSpaces.Any(e => e.Id == id);
        }
    }
}
