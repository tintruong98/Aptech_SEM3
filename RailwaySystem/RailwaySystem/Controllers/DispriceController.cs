using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RailwaySystem.Models;
using RailwaySystem.Repository;
using RailwaySystem.Services;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace RailwaySystem.Controllers
{
    public class DispriceController : Controller
    {
        private IHomeServices service;
        public DispriceController(IHomeServices _service)
        {
            this.service = _service;
        }
        //-----
        FServices fServices = new FServices();
        //-----
        public void SaveSession()
        {
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
        public IActionResult ListDisprice()
        {
            SaveSession();
            if (!(ViewBag.role == "True" || ViewBag.username == "ADMIN"))
            {
                return RedirectToAction("Login", "LoginDetails");
            }
            return View(service.GetDisprice());
        }
        //-----
        [HttpGet]
        public IActionResult Create()
        {
            SaveSession();
            var listarr = service.GetStationArr();
            ViewBag.arr = new SelectList(listarr, "StationCode", "StationName");

            var listdep = service.GetStationDep();
            ViewBag.dep = new SelectList(listdep, "StationCode", "StationName");

            return View();
        }
        [HttpPost]
        public IActionResult Create(Disprice varTable)
        {
            SaveSession();
            var listarr = service.GetStationArr();
            ViewBag.arr = new SelectList(listarr, "StationCode", "StationName");

            var listdep = service.GetStationDep();
            ViewBag.dep = new SelectList(listdep, "StationCode", "StationName");
            try
            {
                if (ModelState.IsValid)
                {
                    if (varTable.Source == varTable.Destination)
                    {
                        ViewBag.msg = "Source can't same Destination!";
                        return View();
                    }

                    service.PostDisprice(varTable);
                    return RedirectToAction("ListDisprice", "Disprice");
                }
                else
                {
                    ViewBag.msg = "Create Disprice failed!!!";
                }
            }
            catch (Exception e)
            {
                ViewBag.msg = e.Message;
            }
            return View();
        }
        //-----
        public IActionResult Edit(int varLocal)
        {
            SaveSession();
            var listarr = service.GetStationArr();
            ViewBag.arr = new SelectList(listarr, "StationCode", "StationName");

            var listdep = service.GetStationDep();
            ViewBag.dep = new SelectList(listdep, "StationCode", "StationName");

            return View(service.GetDispriceOne(varLocal));
        }
        //-----
        [HttpPost]
        public IActionResult Edit(Disprice varTable)
        {
            SaveSession();
            var listarr = service.GetStationArr();
            ViewBag.arr = new SelectList(listarr, "StationCode", "StationName");

            var listdep = service.GetStationDep();
            ViewBag.dep = new SelectList(listdep, "StationCode", "StationName");

            if (varTable.Source == varTable.Destination)
            {
                ViewBag.msg = "Source can't same Destination!";
                return View();
            }

            Disprice lgdetails = service.GetDispriceOne(varTable.Id);
            if (lgdetails != null)
            {
                if (ModelState.IsValid)
                {
                    var model = service.PutDisprice(varTable);
                    return RedirectToAction("ListDisprice", "Disprice");
                }
                else
                {
                    ViewBag.msg = "Update failed!";
                }
            }
            else
            {
                ViewBag.msg = "Update failed !!!";
            }
            return View();
        }
        //-----
        public IActionResult Delete(int varLocal)
        {
            SaveSession();
            return View(service.GetDispriceOne(varLocal));
        }
        //-----
        [HttpPost]
        public IActionResult Delete(Disprice varTable)
        {
            SaveSession();
            service.DeleteDisprice(varTable.Id);
            return RedirectToAction("ListDisprice", "Disprice");
        }
        //-----
    }
}
