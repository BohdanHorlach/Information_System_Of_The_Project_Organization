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
    public class EmployeeCategoriesController : Controller
    {
        private readonly Information_System_Of_The_Project_OrganizationContext _context;

        public EmployeeCategoriesController(Information_System_Of_The_Project_OrganizationContext context)
        {
            _context = context;
        }

        // GET: EmployeeCategories
        public async Task<IActionResult> Index()
        {
              return _context.EmployeeCategories != null ? 
                          View(await _context.EmployeeCategories.ToListAsync()) :
                          Problem("Entity set 'Information_System_Of_The_Project_OrganizationContext.EmployeeCategories'  is null.");
        }

        // GET: EmployeeCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EmployeeCategories == null)
            {
                return NotFound();
            }

            var employeeCategory = await _context.EmployeeCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeCategory == null)
            {
                return NotFound();
            }

            return View(employeeCategory);
        }

        // GET: EmployeeCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,CategoryId,AssignmentDate")] EmployeeCategory employeeCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeCategory);
        }

        // GET: EmployeeCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EmployeeCategories == null)
            {
                return NotFound();
            }

            var employeeCategory = await _context.EmployeeCategories.FindAsync(id);
            if (employeeCategory == null)
            {
                return NotFound();
            }
            return View(employeeCategory);
        }

        // POST: EmployeeCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,CategoryId,AssignmentDate")] EmployeeCategory employeeCategory)
        {
            if (id != employeeCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeCategoryExists(employeeCategory.Id))
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
            return View(employeeCategory);
        }

        // GET: EmployeeCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EmployeeCategories == null)
            {
                return NotFound();
            }

            var employeeCategory = await _context.EmployeeCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeCategory == null)
            {
                return NotFound();
            }

            return View(employeeCategory);
        }

        // POST: EmployeeCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EmployeeCategories == null)
            {
                return Problem("Entity set 'Information_System_Of_The_Project_OrganizationContext.EmployeeCategories'  is null.");
            }
            var employeeCategory = await _context.EmployeeCategories.FindAsync(id);
            if (employeeCategory != null)
            {
                _context.EmployeeCategories.Remove(employeeCategory);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeCategoryExists(int id)
        {
          return (_context.EmployeeCategories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
