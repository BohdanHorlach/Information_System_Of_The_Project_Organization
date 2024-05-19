using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Information_System_Of_The_Project_Organization.Models;


namespace Information_System_Of_The_Project_Organization.Controllers
{
    public class PactProjectsController : Controller
    {
        private readonly Information_System_Of_The_Project_OrganizationContext _context;

        public PactProjectsController(Information_System_Of_The_Project_OrganizationContext context)
        {
            _context = context;
        }

        // GET: PactProjects
        public async Task<IActionResult> Index()
        {
              return _context.PactProjects != null ? 
                          View(await _context.PactProjects.ToListAsync()) :
                          Problem("Entity set 'Information_System_Of_The_Project_OrganizationContext.PactProjects'  is null.");
        }


        public async Task<IActionResult> GetProjectsFromPacts(string pactName)
        {
            List<ProjectsFromPacts> projects = await _context.ProjectsFromPacts.FromSqlInterpolated($"EXEC GetProjectsFromPacts {pactName}").ToListAsync();

            return View("GetProjectsFromPacts", projects);
        }


        public async Task<IActionResult> GetTotalCostFromPacts(DateTime startDate, DateTime endDate)
        {
            DateTime? startDateToProcedure = startDate == DateTime.MinValue ? null : startDate;
            DateTime? endDateToProcedure = endDate == DateTime.MinValue ? null : endDate;

            List<TotalCostFromPacts> costInfo = await _context.TotalCostFromPacts.FromSqlInterpolated($"EXEC GetTotalCostFromPacts {startDateToProcedure}, {endDateToProcedure}").ToListAsync();

            return View("GetTotalCostFromPacts", costInfo);
        }


        // GET: PactProjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PactProjects == null)
            {
                return NotFound();
            }

            var pactProject = await _context.PactProjects
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pactProject == null)
            {
                return NotFound();
            }

            return View(pactProject);
        }

        // GET: PactProjects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PactProjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdPact,IdProject")] PactProject pactProject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pactProject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pactProject);
        }

        // GET: PactProjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PactProjects == null)
            {
                return NotFound();
            }

            var pactProject = await _context.PactProjects.FindAsync(id);
            if (pactProject == null)
            {
                return NotFound();
            }
            return View(pactProject);
        }

        // POST: PactProjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdPact,IdProject")] PactProject pactProject)
        {
            if (id != pactProject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pactProject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PactProjectExists(pactProject.Id))
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
            return View(pactProject);
        }

        // GET: PactProjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PactProjects == null)
            {
                return NotFound();
            }

            var pactProject = await _context.PactProjects
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pactProject == null)
            {
                return NotFound();
            }

            return View(pactProject);
        }

        // POST: PactProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PactProjects == null)
            {
                return Problem("Entity set 'Information_System_Of_The_Project_OrganizationContext.PactProjects'  is null.");
            }
            var pactProject = await _context.PactProjects.FindAsync(id);
            if (pactProject != null)
            {
                _context.PactProjects.Remove(pactProject);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PactProjectExists(int id)
        {
          return (_context.PactProjects?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
