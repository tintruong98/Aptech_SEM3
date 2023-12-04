using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RailwaySystem.Models;
using RailwaySystem.Repository;
using RailwaySystem.Services;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace RailwaySystem.Controllers
{
    public class PriceDetailsController : Controller
    {
        private IHomeServices service;
        public PriceDetailsController(IHomeServices _service)
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
        public IActionResult ListPriceDetails(string varLocal)
        {
            SaveSession();
            if (!(ViewBag.role == "True" || ViewBag.username == "ADMIN"))
            {
                return RedirectToAction("Login", "LoginDetails");
            }
            var model = service.GetPriceDetails();
            if (varLocal != null)
            {
                model = model.FindAll(u => u.ClassName.Contains(varLocal));
            }
            return View(model);
        }
        //-----
        [HttpGet]
        public IActionResult Create()
        {
            SaveSession();
            return View();
        }
        [HttpPost]
        public IActionResult Create(PriceDetails varTable)
        {
            SaveSession();
            try
            {
                if (ModelState.IsValid)
                {
                    service.PostPriceDetails(varTable);
                    return RedirectToAction("ListPriceDetails", "PriceDetails");
                }
                else
                {
                    ViewBag.msg = "Create PriceDetails failed!!!";
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
            return View(service.GetPriceDetailsOne(varLocal));
        }
        //-----
        [HttpPost]
        public IActionResult Edit(PriceDetails varTable)
        {
            SaveSession();
            PriceDetails lgdetails = service.GetPriceDetailsOne(varTable.SeatCode);
            if (lgdetails != null)
            {
                if (ModelState.IsValid)
                {
                    var model = service.PutPriceDetails(varTable);
                    return RedirectToAction("ListPriceDetails", "PriceDetails");
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
            return View(service.GetPriceDetailsOne(varLocal));
        }
        //-----
        [HttpPost]
        public IActionResult Delete(PriceDetails varTable)
        {
            SaveSession();
            service.DeletePriceDetails(varTable.SeatCode);
            return RedirectToAction("ListPriceDetails", "PriceDetails");
        }
        //-----
    }
}


