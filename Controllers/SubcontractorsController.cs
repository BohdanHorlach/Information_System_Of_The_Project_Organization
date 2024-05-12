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
    public class SubcontractorsController : Controller
    {
        private readonly Information_System_Of_The_Project_OrganizationContext _context;

        public SubcontractorsController(Information_System_Of_The_Project_OrganizationContext context)
        {
            _context = context;
        }

        // GET: Subcontractors
        public async Task<IActionResult> Index()
        {
              return _context.Subcontractors != null ? 
                          View(await _context.Subcontractors.ToListAsync()) :
                          Problem("Entity set 'Information_System_Of_The_Project_OrganizationContext.Subcontractors'  is null.");
        }

        // GET: Subcontractors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Subcontractors == null)
            {
                return NotFound();
            }

            var subcontractor = await _context.Subcontractors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subcontractor == null)
            {
                return NotFound();
            }

            return View(subcontractor);
        }

        // GET: Subcontractors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Subcontractors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameOrganization")] Subcontractor subcontractor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subcontractor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subcontractor);
        }

        // GET: Subcontractors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Subcontractors == null)
            {
                return NotFound();
            }

            var subcontractor = await _context.Subcontractors.FindAsync(id);
            if (subcontractor == null)
            {
                return NotFound();
            }
            return View(subcontractor);
        }

        // POST: Subcontractors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameOrganization")] Subcontractor subcontractor)
        {
            if (id != subcontractor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subcontractor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubcontractorExists(subcontractor.Id))
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
            return View(subcontractor);
        }

        // GET: Subcontractors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Subcontractors == null)
            {
                return NotFound();
            }

            var subcontractor = await _context.Subcontractors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subcontractor == null)
            {
                return NotFound();
            }

            return View(subcontractor);
        }

        // POST: Subcontractors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Subcontractors == null)
            {
                return Problem("Entity set 'Information_System_Of_The_Project_OrganizationContext.Subcontractors'  is null.");
            }
            var subcontractor = await _context.Subcontractors.FindAsync(id);
            if (subcontractor != null)
            {
                _context.Subcontractors.Remove(subcontractor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubcontractorExists(int id)
        {
          return (_context.Subcontractors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
