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
    public class TeachersModulesController : Controller
    {
        private readonly ModelContext _context;

        public TeachersModulesController(ModelContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string id)
        {
            if (id == "Nope")
            {
                id = (await _context.Teacher.ToListAsync())[0].PersonId;
            }
            ViewData["TeacherId"] = new SelectList(_context.Teacher, "PersonId", "PersonId");
            ViewBag.Teacher = (await _context.Teacher.FromSqlRaw($"select * from teacher where person_id= '{id}'").ToListAsync())[0];
            ViewBag.Modules = await _context.Module.FromSqlRaw($"select * from module where module_id in (select module_id from teacher_module_info where teacher_id ='{id}')").ToListAsync();
            ViewBag.Teacher.Person = (await _context.Person.FromSqlRaw($"select * from person where person_id  = '{ViewBag.Teacher.PersonId}'").ToListAsync())[0];
            return View();
        }
    }
}
