using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Reporting_HO.Models;

namespace Reporting_HO.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
        [HttpPost]
        public ActionResult Index(PersonModel person)
        {
            string reportingTme = person.Report_Date.TimeOfDay.ToString("hh");
            string path = Directory.GetCurrentDirectory();
            string dtRep = person.Report_Date.Date.ToString("yyyyMMdd");
            string paramBat = dtRep + reportingTme + "00";
           
             Process proc = new Process();
             proc.StartInfo.WorkingDirectory = path;

               
            if(person.Report_Time=="Input")
            {
                proc.StartInfo.FileName = "input.bat";
                proc.StartInfo.Arguments = " " + paramBat;
            }
                
            else
            {
                proc.StartInfo.FileName = "output.bat";
                proc.StartInfo.Arguments = " " + paramBat;
            }
                
            proc.StartInfo.CreateNoWindow = false;
            proc.Start();
             proc.WaitForExit();
              
          
          
           // System.IO.StreamWriter SW = new System.IO.StreamWriter(@"C:\Log\test.bat");
            

           

            return View();
        }
    }
}
