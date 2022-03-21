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
    public class StudentPaymentController : Controller
    {
        private readonly ModelContext _context;

        public StudentPaymentController(ModelContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if(id == "Nope"){
                id = (await _context.StudentFeePayment.FromSqlRaw($"select * from student_fee_payment").ToListAsync())[0].StudentId;
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "PersonId", "PersonId");
            ViewBag.student = (await _context.Student.FromSqlRaw($"select * from student where person_id= '{id}'").ToListAsync())[0];
            ViewBag.payments = await _context.StudentFeePayment.FromSqlRaw($"select * from student_fee_payment where student_id='{id}'").ToListAsync();
            return View();
        }
    }
}
