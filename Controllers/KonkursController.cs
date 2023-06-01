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
    public class KonkursController : Controller
    {
        private readonly MvcPracownikContext _context;

        public KonkursController(MvcPracownikContext context)
        {
            _context = context;
        }

        // GET: Konkurs
        public async Task<IActionResult> Index()
        {
              return _context.Konkurs != null ?
                          View(await _context.Konkurs.ToListAsync()) :
                          Problem("Entity set 'MvcPracownikContext.Konkurs'  is null.");
        }

        // GET: Konkurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Konkurs == null)
            {
                return NotFound();
            }

            var konkurs = await _context.Konkurs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (konkurs == null)
            {
                return NotFound();
            }

            return View(konkurs);
        }

        // GET: Konkurs/Create
        public IActionResult Create()
        {
            PopulateSkoczniaDropDownList();
            return View();
        }

        private void PopulateSkoczniaDropDownList(object? selected = null)
        {
            var wybrane = from z in _context.Skocznia
                                select z;
            var res = wybrane.AsNoTracking();
            ViewBag.KonkursId = new SelectList(res, "Id", "Nazwa", selected);
        }

        // POST: Konkurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nazwa,Rodzaj,Pora,Data")] Konkurs konkurs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(konkurs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(konkurs);
        }

        // GET: Konkurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Konkurs == null)
            {
                return NotFound();
            }

            var konkurs = await _context.Konkurs.FindAsync(id);
            if (konkurs == null)
            {
                return NotFound();
            }
            return View(konkurs);
        }

        // POST: Konkurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nazwa,Rodzaj,Pora,Data")] Konkurs konkurs)
        {
            if (id != konkurs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(konkurs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KonkursExists(konkurs.Id))
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
            return View(konkurs);
        }

        // GET: Konkurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Konkurs == null)
            {
                return NotFound();
            }

            var konkurs = await _context.Konkurs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (konkurs == null)
            {
                return NotFound();
            }

            return View(konkurs);
        }

        // POST: Konkurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Konkurs == null)
            {
                return Problem("Entity set 'MvcPracownikContext.Konkurs'  is null.");
            }
            var konkurs = await _context.Konkurs.FindAsync(id);
            if (konkurs != null)
            {
                _context.Konkurs.Remove(konkurs);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KonkursExists(int id)
        {
          return (_context.Konkurs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
