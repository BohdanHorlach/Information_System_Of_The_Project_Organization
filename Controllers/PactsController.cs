using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Information_System_Of_The_Project_Organization.Models;

namespace Information_System_Of_The_Project_Organization.Controllers
{
    public class PactsController : Controller
    {
        private readonly Information_System_Of_The_Project_OrganizationContext _context;

        public PactsController(Information_System_Of_The_Project_OrganizationContext context)
        {
            _context = context;
        }

        // GET: Pacts
        public async Task<IActionResult> Index()
        {
              return _context.Pacts != null ? 
                          View(await _context.Pacts.ToListAsync()) :
                          Problem("Entity set 'Information_System_Of_The_Project_OrganizationContext.Pacts'  is null.");
        }

        // GET: Pacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pacts == null)
            {
                return NotFound();
            }

            var pact = await _context.Pacts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pact == null)
            {
                return NotFound();
            }

            return View(pact);
        }

        // GET: Pacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PactName,FullNameCustomer,EmailCustomer,StartDate,EndDate")] Pact pact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pact);
        }

        // GET: Pacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pacts == null)
            {
                return NotFound();
            }

            var pact = await _context.Pacts.FindAsync(id);
            if (pact == null)
            {
                return NotFound();
            }
            return View(pact);
        }

        // POST: Pacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PactName,FullNameCustomer,EmailCustomer,StartDate,EndDate")] Pact pact)
        {
            if (id != pact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PactExists(pact.Id))
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
            return View(pact);
        }

        // GET: Pacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pacts == null)
            {
                return NotFound();
            }

            var pact = await _context.Pacts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pact == null)
            {
                return NotFound();
            }

            return View(pact);
        }

        // POST: Pacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pacts == null)
            {
                return Problem("Entity set 'Information_System_Of_The_Project_OrganizationContext.Pacts'  is null.");
            }
            var pact = await _context.Pacts.FindAsync(id);
            if (pact != null)
            {
                _context.Pacts.Remove(pact);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PactExists(int id)
        {
          return (_context.Pacts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
