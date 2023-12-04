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
    public class SeatDiagramController : Controller
    {
        private IHomeServices service;
        public SeatDiagramController(IHomeServices _service)
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
        public IActionResult ListSeatDiagram()
        {
            SaveSession();
            if (!(ViewBag.role == "True" || ViewBag.username == "ADMIN"))
            {
                return RedirectToAction("Login", "LoginDetails");
            }
            return View(service.GetSeatDiagram());
        }
        //-----
        [HttpGet]
        public IActionResult Create()
        {
            SaveSession();
            var listarr = service.GetPriceDetails();
            ViewBag.seatcode = new SelectList(listarr, "SeatCode", "ClassName");

            var listtrain = service.GetTrainDetails();
            ViewBag.train = new SelectList(listtrain, "TrainNo", "TrainName");


            return View();
        }
        [HttpPost]
        public IActionResult Create(SeatDiagram varTable)
        {
            SaveSession();
            var listarr = service.GetPriceDetails();
            ViewBag.seatcode = new SelectList(listarr, "SeatCode", "ClassName");

            var listtrain = service.GetTrainDetails();
            ViewBag.train = new SelectList(listtrain, "TrainNo", "TrainName");

            try
            {
                var kt = service.GetSeatDiagram().Where(k => k.TrainNo.Equals(varTable.TrainNo)
                    && k.Compartment.Equals(varTable.Compartment)
                    && k.SeatCode.Equals(varTable.SeatCode)
                    && k.SeatOrder.Equals(varTable.SeatOrder));
                if (kt.Count()>0)
                {
                    ViewBag.msg = "Duplicate data!";
                    return View();
                }
                if (ModelState.IsValid)
                {
                    varTable.UserId = 0;
                    varTable.Status = true;
                    service.PostSeatDiagram(varTable);
                    return RedirectToAction("ListSeatDiagram", "SeatDiagram");
                }
                else
                {
                    ViewBag.msg = "Create SeatDiagram failed!!!";
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
            var listarr = service.GetPriceDetails();
            ViewBag.seatcode = new SelectList(listarr, "SeatCode", "ClassName");
            var listtrain = service.GetTrainDetails();
            ViewBag.train = new SelectList(listtrain, "TrainNo", "TrainName");
            return View(service.GetSeatDiagramOne(varLocal));
        }
        //-----
        [HttpPost]
        public IActionResult Edit(SeatDiagram varTable)
        {
            SaveSession();
            var listarr = service.GetPriceDetails();
            ViewBag.seatcode = new SelectList(listarr, "SeatCode", "ClassName");
            var listtrain = service.GetTrainDetails();
            ViewBag.train = new SelectList(listtrain, "TrainNo", "TrainName");

            var kt = service.GetSeatDiagram().Where(k => k.TrainNo.Equals(varTable.TrainNo)
                 && k.Compartment.Equals(varTable.Compartment)
                 && k.SeatCode.Equals(varTable.SeatCode)
                 && k.SeatOrder.Equals(varTable.SeatOrder) 
                 && k.Id!=varTable.Id);
            if (kt.Count() > 0)
            {
                ViewBag.msg = "Duplicate data!";
                return View(varTable);
            }
            SeatDiagram lgdetails = service.GetSeatDiagramOne(varTable.Id);
            if (lgdetails != null)
            {
                if (ModelState.IsValid)
                {
                    var model = service.PutSeatDiagram(varTable);
                    return RedirectToAction("ListSeatDiagram", "SeatDiagram");
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
            return View(service.GetSeatDiagramOne(varLocal));
        }
        //-----
        [HttpPost]
        public IActionResult Delete(SeatDiagram varTable)
        {
            SaveSession();
            service.DeleteSeatDiagram(varTable.Id);
            return RedirectToAction("ListSeatDiagram", "SeatDiagram");
        }
        //-----
    }
}
