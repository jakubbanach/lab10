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
    public class WynikController : Controller
    {
        private readonly MvcPracownikContext _context;

        public WynikController(MvcPracownikContext context)
        {
            _context = context;
        }

        // GET: Wynik
        public async Task<IActionResult> Index()
        {
              return _context.Wynik != null ? 
                          View(await _context.Wynik.ToListAsync()) :
                          Problem("Entity set 'MvcPracownikContext.Wynik'  is null.");
        }

        // GET: Wynik/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Wynik == null)
            {
                return NotFound();
            }

            var wynik = await _context.Wynik
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wynik == null)
            {
                return NotFound();
            }

            return View(wynik);
        }

        // GET: Wynik/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Wynik/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Miejsce,Seria1,Seria2,Nota,PunktySezonowe")] Wynik wynik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wynik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wynik);
        }

        // GET: Wynik/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Wynik == null)
            {
                return NotFound();
            }

            var wynik = await _context.Wynik.FindAsync(id);
            if (wynik == null)
            {
                return NotFound();
            }
            return View(wynik);
        }

        // POST: Wynik/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Miejsce,Seria1,Seria2,Nota,PunktySezonowe")] Wynik wynik)
        {
            if (id != wynik.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wynik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WynikExists(wynik.Id))
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
            return View(wynik);
        }

        // GET: Wynik/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Wynik == null)
            {
                return NotFound();
            }

            var wynik = await _context.Wynik
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wynik == null)
            {
                return NotFound();
            }

            return View(wynik);
        }

        // POST: Wynik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Wynik == null)
            {
                return Problem("Entity set 'MvcPracownikContext.Wynik'  is null.");
            }
            var wynik = await _context.Wynik.FindAsync(id);
            if (wynik != null)
            {
                _context.Wynik.Remove(wynik);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WynikExists(int id)
        {
          return (_context.Wynik?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
