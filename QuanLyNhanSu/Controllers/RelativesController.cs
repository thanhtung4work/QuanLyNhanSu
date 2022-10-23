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
    public class RelativesController : Controller
    {
        private readonly QuanLyNhanSuDbContext _context;

        public RelativesController(QuanLyNhanSuDbContext context)
        {
            _context = context;
        }

        // GET: Relatives
        public async Task<IActionResult> Index()
        {
            var quanLyNhanSuDbContext = _context.Relatives.Include(r => r.Employee);
            return View(await quanLyNhanSuDbContext.ToListAsync());
        }

        // GET: Relatives/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Relatives == null)
            {
                return NotFound();
            }

            var relative = await _context.Relatives
                .Include(r => r.Employee)
                .FirstOrDefaultAsync(m => m.RelativeId == id);
            if (relative == null)
            {
                return NotFound();
            }

            return View(relative);
        }

        // GET: Relatives/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "FirstName");
            return View();
        }

        // POST: Relatives/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RelativeId,EmployeeId,FirstName,LastName,Relationship,PhoneNo")] Relative relative)
        {
            if (ModelState.IsValid)
            {
                _context.Add(relative);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", relative.EmployeeId);
            return View(relative);
        }

        // GET: Relatives/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Relatives == null)
            {
                return NotFound();
            }

            var relative = await _context.Relatives.FindAsync(id);
            if (relative == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", relative.EmployeeId);
            return View(relative);
        }

        // POST: Relatives/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RelativeId,EmployeeId,FirstName,LastName,Relationship,PhoneNo")] Relative relative)
        {
            if (id != relative.RelativeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(relative);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RelativeExists(relative.RelativeId))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", relative.EmployeeId);
            return View(relative);
        }

        // GET: Relatives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Relatives == null)
            {
                return NotFound();
            }

            var relative = await _context.Relatives
                .Include(r => r.Employee)
                .FirstOrDefaultAsync(m => m.RelativeId == id);
            if (relative == null)
            {
                return NotFound();
            }

            return View(relative);
        }

        // POST: Relatives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Relatives == null)
            {
                return Problem("Entity set 'QuanLyNhanSuDbContext.Relatives'  is null.");
            }
            var relative = await _context.Relatives.FindAsync(id);
            if (relative != null)
            {
                _context.Relatives.Remove(relative);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RelativeExists(int id)
        {
          return _context.Relatives.Any(e => e.RelativeId == id);
        }
    }
}
