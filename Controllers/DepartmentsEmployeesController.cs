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
    public class DepartmentsEmployeesController : Controller
    {
        private readonly Information_System_Of_The_Project_OrganizationContext _context;

        public DepartmentsEmployeesController(Information_System_Of_The_Project_OrganizationContext context)
        {
            _context = context;
        }

        // GET: DepartmentsEmployees
        public async Task<IActionResult> Index()
        {
              return _context.DepartmentsEmployees != null ? 
                          View(await _context.DepartmentsEmployees.ToListAsync()) :
                          Problem("Entity set 'Information_System_Of_The_Project_OrganizationContext.DepartmentsEmployees'  is null.");
        }

        // GET: DepartmentsEmployees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DepartmentsEmployees == null)
            {
                return NotFound();
            }

            var departmentsEmployee = await _context.DepartmentsEmployees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departmentsEmployee == null)
            {
                return NotFound();
            }

            return View(departmentsEmployee);
        }

        // GET: DepartmentsEmployees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DepartmentsEmployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdDepartaments,IdEmployee,AppointmentDate,DismissalDate")] DepartmentsEmployee departmentsEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departmentsEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departmentsEmployee);
        }

        // GET: DepartmentsEmployees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DepartmentsEmployees == null)
            {
                return NotFound();
            }

            var departmentsEmployee = await _context.DepartmentsEmployees.FindAsync(id);
            if (departmentsEmployee == null)
            {
                return NotFound();
            }
            return View(departmentsEmployee);
        }

        // POST: DepartmentsEmployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdDepartaments,IdEmployee,AppointmentDate,DismissalDate")] DepartmentsEmployee departmentsEmployee)
        {
            if (id != departmentsEmployee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departmentsEmployee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentsEmployeeExists(departmentsEmployee.Id))
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
            return View(departmentsEmployee);
        }

        // GET: DepartmentsEmployees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DepartmentsEmployees == null)
            {
                return NotFound();
            }

            var departmentsEmployee = await _context.DepartmentsEmployees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departmentsEmployee == null)
            {
                return NotFound();
            }

            return View(departmentsEmployee);
        }

        // POST: DepartmentsEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DepartmentsEmployees == null)
            {
                return Problem("Entity set 'Information_System_Of_The_Project_OrganizationContext.DepartmentsEmployees'  is null.");
            }
            var departmentsEmployee = await _context.DepartmentsEmployees.FindAsync(id);
            if (departmentsEmployee != null)
            {
                _context.DepartmentsEmployees.Remove(departmentsEmployee);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentsEmployeeExists(int id)
        {
          return (_context.DepartmentsEmployees?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
