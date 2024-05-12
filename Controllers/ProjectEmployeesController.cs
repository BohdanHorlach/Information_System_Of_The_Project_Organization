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
    public class ProjectEmployeesController : Controller
    {
        private readonly Information_System_Of_The_Project_OrganizationContext _context;

        public ProjectEmployeesController(Information_System_Of_The_Project_OrganizationContext context)
        {
            _context = context;
        }

        // GET: ProjectEmployees
        public async Task<IActionResult> Index()
        {
              return _context.ProjectEmployees != null ? 
                          View(await _context.ProjectEmployees.ToListAsync()) :
                          Problem("Entity set 'Information_System_Of_The_Project_OrganizationContext.ProjectEmployees'  is null.");
        }

        // GET: ProjectEmployees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProjectEmployees == null)
            {
                return NotFound();
            }

            var projectEmployee = await _context.ProjectEmployees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectEmployee == null)
            {
                return NotFound();
            }

            return View(projectEmployee);
        }

        // GET: ProjectEmployees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProjectEmployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdProject,IdEmployee,IdResponsibility,AppointmentDate,DismissalDate")] ProjectEmployee projectEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projectEmployee);
        }

        // GET: ProjectEmployees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProjectEmployees == null)
            {
                return NotFound();
            }

            var projectEmployee = await _context.ProjectEmployees.FindAsync(id);
            if (projectEmployee == null)
            {
                return NotFound();
            }
            return View(projectEmployee);
        }

        // POST: ProjectEmployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdProject,IdEmployee,IdResponsibility,AppointmentDate,DismissalDate")] ProjectEmployee projectEmployee)
        {
            if (id != projectEmployee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectEmployee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectEmployeeExists(projectEmployee.Id))
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
            return View(projectEmployee);
        }

        // GET: ProjectEmployees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProjectEmployees == null)
            {
                return NotFound();
            }

            var projectEmployee = await _context.ProjectEmployees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (projectEmployee == null)
            {
                return NotFound();
            }

            return View(projectEmployee);
        }

        // POST: ProjectEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProjectEmployees == null)
            {
                return Problem("Entity set 'Information_System_Of_The_Project_OrganizationContext.ProjectEmployees'  is null.");
            }
            var projectEmployee = await _context.ProjectEmployees.FindAsync(id);
            if (projectEmployee != null)
            {
                _context.ProjectEmployees.Remove(projectEmployee);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectEmployeeExists(int id)
        {
          return (_context.ProjectEmployees?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
