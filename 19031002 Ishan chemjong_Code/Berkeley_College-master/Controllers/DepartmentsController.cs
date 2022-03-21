using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using berkeley_college.Models;

namespace berkeley_college.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly ModelContext _context;

        public DepartmentsController(ModelContext context)
        {
            _context = context;
        }

        // GET: Departments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Departments.ToListAsync());
        }

        // GET: Departments/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departments = await _context.Departments
                .FirstOrDefaultAsync(m => m.DepartmentId == id);
            if (departments == null)
            {
                return NotFound();
            }

            return View(departments);
        }

        // GET: Departments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepartmentId,DepartmentName")] Departments departments)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departments);
        }

        // GET: Departments/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departments = await _context.Departments.FindAsync(id);
            if (departments == null)
            {
                return NotFound();
            }
            return View(departments);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("DepartmentId,DepartmentName")] Departments departments)
        {
            if (id != departments.DepartmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(departments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentsExists(departments.DepartmentId))
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
            return View(departments);
        }

        // GET: Departments/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departments = await _context.Departments
                .FirstOrDefaultAsync(m => m.DepartmentId == id);
            if (departments == null)
            {
                return NotFound();
            }

            return View(departments);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var departments = await _context.Departments.FindAsync(id);
            _context.Departments.Remove(departments);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentsExists(string id)
        {
            return _context.Departments.Any(e => e.DepartmentId == id);
        }
    }
}
