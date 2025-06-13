using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bc.Models.DbModels;

namespace bc.Controllers
{
    public class SkladniksController : Controller
    {
        private readonly DatabaseContext _context;

        public SkladniksController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Skladniks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Skladniki.ToListAsync());
        }

        // GET: Skladniks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skladnik = await _context.Skladniki
                .FirstOrDefaultAsync(m => m.IdSkladnika == id);
            if (skladnik == null)
            {
                return NotFound();
            }

            return View(skladnik);
        }

        // GET: Skladniks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Skladniks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSkladnika,NazwaSkladnika")] Skladnik skladnik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(skladnik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(skladnik);
        }

        // GET: Skladniks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skladnik = await _context.Skladniki.FindAsync(id);
            if (skladnik == null)
            {
                return NotFound();
            }
            return View(skladnik);
        }

        // POST: Skladniks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSkladnika,NazwaSkladnika")] Skladnik skladnik)
        {
            if (id != skladnik.IdSkladnika)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(skladnik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkladnikExists(skladnik.IdSkladnika))
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
            return View(skladnik);
        }

        // GET: Skladniks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skladnik = await _context.Skladniki
                .FirstOrDefaultAsync(m => m.IdSkladnika == id);
            if (skladnik == null)
            {
                return NotFound();
            }

            return View(skladnik);
        }

        // POST: Skladniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var skladnik = await _context.Skladniki.FindAsync(id);
            if (skladnik != null)
            {
                _context.Skladniki.Remove(skladnik);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SkladnikExists(int id)
        {
            return _context.Skladniki.Any(e => e.IdSkladnika == id);
        }
    }
}
