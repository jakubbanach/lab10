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
    public class SkoczniaController : Controller
    {
        private readonly MvcPracownikContext _context;

        public SkoczniaController(MvcPracownikContext context)
        {
            _context = context;
        }

        // GET: Skocznia
        public async Task<IActionResult> Index()
        {
              return _context.Skocznia != null ? 
                          View(await _context.Skocznia.ToListAsync()) :
                          Problem("Entity set 'MvcPracownikContext.Skocznia'  is null.");
        }

        // GET: Skocznia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Skocznia == null)
            {
                return NotFound();
            }

            var skocznia = await _context.Skocznia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (skocznia == null)
            {
                return NotFound();
            }

            return View(skocznia);
        }

        // GET: Skocznia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Skocznia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nazwa,Kraj,Miejscowosc")] Skocznia skocznia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(skocznia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(skocznia);
        }

        // GET: Skocznia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Skocznia == null)
            {
                return NotFound();
            }

            var skocznia = await _context.Skocznia.FindAsync(id);
            if (skocznia == null)
            {
                return NotFound();
            }
            return View(skocznia);
        }

        // POST: Skocznia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nazwa,Kraj,Miejscowosc")] Skocznia skocznia)
        {
            if (id != skocznia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(skocznia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkoczniaExists(skocznia.Id))
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
            return View(skocznia);
        }

        // GET: Skocznia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Skocznia == null)
            {
                return NotFound();
            }

            var skocznia = await _context.Skocznia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (skocznia == null)
            {
                return NotFound();
            }

            return View(skocznia);
        }

        // POST: Skocznia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Skocznia == null)
            {
                return Problem("Entity set 'MvcPracownikContext.Skocznia'  is null.");
            }
            var skocznia = await _context.Skocznia.FindAsync(id);
            if (skocznia != null)
            {
                _context.Skocznia.Remove(skocznia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SkoczniaExists(int id)
        {
          return (_context.Skocznia?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
