using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using RailwaySystem.Models;
using RailwaySystem.Repository;

namespace RailwaySystem.Controllers
{
    public class HomeController : Controller
    {
        private IHomeServices service;
        public HomeController(IHomeServices _service)
        {
            service = _service;
        }
        //-----
        public void SaveSession()
        {
            Services.FServices fServices = new Services.FServices();
            if (HttpContext.Session.GetString("name") != null)
            {
                ViewBag.name = HttpContext.Session.GetString("name");
            }
            if (HttpContext.Session.GetString("username") != null)
            {
                ViewBag.username = HttpContext.Session.GetString("username");
            }
            if (HttpContext.Session.GetString("role") != null)
            {
                ViewBag.role = HttpContext.Session.GetString("role");
            }
            if (HttpContext.Session.GetString("userid") != null)
            {
                ViewBag.userid = HttpContext.Session.GetString("userid");
            }
            //-----
            StreamReader sr = new StreamReader("wwwroot/Visitor.txt");
            int cnt = 0;
            string cnt_ = sr.ReadToEnd().Trim();
            cnt = int.Parse(cnt_);
            sr.Close();
            ViewData["count"] = cnt;
            if (HttpContext.Session.GetString("visitor") == null)
            {
                HttpContext.Session.SetString("visitor", cnt_);
                cnt++;
                StreamWriter sw = new StreamWriter("wwwroot/Visitor.txt");
                sw.Write(cnt);
                sw.Flush();
                sw.Close();
                ViewData["count"] = cnt;
            }
            ViewData["Date"] = fServices.NamThangNgay();
        }
        //-----
        public IActionResult Index(string varLocal, string varLocal2,DateTime departure)
        {
            SaveSession();
            var listarr = service.GetStationArr();
            ViewBag.arr = new SelectList(listarr, "StationCode", "StationName");

            var listdep = service.GetStationDep();
            ViewBag.dep = new SelectList(listdep, "StationCode", "StationName");

            var model = service.GetTrainDetails().Where(t=>t.Status==true && t.Departure.Date>=DateTime.Now.Date);

            if (varLocal == varLocal2 && varLocal != null && !varLocal.Contains("Choose your") && varLocal2 != null && !varLocal2.Contains("Choose your"))
            {
                ViewBag.msg = "Source can't same Destination!";
                return View(service.GetTrainDetails().Where(pr=>pr.TrainNo==0));
            }

            if (departure.Year >= DateTime.Now.Year)
            {
                if (varLocal != null && !varLocal.Contains("Choose your") && (varLocal2 == null || varLocal2.Contains("Choose your")))
                {
                    model = model.Where(pr => pr.Source.Contains(varLocal) && pr.Departure.Date == departure.Date).ToList();
                }
                if ((varLocal == null || varLocal.Contains("Choose your")) && varLocal2 != null && !varLocal2.Contains("Choose your"))
                {
                    model = model.Where(pr => pr.Destination.Contains(varLocal2) && pr.Departure.Date == departure.Date).ToList();
                }
                if (varLocal != null && !varLocal.Contains("Choose your") && varLocal2 != null && !varLocal2.Contains("Choose your"))
                {
                    model = model.Where(pr => pr.Source.Contains(varLocal) && pr.Destination.Contains(varLocal2) && pr.Departure.Date == departure.Date).ToList();
                }
                if (varLocal == null || varLocal.Contains("Choose your") && (varLocal2 == null || varLocal2.Contains("Choose your")))
                {
                    model = model.Where(pr => pr.Departure.Date == departure.Date).ToList();
                }
            }
            else
            {
                if (varLocal != null && !varLocal.Contains("Choose your") && (varLocal2 == null || varLocal2.Contains("Choose your")))
                {
                    model = model.Where(pr => pr.Source.Contains(varLocal)).ToList();
                }
                if ((varLocal == null || varLocal.Contains("Choose your")) && varLocal2 != null && !varLocal2.Contains("Choose your"))
                {
                    model = model.Where(pr => pr.Destination.Contains(varLocal2)).ToList();
                }
                if (varLocal != null && !varLocal.Contains("Choose your") && varLocal2 != null && !varLocal2.Contains("Choose your"))
                {
                    model = model.Where(pr => pr.Source.Contains(varLocal) && pr.Destination.Contains(varLocal2)).ToList();
                }
            }
            return View(model);
        }

        //--------------------------------------------------------------------------------------------------------------------
        public IActionResult Privacy()
        {
            SaveSession();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult contact()
        {
            SaveSession();
            return View();
        }
    }
}
