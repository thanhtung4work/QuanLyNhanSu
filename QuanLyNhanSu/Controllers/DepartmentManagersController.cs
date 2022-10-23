using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLyNhanSu.Entity;
using QuanLyNhanSu.Persistence;

namespace QuanLyNhanSu.Controllers
{
    public class DepartmentManagersController : Controller
    {
        private readonly QuanLyNhanSuDbContext _context;

        public DepartmentManagersController(QuanLyNhanSuDbContext context)
        {
            _context = context;
        }

        // GET: DepartmentManagers
        public async Task<IActionResult> Index()
        {
            var quanLyNhanSuDbContext = _context.DepartmentManagers.Include(d => d.Department).Include(d => d.Employee);
            return View(await quanLyNhanSuDbContext.ToListAsync());
        }

        // GET: DepartmentManagers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DepartmentManagers == null)
            {
                return NotFound();
            }

            var departmentManager = await _context.DepartmentManagers
                .Include(d => d.Department)
                .Include(d => d.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departmentManager == null)
            {
                return NotFound();
            }

            return View(departmentManager);
        }

        // GET: DepartmentManagers/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "Name");
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FirstName");
            return View();
        }

        // POST: DepartmentManagers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,DepartmentId,PromotionDate")] DepartmentManager departmentManager)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departmentManager);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentId", departmentManager.DepartmentId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", departmentManager.EmployeeId);
            return View(departmentManager);
        }

        // GET: DepartmentManagers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DepartmentManagers == null)
            {
                return NotFound();
            }

            var departmentManager = await _context.DepartmentManagers.FindAsync(id);
            if (departmentManager == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentId", departmentManager.DepartmentId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", departmentManager.EmployeeId);
            return View(departmentManager);
        }

        // POST: DepartmentManagers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,DepartmentId,PromotionDate")] DepartmentManager departmentManager)
        {
            if (id != departmentManager.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departmentManager);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentManagerExists(departmentManager.Id))
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
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentId", departmentManager.DepartmentId);
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", departmentManager.EmployeeId);
            return View(departmentManager);
        }

        // GET: DepartmentManagers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DepartmentManagers == null)
            {
                return NotFound();
            }

            var departmentManager = await _context.DepartmentManagers
                .Include(d => d.Department)
                .Include(d => d.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (departmentManager == null)
            {
                return NotFound();
            }

            return View(departmentManager);
        }

        // POST: DepartmentManagers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DepartmentManagers == null)
            {
                return Problem("Entity set 'QuanLyNhanSuDbContext.DepartmentManagers'  is null.");
            }
            var departmentManager = await _context.DepartmentManagers.FindAsync(id);
            if (departmentManager != null)
            {
                _context.DepartmentManagers.Remove(departmentManager);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentManagerExists(int id)
        {
          return _context.DepartmentManagers.Any(e => e.Id == id);
        }
    }
}
