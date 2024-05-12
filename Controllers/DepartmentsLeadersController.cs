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
    public class DepartmentsLeadersController : Controller
    {
        private readonly Information_System_Of_The_Project_OrganizationContext _context;

        public DepartmentsLeadersController(Information_System_Of_The_Project_OrganizationContext context)
        {
            _context = context;
        }

        // GET: DepartmentsLeaders
        public async Task<IActionResult> Index()
        {
              return _context.DepartmentsLeaders != null ? 
                          View(await _context.DepartmentsLeaders.ToListAsync()) :
                          Problem("Entity set 'Information_System_Of_The_Project_OrganizationContext.DepartmentsLeaders'  is null.");
        }

        // GET: DepartmentsLeaders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DepartmentsLeaders == null)
            {
                return NotFound();
            }

            var departmentsLeader = await _context.DepartmentsLeaders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departmentsLeader == null)
            {
                return NotFound();
            }

            return View(departmentsLeader);
        }

        // GET: DepartmentsLeaders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DepartmentsLeaders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdDepartaments,IdEmployee,AppointmentDate,DismissalDate")] DepartmentsLeader departmentsLeader)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departmentsLeader);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departmentsLeader);
        }

        // GET: DepartmentsLeaders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DepartmentsLeaders == null)
            {
                return NotFound();
            }

            var departmentsLeader = await _context.DepartmentsLeaders.FindAsync(id);
            if (departmentsLeader == null)
            {
                return NotFound();
            }
            return View(departmentsLeader);
        }

        // POST: DepartmentsLeaders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdDepartaments,IdEmployee,AppointmentDate,DismissalDate")] DepartmentsLeader departmentsLeader)
        {
            if (id != departmentsLeader.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departmentsLeader);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentsLeaderExists(departmentsLeader.Id))
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
            return View(departmentsLeader);
        }

        // GET: DepartmentsLeaders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DepartmentsLeaders == null)
            {
                return NotFound();
            }

            var departmentsLeader = await _context.DepartmentsLeaders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departmentsLeader == null)
            {
                return NotFound();
            }

            return View(departmentsLeader);
        }

        // POST: DepartmentsLeaders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DepartmentsLeaders == null)
            {
                return Problem("Entity set 'Information_System_Of_The_Project_OrganizationContext.DepartmentsLeaders'  is null.");
            }
            var departmentsLeader = await _context.DepartmentsLeaders.FindAsync(id);
            if (departmentsLeader != null)
            {
                _context.DepartmentsLeaders.Remove(departmentsLeader);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentsLeaderExists(int id)
        {
          return (_context.DepartmentsLeaders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
