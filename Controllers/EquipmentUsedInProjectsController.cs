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
    public class EquipmentUsedInProjectsController : Controller
    {
        private readonly Information_System_Of_The_Project_OrganizationContext _context;

        public EquipmentUsedInProjectsController(Information_System_Of_The_Project_OrganizationContext context)
        {
            _context = context;
        }

        // GET: EquipmentUsedInProjects
        public async Task<IActionResult> Index()
        {
              return _context.EquipmentUsedInProjects != null ? 
                          View(await _context.EquipmentUsedInProjects.ToListAsync()) :
                          Problem("Entity set 'Information_System_Of_The_Project_OrganizationContext.EquipmentUsedInProjects'  is null.");
        }

        // GET: EquipmentUsedInProjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EquipmentUsedInProjects == null)
            {
                return NotFound();
            }

            var equipmentUsedInProject = await _context.EquipmentUsedInProjects
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipmentUsedInProject == null)
            {
                return NotFound();
            }

            return View(equipmentUsedInProject);
        }

        // GET: EquipmentUsedInProjects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EquipmentUsedInProjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdEquipment,IdProjects,IdTypeOfWork,AppointmentDate,DismissalDate")] EquipmentUsedInProject equipmentUsedInProject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipmentUsedInProject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(equipmentUsedInProject);
        }

        // GET: EquipmentUsedInProjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EquipmentUsedInProjects == null)
            {
                return NotFound();
            }

            var equipmentUsedInProject = await _context.EquipmentUsedInProjects.FindAsync(id);
            if (equipmentUsedInProject == null)
            {
                return NotFound();
            }
            return View(equipmentUsedInProject);
        }

        // POST: EquipmentUsedInProjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdEquipment,IdProjects,IdTypeOfWork,AppointmentDate,DismissalDate")] EquipmentUsedInProject equipmentUsedInProject)
        {
            if (id != equipmentUsedInProject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipmentUsedInProject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipmentUsedInProjectExists(equipmentUsedInProject.Id))
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
            return View(equipmentUsedInProject);
        }

        // GET: EquipmentUsedInProjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EquipmentUsedInProjects == null)
            {
                return NotFound();
            }

            var equipmentUsedInProject = await _context.EquipmentUsedInProjects
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipmentUsedInProject == null)
            {
                return NotFound();
            }

            return View(equipmentUsedInProject);
        }

        // POST: EquipmentUsedInProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EquipmentUsedInProjects == null)
            {
                return Problem("Entity set 'Information_System_Of_The_Project_OrganizationContext.EquipmentUsedInProjects'  is null.");
            }
            var equipmentUsedInProject = await _context.EquipmentUsedInProjects.FindAsync(id);
            if (equipmentUsedInProject != null)
            {
                _context.EquipmentUsedInProjects.Remove(equipmentUsedInProject);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipmentUsedInProjectExists(int id)
        {
          return (_context.EquipmentUsedInProjects?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
