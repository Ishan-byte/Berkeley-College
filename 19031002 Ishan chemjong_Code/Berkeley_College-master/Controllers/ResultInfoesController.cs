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
    public class ResultInfoesController : Controller
    {
        private readonly ModelContext _context;

        public ResultInfoesController(ModelContext context)
        {
            _context = context;
        }

        // GET: ResultInfoes
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.ResultInfo.Include(r => r.Assignment).Include(r => r.Student);
            return View(await modelContext.ToListAsync());
        }

        // GET: ResultInfoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultInfo = await _context.ResultInfo
                .Include(r => r.Assignment)
                .Include(r => r.Student)
                .FirstOrDefaultAsync(m => m.ResultId == id);
            if (resultInfo == null)
            {
                return NotFound();
            }

            return View(resultInfo);
        }

        // GET: ResultInfoes/Create
        public IActionResult Create()
        {
            ViewData["AssignmentId"] = new SelectList(_context.Assignment, "AssignmentId", "AssignmentId");
            ViewData["StudentId"] = new SelectList(_context.Student, "PersonId", "PersonId");
            return View();
        }

        // POST: ResultInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResultId,AssignmentId,Grade,Status,StudentId")] ResultInfo resultInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resultInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssignmentId"] = new SelectList(_context.Assignment, "AssignmentId", "AssignmentId", resultInfo.AssignmentId);
            ViewData["StudentId"] = new SelectList(_context.Student, "PersonId", "PersonId", resultInfo.StudentId);
            return View(resultInfo);
        }

        // GET: ResultInfoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultInfo = await _context.ResultInfo.FindAsync(id);
            if (resultInfo == null)
            {
                return NotFound();
            }
            ViewData["AssignmentId"] = new SelectList(_context.Assignment, "AssignmentId", "AssignmentId", resultInfo.AssignmentId);
            ViewData["StudentId"] = new SelectList(_context.Student, "PersonId", "PersonId", resultInfo.StudentId);
            return View(resultInfo);
        }

        // POST: ResultInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ResultId,AssignmentId,Grade,Status,StudentId")] ResultInfo resultInfo)
        {
            if (id != resultInfo.ResultId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resultInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResultInfoExists(resultInfo.ResultId))
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
            ViewData["AssignmentId"] = new SelectList(_context.Assignment, "AssignmentId", "AssignmentId", resultInfo.AssignmentId);
            ViewData["StudentId"] = new SelectList(_context.Student, "PersonId", "PersonId", resultInfo.StudentId);
            return View(resultInfo);
        }

        // GET: ResultInfoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultInfo = await _context.ResultInfo
                .Include(r => r.Assignment)
                .Include(r => r.Student)
                .FirstOrDefaultAsync(m => m.ResultId == id);
            if (resultInfo == null)
            {
                return NotFound();
            }

            return View(resultInfo);
        }

        // POST: ResultInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var resultInfo = await _context.ResultInfo.FindAsync(id);
            _context.ResultInfo.Remove(resultInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResultInfoExists(string id)
        {
            return _context.ResultInfo.Any(e => e.ResultId == id);
        }
    }
}
