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
    public class StudentFeePaymentsController : Controller
    {
        private readonly ModelContext _context;

        public StudentFeePaymentsController(ModelContext context)
        {
            _context = context;
        }

        // GET: StudentFeePayments
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.StudentFeePayment.Include(s => s.Department).Include(s => s.Student);
            return View(await modelContext.ToListAsync());
        }

        // GET: StudentFeePayments/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentFeePayment = await _context.StudentFeePayment
                .Include(s => s.Department)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.PaymentId == id);
            if (studentFeePayment == null)
            {
                return NotFound();
            }

            return View(studentFeePayment);
        }

        // GET: StudentFeePayments/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentId");
            ViewData["StudentId"] = new SelectList(_context.Student, "PersonId", "PersonId");
            return View();
        }

        // POST: StudentFeePayments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaymentId,Amount,Year,PaymentDate,StudentId,DepartmentId")] StudentFeePayment studentFeePayment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentFeePayment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentId", studentFeePayment.DepartmentId);
            ViewData["StudentId"] = new SelectList(_context.Student, "PersonId", "PersonId", studentFeePayment.StudentId);
            return View(studentFeePayment);
        }

        // GET: StudentFeePayments/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentFeePayment = await _context.StudentFeePayment.FindAsync(id);
            if (studentFeePayment == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentId", studentFeePayment.DepartmentId);
            ViewData["StudentId"] = new SelectList(_context.Student, "PersonId", "PersonId", studentFeePayment.StudentId);
            return View(studentFeePayment);
        }

        // POST: StudentFeePayments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PaymentId,Amount,Year,PaymentDate,StudentId,DepartmentId")] StudentFeePayment studentFeePayment)
        {
            if (id != studentFeePayment.PaymentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentFeePayment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentFeePaymentExists(studentFeePayment.PaymentId))
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
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentId", studentFeePayment.DepartmentId);
            ViewData["StudentId"] = new SelectList(_context.Student, "PersonId", "PersonId", studentFeePayment.StudentId);
            return View(studentFeePayment);
        }

        // GET: StudentFeePayments/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentFeePayment = await _context.StudentFeePayment
                .Include(s => s.Department)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.PaymentId == id);
            if (studentFeePayment == null)
            {
                return NotFound();
            }

            return View(studentFeePayment);
        }

        // POST: StudentFeePayments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var studentFeePayment = await _context.StudentFeePayment.FindAsync(id);
            _context.StudentFeePayment.Remove(studentFeePayment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentFeePaymentExists(string id)
        {
            return _context.StudentFeePayment.Any(e => e.PaymentId == id);
        }
    }
}
