using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcPracownik.Data;
using Skoki.Models;

namespace skoki.Controllers
{
    public class ZawodnikController : Controller
    {
        private readonly MvcPracownikContext _context;

        public ZawodnikController(MvcPracownikContext context)
        {
            _context = context;
        }

        // GET: Zawodnik
        public async Task<IActionResult> Index()
        {
              return _context.Zawodnik != null ? 
                          View(await _context.Zawodnik.ToListAsync()) :
                          Problem("Entity set 'MvcPracownikContext.Zawodnik'  is null.");
        }

        // GET: Zawodnik/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Zawodnik == null)
            {
                return NotFound();
            }

            var zawodnik = await _context.Zawodnik
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zawodnik == null)
            {
                return NotFound();
            }

            return View(zawodnik);
        }

        // GET: Zawodnik/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zawodnik/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Imie,Nazwisko,Kraj")] Zawodnik zawodnik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zawodnik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zawodnik);
        }

        // GET: Zawodnik/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Zawodnik == null)
            {
                return NotFound();
            }

            var zawodnik = await _context.Zawodnik.FindAsync(id);
            if (zawodnik == null)
            {
                return NotFound();
            }
            return View(zawodnik);
        }

        // POST: Zawodnik/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Imie,Nazwisko,Kraj")] Zawodnik zawodnik)
        {
            if (id != zawodnik.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zawodnik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZawodnikExists(zawodnik.Id))
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
            return View(zawodnik);
        }

        // GET: Zawodnik/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Zawodnik == null)
            {
                return NotFound();
            }

            var zawodnik = await _context.Zawodnik
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zawodnik == null)
            {
                return NotFound();
            }

            return View(zawodnik);
        }

        // POST: Zawodnik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Zawodnik == null)
            {
                return Problem("Entity set 'MvcPracownikContext.Zawodnik'  is null.");
            }
            var zawodnik = await _context.Zawodnik.FindAsync(id);
            if (zawodnik != null)
            {
                _context.Zawodnik.Remove(zawodnik);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZawodnikExists(int id)
        {
          return (_context.Zawodnik?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
