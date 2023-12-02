using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Raythos_Aerospace.Data;
using Raythos_Aerospace.Models;

namespace Raythos_Aerospace.Controllers
{
    public class ManufacturingsController : Controller
    {
        private readonly Raythos_AerospaceContext _context;

        public ManufacturingsController(Raythos_AerospaceContext context)
        {
            _context = context;
        }

        // GET: Manufacturings
        public async Task<IActionResult> Index()
        {
              return _context.Manufacturing != null ? 
                          View(await _context.Manufacturing.ToListAsync()) :
                          Problem("Entity set 'Raythos_AerospaceContext.Manufacturing'  is null.");
        }

        // GET: Manufacturings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Manufacturing == null)
            {
                return NotFound();
            }

            var manufacturing = await _context.Manufacturing
                .FirstOrDefaultAsync(m => m.Id == id);
            if (manufacturing == null)
            {
                return NotFound();
            }

            return View(manufacturing);
        }

        // GET: Manufacturings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Manufacturings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrderNumber,Description")] Manufacturing manufacturing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(manufacturing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(manufacturing);
        }

        // GET: Manufacturings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Manufacturing == null)
            {
                return NotFound();
            }

            var manufacturing = await _context.Manufacturing.FindAsync(id);
            if (manufacturing == null)
            {
                return NotFound();
            }
            return View(manufacturing);
        }

        // POST: Manufacturings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrderNumber,Description")] Manufacturing manufacturing)
        {
            if (id != manufacturing.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(manufacturing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManufacturingExists(manufacturing.Id))
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
            return View(manufacturing);
        }

        // GET: Manufacturings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Manufacturing == null)
            {
                return NotFound();
            }

            var manufacturing = await _context.Manufacturing
                .FirstOrDefaultAsync(m => m.Id == id);
            if (manufacturing == null)
            {
                return NotFound();
            }

            return View(manufacturing);
        }

        // POST: Manufacturings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Manufacturing == null)
            {
                return Problem("Entity set 'Raythos_AerospaceContext.Manufacturing'  is null.");
            }
            var manufacturing = await _context.Manufacturing.FindAsync(id);
            if (manufacturing != null)
            {
                _context.Manufacturing.Remove(manufacturing);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ManufacturingExists(int id)
        {
          return (_context.Manufacturing?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
