using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Artikel_Hersteller.Models;

namespace Artikel_Hersteller
{
    public class ArtikelsController : Controller
    {
        private readonly HerstellerContext _context;

        public ArtikelsController(HerstellerContext context)
        {
            _context = context;
        }

        // GET: Artikel
        public async Task<IActionResult> Index()
        {
            return _context.Artikels != null ?
                        View(await _context.Artikels.ToListAsync()) :
                        Problem("Entity set 'HerstellerContext.Artikels'  is null.");
        }

        // GET: Artikel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Artikels == null)
            {
                return NotFound();
            }

            var artikel = await _context.Artikels
                .FirstOrDefaultAsync(m => m.ArtId == id);
            if (artikel == null)
            {
                return NotFound();
            }

            return View(artikel);
        }

        // GET: Artikel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Artikel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArtId,ArtName")] Artikel artikel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artikel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(artikel);
        }

        // GET: Artikel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Artikels == null)
            {
                return NotFound();
            }

            var artikel = await _context.Artikels.FindAsync(id);
            if (artikel == null)
            {
                return NotFound();
            }
            return View(artikel);
        }

        // POST: Artikel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArtId,ArtName")] Artikel artikel)
        {
            if (id != artikel.ArtId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(artikel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtikelExists(artikel.ArtId))
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
            return View(artikel);
        }

        // GET: Artikel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Artikels == null)
            {
                return NotFound();
            }

            var artikel = await _context.Artikels
                .FirstOrDefaultAsync(m => m.ArtId == id);
            if (artikel == null)
            {
                return NotFound();
            }

            return View(artikel);
        }

        // POST: Artikel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Artikels == null)
            {
                return Problem("Entity set 'HerstellerContext.Artikels'  is null.");
            }
            var artikel = await _context.Artikels.FindAsync(id);
            if (artikel != null)
            {
                _context.Artikels.Remove(artikel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArtikelExists(int id)
        {
            return (_context.Artikels?.Any(e => e.ArtId == id)).GetValueOrDefault();
        }
    }
}
