using berkeley_college.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace berkeley_college.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ModelContext _context;

        public HomeController(ModelContext context, ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> IndexAsync()
        {
            List<DataPoint> dataPoints = new List<DataPoint>();

            var modules = await _context.Module.FromSqlRaw($"select * from module").ToListAsync();

            foreach(var module in modules){
                int x = (await _context.ModuleStudent.FromSqlRaw($"select * from module_student where module_id = '{module.ModuleId}'").ToListAsync()).Count;
                dataPoints.Add(new DataPoint { X = x, Y = module.ModuleName});
            }

            ViewBag.ChartTitle = "Number of student in on each module";
            ViewBag.ChartSubTitle = "";
            ViewBag.ChartType = "pie";
            String j = JsonConvert.SerializeObject(dataPoints);
			ViewBag.DataPoints = j;



            //Chart 2

            List<DataPoint> dataPoints2 = new List<DataPoint>();

            string[] ts = new string[4] { "A", "B", "C","D"};

            for (int i = 0; i < 4; i++)
            {
                string y = ts[i] ;
                int x = (await _context.ResultInfo.FromSqlRaw($"select * from result_info where grade = '{ts[i]}'").ToListAsync()).Count;
                dataPoints2.Add(new DataPoint { X = x, Y = y });
            }

            ViewBag.ChartTitle2 = "Number of students in each grade";
            ViewBag.ChartSubTitle2 = "X = grade, Y = number of students with that grade";
            ViewBag.ChartType2 = "area";
            String j2 = JsonConvert.SerializeObject(dataPoints2);
			ViewBag.DataPoints2 = j2;

            
            //Chart 3
            List<DataPoint> dataPoints3 = new List<DataPoint>();

            foreach(var module in modules){
                int x = (await _context.StudentAttendenceInfo.FromSqlRaw($"select * from student_attendence_info where module_id = '{module.ModuleId}'").ToListAsync()).Count;
                dataPoints3.Add(new DataPoint { X = x, Y = module.ModuleName});
            }

            ViewBag.ChartTitle3 = "Number of attendance in each Module";
            ViewBag.ChartSubTitle3 = "X = name of module , Y = number of attendance in the module";
            ViewBag.ChartType3 = "area";
            String j3 = JsonConvert.SerializeObject(dataPoints3);
			ViewBag.DataPoints3 = j3;


            return View("~/Views/Charts/Index.cshtml");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
