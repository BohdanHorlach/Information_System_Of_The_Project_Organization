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
    public class EquipmentDepartmentsController : Controller
    {
        private readonly Information_System_Of_The_Project_OrganizationContext _context;

        public EquipmentDepartmentsController(Information_System_Of_The_Project_OrganizationContext context)
        {
            _context = context;
        }

        // GET: EquipmentDepartments
        public async Task<IActionResult> Index()
        {
              return _context.EquipmentDepartments != null ? 
                          View(await _context.EquipmentDepartments.ToListAsync()) :
                          Problem("Entity set 'Information_System_Of_The_Project_OrganizationContext.EquipmentDepartments'  is null.");
        }


        public async Task<IActionResult> GetCurrentEquipmentInvolved(DateTime currentDate)
        {
            DateTime? dateToProcedure = DateTime.MinValue == currentDate ? null : currentDate;

            List<CurrentEquipmentInvolved> currentEquipmentInvolveds = await _context.CurrentEquipmentInvolveds.FromSqlInterpolated($"EXEC GetCurrentEquipmentInvolved {dateToProcedure}").ToListAsync();

            return View("GetCurrentEquipmentInvolved", currentEquipmentInvolveds);
        }


        // GET: EquipmentDepartments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EquipmentDepartments == null)
            {
                return NotFound();
            }

            var equipmentDepartment = await _context.EquipmentDepartments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipmentDepartment == null)
            {
                return NotFound();
            }

            return View(equipmentDepartment);
        }

        // GET: EquipmentDepartments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EquipmentDepartments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdDepartaments,IdEquipment,AppointmentDate,DismissalDate")] EquipmentDepartment equipmentDepartment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipmentDepartment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(equipmentDepartment);
        }

        // GET: EquipmentDepartments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EquipmentDepartments == null)
            {
                return NotFound();
            }

            var equipmentDepartment = await _context.EquipmentDepartments.FindAsync(id);
            if (equipmentDepartment == null)
            {
                return NotFound();
            }
            return View(equipmentDepartment);
        }

        // POST: EquipmentDepartments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdDepartaments,IdEquipment,AppointmentDate,DismissalDate")] EquipmentDepartment equipmentDepartment)
        {
            if (id != equipmentDepartment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipmentDepartment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipmentDepartmentExists(equipmentDepartment.Id))
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
            return View(equipmentDepartment);
        }

        // GET: EquipmentDepartments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EquipmentDepartments == null)
            {
                return NotFound();
            }

            var equipmentDepartment = await _context.EquipmentDepartments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipmentDepartment == null)
            {
                return NotFound();
            }

            return View(equipmentDepartment);
        }

        // POST: EquipmentDepartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EquipmentDepartments == null)
            {
                return Problem("Entity set 'Information_System_Of_The_Project_OrganizationContext.EquipmentDepartments'  is null.");
            }
            var equipmentDepartment = await _context.EquipmentDepartments.FindAsync(id);
            if (equipmentDepartment != null)
            {
                _context.EquipmentDepartments.Remove(equipmentDepartment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipmentDepartmentExists(int id)
        {
          return (_context.EquipmentDepartments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
