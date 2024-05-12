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
    public class ResponsibilityInTheProjectsController : Controller
    {
        private readonly Information_System_Of_The_Project_OrganizationContext _context;

        public ResponsibilityInTheProjectsController(Information_System_Of_The_Project_OrganizationContext context)
        {
            _context = context;
        }

        // GET: ResponsibilityInTheProjects
        public async Task<IActionResult> Index()
        {
              return _context.ResponsibilityInTheProjects != null ? 
                          View(await _context.ResponsibilityInTheProjects.ToListAsync()) :
                          Problem("Entity set 'Information_System_Of_The_Project_OrganizationContext.ResponsibilityInTheProjects'  is null.");
        }

        // GET: ResponsibilityInTheProjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ResponsibilityInTheProjects == null)
            {
                return NotFound();
            }

            var responsibilityInTheProject = await _context.ResponsibilityInTheProjects
                .FirstOrDefaultAsync(m => m.Id == id);
            if (responsibilityInTheProject == null)
            {
                return NotFound();
            }

            return View(responsibilityInTheProject);
        }

        // GET: ResponsibilityInTheProjects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ResponsibilityInTheProjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ResponsibilityName")] ResponsibilityInTheProject responsibilityInTheProject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(responsibilityInTheProject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(responsibilityInTheProject);
        }

        // GET: ResponsibilityInTheProjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ResponsibilityInTheProjects == null)
            {
                return NotFound();
            }

            var responsibilityInTheProject = await _context.ResponsibilityInTheProjects.FindAsync(id);
            if (responsibilityInTheProject == null)
            {
                return NotFound();
            }
            return View(responsibilityInTheProject);
        }

        // POST: ResponsibilityInTheProjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ResponsibilityName")] ResponsibilityInTheProject responsibilityInTheProject)
        {
            if (id != responsibilityInTheProject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(responsibilityInTheProject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResponsibilityInTheProjectExists(responsibilityInTheProject.Id))
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
            return View(responsibilityInTheProject);
        }

        // GET: ResponsibilityInTheProjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ResponsibilityInTheProjects == null)
            {
                return NotFound();
            }

            var responsibilityInTheProject = await _context.ResponsibilityInTheProjects
                .FirstOrDefaultAsync(m => m.Id == id);
            if (responsibilityInTheProject == null)
            {
                return NotFound();
            }

            return View(responsibilityInTheProject);
        }

        // POST: ResponsibilityInTheProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ResponsibilityInTheProjects == null)
            {
                return Problem("Entity set 'Information_System_Of_The_Project_OrganizationContext.ResponsibilityInTheProjects'  is null.");
            }
            var responsibilityInTheProject = await _context.ResponsibilityInTheProjects.FindAsync(id);
            if (responsibilityInTheProject != null)
            {
                _context.ResponsibilityInTheProjects.Remove(responsibilityInTheProject);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResponsibilityInTheProjectExists(int id)
        {
          return (_context.ResponsibilityInTheProjects?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
