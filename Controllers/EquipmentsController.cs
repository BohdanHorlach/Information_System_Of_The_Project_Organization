﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Information_System_Of_The_Project_Organization.Models;

namespace Information_System_Of_The_Project_Organization.Controllers
{
    public class EquipmentsController : Controller
    {
        private readonly Information_System_Of_The_Project_OrganizationContext _context;

        public EquipmentsController(Information_System_Of_The_Project_OrganizationContext context)
        {
            _context = context;
        }

        // GET: Equipments
        public async Task<IActionResult> Index()
        {
              return _context.Equipment != null ? 
                          View(await _context.Equipment.ToListAsync()) :
                          Problem("Entity set 'Information_System_Of_The_Project_OrganizationContext.Equipment'  is null.");
        }


        public async Task<IActionResult> GetUsedEquipmentFromPact(string pactName)
        {
            string? pactNameToProcedure = pactName == "" || pactName == null ? null : pactName;

            List<UsedEquipmentFromPact> usedEquipmentFromPacts = await _context.UsedEquipmentFromPact.FromSqlInterpolated($"EXEC GetUsedEquipmentFromPact {pactNameToProcedure}").ToListAsync();

            return View("GetUsedEquipmentFromPact", usedEquipmentFromPacts);
        }


        // GET: Equipments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Equipment == null)
            {
                return NotFound();
            }

            var equipment = await _context.Equipment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipment == null)
            {
                return NotFound();
            }

            return View(equipment);
        }

        // GET: Equipments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Equipments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EquipmentName,Destination")] Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(equipment);
        }

        // GET: Equipments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Equipment == null)
            {
                return NotFound();
            }

            var equipment = await _context.Equipment.FindAsync(id);
            if (equipment == null)
            {
                return NotFound();
            }
            return View(equipment);
        }

        // POST: Equipments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EquipmentName,Destination")] Equipment equipment)
        {
            if (id != equipment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipmentExists(equipment.Id))
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
            return View(equipment);
        }

        // GET: Equipments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Equipment == null)
            {
                return NotFound();
            }

            var equipment = await _context.Equipment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (equipment == null)
            {
                return NotFound();
            }

            return View(equipment);
        }

        // POST: Equipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Equipment == null)
            {
                return Problem("Entity set 'Information_System_Of_The_Project_OrganizationContext.Equipment'  is null.");
            }
            var equipment = await _context.Equipment.FindAsync(id);
            if (equipment != null)
            {
                _context.Equipment.Remove(equipment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipmentExists(int id)
        {
          return (_context.Equipment?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
