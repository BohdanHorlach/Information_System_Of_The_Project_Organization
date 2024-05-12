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
    public class TypeOfOrderInSubcontractorsController : Controller
    {
        private readonly Information_System_Of_The_Project_OrganizationContext _context;

        public TypeOfOrderInSubcontractorsController(Information_System_Of_The_Project_OrganizationContext context)
        {
            _context = context;
        }

        // GET: TypeOfOrderInSubcontractors
        public async Task<IActionResult> Index()
        {
              return _context.TypeOfOrderInSubcontractors != null ? 
                          View(await _context.TypeOfOrderInSubcontractors.ToListAsync()) :
                          Problem("Entity set 'Information_System_Of_The_Project_OrganizationContext.TypeOfOrderInSubcontractors'  is null.");
        }

        // GET: TypeOfOrderInSubcontractors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TypeOfOrderInSubcontractors == null)
            {
                return NotFound();
            }

            var typeOfOrderInSubcontractor = await _context.TypeOfOrderInSubcontractors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeOfOrderInSubcontractor == null)
            {
                return NotFound();
            }

            return View(typeOfOrderInSubcontractor);
        }

        // GET: TypeOfOrderInSubcontractors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeOfOrderInSubcontractors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TypeOfOrder")] TypeOfOrderInSubcontractor typeOfOrderInSubcontractor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeOfOrderInSubcontractor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeOfOrderInSubcontractor);
        }

        // GET: TypeOfOrderInSubcontractors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TypeOfOrderInSubcontractors == null)
            {
                return NotFound();
            }

            var typeOfOrderInSubcontractor = await _context.TypeOfOrderInSubcontractors.FindAsync(id);
            if (typeOfOrderInSubcontractor == null)
            {
                return NotFound();
            }
            return View(typeOfOrderInSubcontractor);
        }

        // POST: TypeOfOrderInSubcontractors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TypeOfOrder")] TypeOfOrderInSubcontractor typeOfOrderInSubcontractor)
        {
            if (id != typeOfOrderInSubcontractor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeOfOrderInSubcontractor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeOfOrderInSubcontractorExists(typeOfOrderInSubcontractor.Id))
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
            return View(typeOfOrderInSubcontractor);
        }

        // GET: TypeOfOrderInSubcontractors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TypeOfOrderInSubcontractors == null)
            {
                return NotFound();
            }

            var typeOfOrderInSubcontractor = await _context.TypeOfOrderInSubcontractors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeOfOrderInSubcontractor == null)
            {
                return NotFound();
            }

            return View(typeOfOrderInSubcontractor);
        }

        // POST: TypeOfOrderInSubcontractors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TypeOfOrderInSubcontractors == null)
            {
                return Problem("Entity set 'Information_System_Of_The_Project_OrganizationContext.TypeOfOrderInSubcontractors'  is null.");
            }
            var typeOfOrderInSubcontractor = await _context.TypeOfOrderInSubcontractors.FindAsync(id);
            if (typeOfOrderInSubcontractor != null)
            {
                _context.TypeOfOrderInSubcontractors.Remove(typeOfOrderInSubcontractor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeOfOrderInSubcontractorExists(int id)
        {
          return (_context.TypeOfOrderInSubcontractors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
