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
    public class ProjectParticipantsController : Controller
    {
        private readonly QuanLyNhanSuDbContext _context;

        public ProjectParticipantsController(QuanLyNhanSuDbContext context)
        {
            _context = context;
        }

        // GET: ProjectParticipants
        public async Task<IActionResult> Index()
        {
            var quanLyNhanSuDbContext = _context.ProjectParticipants.Include(p => p.Employee).Include(p => p.Project);
            return View(await quanLyNhanSuDbContext.ToListAsync());
        }

        // GET: ProjectParticipants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProjectParticipants == null)
            {
                return NotFound();
            }

            var projectParticipant = await _context.ProjectParticipants
                .Include(p => p.Employee)
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (projectParticipant == null)
            {
                return NotFound();
            }

            return View(projectParticipant);
        }

        // GET: ProjectParticipants/Create
        public IActionResult Create()
        {
            ViewData["ProjectId"] = new SelectList(_context.Employees, "Id", "FirstName");
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectName");
            return View();
        }

        // POST: ProjectParticipants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProjectId,EmployeeId")] ProjectParticipant projectParticipant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectParticipant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProjectId"] = new SelectList(_context.Employees, "Id", "Id", projectParticipant.ProjectId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", projectParticipant.ProjectId);
            return View(projectParticipant);
        }

        // GET: ProjectParticipants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProjectParticipants == null)
            {
                return NotFound();
            }

            var projectParticipant = await _context.ProjectParticipants.FindAsync(id);
            if (projectParticipant == null)
            {
                return NotFound();
            }
            ViewData["ProjectId"] = new SelectList(_context.Employees, "Id", "Id", projectParticipant.ProjectId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", projectParticipant.ProjectId);
            return View(projectParticipant);
        }

        // POST: ProjectParticipants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProjectId,EmployeeId")] ProjectParticipant projectParticipant)
        {
            if (id != projectParticipant.ProjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectParticipant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectParticipantExists(projectParticipant.ProjectId))
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
            ViewData["ProjectId"] = new SelectList(_context.Employees, "Id", "Id", projectParticipant.ProjectId);
            ViewData["ProjectId"] = new SelectList(_context.Projects, "ProjectId", "ProjectId", projectParticipant.ProjectId);
            return View(projectParticipant);
        }

        // GET: ProjectParticipants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProjectParticipants == null)
            {
                return NotFound();
            }

            var projectParticipant = await _context.ProjectParticipants
                .Include(p => p.Employee)
                .Include(p => p.Project)
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (projectParticipant == null)
            {
                return NotFound();
            }

            return View(projectParticipant);
        }

        // POST: ProjectParticipants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProjectParticipants == null)
            {
                return Problem("Entity set 'QuanLyNhanSuDbContext.ProjectParticipants'  is null.");
            }
            var projectParticipant = await _context.ProjectParticipants.FindAsync(id);
            if (projectParticipant != null)
            {
                _context.ProjectParticipants.Remove(projectParticipant);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectParticipantExists(int id)
        {
          return _context.ProjectParticipants.Any(e => e.ProjectId == id);
        }
    }
}
