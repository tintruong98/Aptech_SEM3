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
    public class StationArrController : Controller
    {
        private IHomeServices service;
        public StationArrController(IHomeServices _service)
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
        public IActionResult ListStationArr()
        {
            SaveSession();
            if (!(ViewBag.role == "True" || ViewBag.username == "ADMIN"))
            {
                return RedirectToAction("Login", "LoginDetails");
            }
            return View(service.GetStationArr());
        }
        //-----
        [HttpGet]
        public IActionResult Create()
        {
            SaveSession();
            return View();
        }
        [HttpPost]
        public IActionResult Create(StationArr varTable)
        {
            SaveSession();
            try
            {
                if (ModelState.IsValid)
                {
                    service.PostStationArr(varTable);
                    return RedirectToAction("ListStationArr", "StationArr");
                }
                else
                {
                    ViewBag.msg = "Create StationArr failed!!!";
                }
            }
            catch (Exception e)
            {
                ViewBag.msg = e.Message;
            }
            return View();
        }
        //-----
        public IActionResult Edit(string varLocal)
        {
            SaveSession();
            return View(service.GetStationArrOne(varLocal));
        }
        //-----
        [HttpPost]
        public IActionResult Edit(StationArr varTable)
        {
            SaveSession();
            StationArr lgdetails = service.GetStationArrOne(varTable.StationCode);
            if (lgdetails != null)
            {
                if (ModelState.IsValid)
                {
                    var model = service.PutStationArr(varTable);
                    return RedirectToAction("ListStationArr", "StationArr");
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
        public IActionResult Delete(string varLocal)
        {
            SaveSession();
            return View(service.GetStationArrOne(varLocal));
        }
        //-----
        [HttpPost]
        public IActionResult Delete(StationArr varTable)
        {
            SaveSession();
            service.DeleteStationArr(varTable.StationCode);
            return RedirectToAction("ListStationArr", "StationArr");
        }
        //-----
    }
}
