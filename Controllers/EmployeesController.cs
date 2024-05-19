using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Information_System_Of_The_Project_Organization.Models;


namespace Information_System_Of_The_Project_Organization.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly Information_System_Of_The_Project_OrganizationContext _context;

        public EmployeesController(Information_System_Of_The_Project_OrganizationContext context)
        {
            _context = context;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
              return _context.Employees != null ? 
                          View(await _context.Employees.ToListAsync()) :
                          Problem("Entity set 'Information_System_Of_The_Project_OrganizationContext.Employees'  is null.");
        }

        // GET: Employees/GetEmployeeData
        public async Task<IActionResult> GetEmployeeDataByParams(string category, string department)
        {
            List<Employee> employees;

            if (department == "" || department == null)
                employees = await _context.Employees.FromSqlInterpolated($"EXEC GetEmployeeDataByCategory {category}").ToListAsync();
            else
                employees = await _context.Employees.FromSqlInterpolated($"EXEC GetEmployeeDataByCategory {category}, {department}").ToListAsync();

            return View("GetEmployeesDataByParams", employees);
        }


        // GET: Employees/GetAllDepartmentsLeaders
        public async Task<IActionResult> GetAllDepartmentsLeaders()
        {
            List<Employee> employees = await _context.Employees.FromSqlRaw("EXEC GetAllDepartmentsLeaders").ToListAsync();

            return View("Index", employees);
        }


        public async Task<IActionResult> GetEmployeesInfoToProjectsActivities(int employeeId, string category, DateTime appointmentDate, DateTime dismissalDate)
        {
            int? employeeIDToProcedure = employeeId == 0 ? null : employeeId;
            string? caterotyToProcedure = category == "" ? null : category;
            DateTime? firstDate = appointmentDate == DateTime.MinValue ? null : appointmentDate;
            DateTime? secondDate = dismissalDate == DateTime.MinValue ? null : dismissalDate;

            List<EmployeesInfoToProjectsActivities> projectsActivities = await _context.EmployeesInfoToProjectsActivities.FromSqlInterpolated($"EXEC GetEmployeesInfoToProjectsActivities {employeeIDToProcedure}, {caterotyToProcedure}, {firstDate}, {secondDate}").ToListAsync();

            return View("GetEmployeesInfoToProjectsActivities", projectsActivities);
        }


        public async Task<IActionResult> GetCountEmployeesByCategoryFromProject(string nameProject)
        {
            List<CountEmployeesByCategoryFromProject> countEmployeesInfo = await _context.CountEmployeesByCategoryFromProject.FromSqlInterpolated($"EXEC GetCountEmployeesByCategoryFromProject {nameProject}").ToListAsync();

            return View("GetCountEmployeesByCategoryFromProject", countEmployeesInfo);
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,MiddleName,LastName,Age,Education")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,MiddleName,LastName,Age,Education")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
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
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Employees == null)
            {
                return Problem("Entity set 'Information_System_Of_The_Project_OrganizationContext.Employees'  is null.");
            }
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
          return (_context.Employees?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
