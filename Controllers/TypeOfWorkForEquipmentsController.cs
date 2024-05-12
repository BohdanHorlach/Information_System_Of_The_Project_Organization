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
    public class TypeOfWorkForEquipmentsController : Controller
    {
        private readonly Information_System_Of_The_Project_OrganizationContext _context;

        public TypeOfWorkForEquipmentsController(Information_System_Of_The_Project_OrganizationContext context)
        {
            _context = context;
        }

        // GET: TypeOfWorkForEquipments
        public async Task<IActionResult> Index()
        {
              return _context.TypeOfWorkForEquipments != null ? 
                          View(await _context.TypeOfWorkForEquipments.ToListAsync()) :
                          Problem("Entity set 'Information_System_Of_The_Project_OrganizationContext.TypeOfWorkForEquipments'  is null.");
        }

        // GET: TypeOfWorkForEquipments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TypeOfWorkForEquipments == null)
            {
                return NotFound();
            }

            var typeOfWorkForEquipment = await _context.TypeOfWorkForEquipments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeOfWorkForEquipment == null)
            {
                return NotFound();
            }

            return View(typeOfWorkForEquipment);
        }

        // GET: TypeOfWorkForEquipments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeOfWorkForEquipments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TypeOfWork")] TypeOfWorkForEquipment typeOfWorkForEquipment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeOfWorkForEquipment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeOfWorkForEquipment);
        }

        // GET: TypeOfWorkForEquipments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TypeOfWorkForEquipments == null)
            {
                return NotFound();
            }

            var typeOfWorkForEquipment = await _context.TypeOfWorkForEquipments.FindAsync(id);
            if (typeOfWorkForEquipment == null)
            {
                return NotFound();
            }
            return View(typeOfWorkForEquipment);
        }

        // POST: TypeOfWorkForEquipments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TypeOfWork")] TypeOfWorkForEquipment typeOfWorkForEquipment)
        {
            if (id != typeOfWorkForEquipment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeOfWorkForEquipment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeOfWorkForEquipmentExists(typeOfWorkForEquipment.Id))
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
            return View(typeOfWorkForEquipment);
        }

        // GET: TypeOfWorkForEquipments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TypeOfWorkForEquipments == null)
            {
                return NotFound();
            }

            var typeOfWorkForEquipment = await _context.TypeOfWorkForEquipments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeOfWorkForEquipment == null)
            {
                return NotFound();
            }

            return View(typeOfWorkForEquipment);
        }

        // POST: TypeOfWorkForEquipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TypeOfWorkForEquipments == null)
            {
                return Problem("Entity set 'Information_System_Of_The_Project_OrganizationContext.TypeOfWorkForEquipments'  is null.");
            }
            var typeOfWorkForEquipment = await _context.TypeOfWorkForEquipments.FindAsync(id);
            if (typeOfWorkForEquipment != null)
            {
                _context.TypeOfWorkForEquipments.Remove(typeOfWorkForEquipment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeOfWorkForEquipmentExists(int id)
        {
          return (_context.TypeOfWorkForEquipments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
