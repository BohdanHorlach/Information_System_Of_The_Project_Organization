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
    public class OrdersFromSubcontractorsController : Controller
    {
        private readonly Information_System_Of_The_Project_OrganizationContext _context;

        public OrdersFromSubcontractorsController(Information_System_Of_The_Project_OrganizationContext context)
        {
            _context = context;
        }

        // GET: OrdersFromSubcontractors
        public async Task<IActionResult> Index()
        {
              return _context.OrdersFromSubcontractors != null ? 
                          View(await _context.OrdersFromSubcontractors.ToListAsync()) :
                          Problem("Entity set 'Information_System_Of_The_Project_OrganizationContext.OrdersFromSubcontractors'  is null.");
        }

        // GET: OrdersFromSubcontractors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OrdersFromSubcontractors == null)
            {
                return NotFound();
            }

            var ordersFromSubcontractor = await _context.OrdersFromSubcontractors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordersFromSubcontractor == null)
            {
                return NotFound();
            }

            return View(ordersFromSubcontractor);
        }

        // GET: OrdersFromSubcontractors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrdersFromSubcontractors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdSubcontractors,IdProject,IdTypeOfOrderInSubcontractors,OrderDate,ReceivedDate,Cost")] OrdersFromSubcontractor ordersFromSubcontractor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordersFromSubcontractor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ordersFromSubcontractor);
        }

        // GET: OrdersFromSubcontractors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OrdersFromSubcontractors == null)
            {
                return NotFound();
            }

            var ordersFromSubcontractor = await _context.OrdersFromSubcontractors.FindAsync(id);
            if (ordersFromSubcontractor == null)
            {
                return NotFound();
            }
            return View(ordersFromSubcontractor);
        }

        // POST: OrdersFromSubcontractors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdSubcontractors,IdProject,IdTypeOfOrderInSubcontractors,OrderDate,ReceivedDate,Cost")] OrdersFromSubcontractor ordersFromSubcontractor)
        {
            if (id != ordersFromSubcontractor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordersFromSubcontractor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdersFromSubcontractorExists(ordersFromSubcontractor.Id))
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
            return View(ordersFromSubcontractor);
        }

        // GET: OrdersFromSubcontractors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OrdersFromSubcontractors == null)
            {
                return NotFound();
            }

            var ordersFromSubcontractor = await _context.OrdersFromSubcontractors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordersFromSubcontractor == null)
            {
                return NotFound();
            }

            return View(ordersFromSubcontractor);
        }

        // POST: OrdersFromSubcontractors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OrdersFromSubcontractors == null)
            {
                return Problem("Entity set 'Information_System_Of_The_Project_OrganizationContext.OrdersFromSubcontractors'  is null.");
            }
            var ordersFromSubcontractor = await _context.OrdersFromSubcontractors.FindAsync(id);
            if (ordersFromSubcontractor != null)
            {
                _context.OrdersFromSubcontractors.Remove(ordersFromSubcontractor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdersFromSubcontractorExists(int id)
        {
          return (_context.OrdersFromSubcontractors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
