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
    public class StudentAssignment: Controller
    {
        private readonly ModelContext _context;

        public StudentAssignment(ModelContext context){
            _context = context;
        }

        public async Task<IActionResult> Index(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if(id == "Nope"){
                id = (await _context.ResultInfo.FromSqlRaw($"select * from result_info").ToListAsync())[0].StudentId;
            }
            ViewData["StudentId"] = new SelectList(_context.Student, "PersonId", "PersonId");
            ViewBag.student = (await _context.Student.FromSqlRaw($"select * from student where person_id= '{id}'").ToListAsync())[0];
            ViewBag.results = await _context.ResultInfo.FromSqlRaw($"select * from result_info where student_id='{id}'").ToListAsync();
            ViewBag.Student.Person = (await _context.Person.FromSqlRaw($"select * from person where person_id  = '{ViewBag.Student.PersonId}'").ToListAsync())[0];
            foreach (var result in ViewBag.results)
            {
                result.Assignment = (await _context.Assignment.FromSqlRaw($"select * from assignment where assignment_id= '{result.AssignmentId}'").ToListAsync())[0];
                result.Assignment.Module = (await _context.Module.FromSqlRaw($"select * from module where module_id= '{result.Assignment.ModuleId}'").ToListAsync())[0];
            }
            return View();
        }
    }
}