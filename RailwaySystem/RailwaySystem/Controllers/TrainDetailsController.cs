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
    public class TrainDetailsController : Controller
    {
        private IHomeServices service;
        public TrainDetailsController(IHomeServices _service)
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
        public IActionResult ListTrainDetails(string varLocal)
        {
            SaveSession();
            if (!(ViewBag.role == "True" || ViewBag.username == "ADMIN"))
            {
                return RedirectToAction("Login", "LoginDetails");
            }
            var model = service.GetTrainDetails();
            if (varLocal != null)
            {
                model = model.FindAll(u => u.TrainName.Contains(varLocal));
            }
            return View(model);
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
        public IActionResult Create(TrainDetails varTable)
        {
            SaveSession();
            var listarr = service.GetStationArr();
            ViewBag.arr = new SelectList(listarr, "StationCode", "StationName");

            var listdep = service.GetStationDep();
            ViewBag.dep = new SelectList(listdep, "StationCode", "StationName");

            try
            {
                if ((varTable.Departure - DateTime.Now).TotalHours <= 5)
                {
                    ViewBag.msg = "Departure date must be 5 hours greater than or equal to the current date!";
                    return View();
                }
                var kt = service.GetTrainDetails().Where(k => k.Source.Equals(varTable.Source)
                                && k.Destination.Equals(varTable.Destination)
                                && k.Departure == varTable.Departure);
                if (kt.Count() > 0)
                {
                    ViewBag.msg = "Duplicate data!";
                    return View();
                }
                varTable.Status = true;
                if (varTable.FirstClass + varTable.SecondClass + varTable.ThirdClass + varTable.SleepRoom + varTable.General > 64)
                {
                    ViewBag.msg = "Total number of seats for a car larger than 64!";
                    return View();
                }
                if (varTable.FirstClass + varTable.SecondClass + varTable.ThirdClass + varTable.SleepRoom + varTable.General == 0)
                {
                    ViewBag.msg = "Total number of seats must be greater than 0!";
                    return View();
                }
                if (varTable.Source == varTable.Destination)
                {
                    ViewBag.msg = "Source can't same Destination!";
                    return View();
                }
                if (ModelState.IsValid)
                {
                    service.PostTrainDetails(varTable);

                    var listseatcode = service.GetPriceDetails();
                    var listdisprice = service.GetDisprice().FirstOrDefault(d => (d.Source.Equals(varTable.Source) && d.Destination.Equals(varTable.Destination)) || (d.Source.Equals(varTable.Destination) && d.Destination.Equals(varTable.Source)));

                    SeatDiagram seatDiagram;
                    for (int i = 1; i <= varTable.NoOfCompartment; i++)
                    {
                        foreach (var item in listseatcode)
                        {
                            if (item.SeatCode == "1AC")
                            {
                                for (int j = 1; j <= varTable.FirstClass; j++)
                                {
                                    seatDiagram = new SeatDiagram();
                                    seatDiagram.TrainNo = varTable.TrainNo;
                                    seatDiagram.Compartment = i;
                                    seatDiagram.SeatCode = item.SeatCode;
                                    seatDiagram.SeatOrder = j;
                                    seatDiagram.Price = item.Price + listdisprice.Price;
                                    seatDiagram.UserId = 0;
                                    seatDiagram.Status = true;
                                    service.PostSeatDiagram(seatDiagram);
                                }
                            }
                            if (item.SeatCode == "2AC")
                            {
                                for (int j = 1; j <= varTable.SecondClass; j++)
                                {
                                    seatDiagram = new SeatDiagram();
                                    seatDiagram.TrainNo = varTable.TrainNo;
                                    seatDiagram.Compartment = i;
                                    seatDiagram.SeatCode = item.SeatCode;
                                    seatDiagram.SeatOrder = j;
                                    seatDiagram.Price = item.Price + listdisprice.Price;
                                    seatDiagram.UserId = 0;
                                    seatDiagram.Status = true;
                                    service.PostSeatDiagram(seatDiagram);
                                }
                            }
                            if (item.SeatCode == "3AC")
                            {
                                for (int j = 1; j <= varTable.ThirdClass; j++)
                                {
                                    seatDiagram = new SeatDiagram();
                                    seatDiagram.TrainNo = varTable.TrainNo;
                                    seatDiagram.Compartment = i;
                                    seatDiagram.SeatCode = item.SeatCode;
                                    seatDiagram.SeatOrder = j;
                                    seatDiagram.Price = item.Price + listdisprice.Price;
                                    seatDiagram.UserId = 0;
                                    seatDiagram.Status = true;
                                    service.PostSeatDiagram(seatDiagram);
                                }
                            }
                            if (item.SeatCode == "SLE")
                            {
                                for (int j = 1; j <= varTable.SleepRoom; j++)
                                {
                                    seatDiagram = new SeatDiagram();
                                    seatDiagram.TrainNo = varTable.TrainNo;
                                    seatDiagram.Compartment = i;
                                    seatDiagram.SeatCode = item.SeatCode;
                                    seatDiagram.SeatOrder = j;
                                    seatDiagram.Price = item.Price + listdisprice.Price;
                                    seatDiagram.UserId = 0;
                                    seatDiagram.Status = true;
                                    service.PostSeatDiagram(seatDiagram);
                                }
                            }
                            if (item.SeatCode == "GNE")
                            {
                                for (int j = 1; j <= varTable.General; j++)
                                {
                                    seatDiagram = new SeatDiagram();
                                    seatDiagram.TrainNo = varTable.TrainNo;
                                    seatDiagram.Compartment = i;
                                    seatDiagram.SeatCode = item.SeatCode;
                                    seatDiagram.SeatOrder = j;
                                    seatDiagram.Price = item.Price + listdisprice.Price;
                                    seatDiagram.UserId = 0;
                                    seatDiagram.Status = true;
                                    service.PostSeatDiagram(seatDiagram);
                                }
                            }
                        }
                    }
                    return RedirectToAction("ListTrainDetails", "TrainDetails");
                }
                else
                {
                    ViewBag.msg = "Create TrainDetails failed!!!";
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

            return View(service.GetTrainDetailsOne(varLocal));
        }
        //-----
        [HttpPost]
        public IActionResult Edit(TrainDetails varTable)
        {
            SaveSession();
            var listarr = service.GetStationArr();
            ViewBag.arr = new SelectList(listarr, "StationCode", "StationName");

            var listdep = service.GetStationDep();
            ViewBag.dep = new SelectList(listdep, "StationCode", "StationName");
            try
            {
                var kt = service.GetTrainDetails().Where(k => k.Source.Equals(varTable.Source)
                    && k.Destination.Equals(varTable.Destination)
                    && k.Departure == varTable.Departure && k.TrainNo != varTable.TrainNo);
                if (kt.Count() > 0)
                {
                    ViewBag.msg = "Duplicate data!";
                    return View();
                }

                if (varTable.Source == varTable.Destination)
                {
                    ViewBag.msg = "Source can't same Destination!";
                    return View(varTable);
                }
                TrainDetails lgdetails = service.GetTrainDetailsOne(varTable.TrainNo);
                if (lgdetails != null)
                {
                    if (ModelState.IsValid)
                    {
                        var model = service.PutTrainDetails(varTable);
                        return RedirectToAction("ListTrainDetails", "TrainDetails");
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
            }
            catch (Exception e)
            {
                ViewBag.msg = e.Message;
            }
            return View();
        }
        //-----
        public IActionResult Delete(int varLocal)
        {
            SaveSession();
            return View(service.GetTrainDetailsOne(varLocal));
        }
        //-----
        [HttpPost]
        public IActionResult Delete(TrainDetails varTable)
        {
            SaveSession();
            service.DeleteTrainDetails(varTable.TrainNo);
            return RedirectToAction("ListTrainDetails", "TrainDetails");
        }
        //-----
        public IActionResult Details(int varLocal)
        {
            SaveSession();
            var sg = service.GetSeatDiagram().Where(s => s.TrainNo == varLocal);

            var m1ac = sg.Where(s => s.SeatCode.Equals("1AC"));
            var m1acB = m1ac.Where(s => s.SeatCode.Equals("1AC") && s.Status == true && s.UserId == 0);

            var m2ac = sg.Where(s => s.SeatCode.Equals("2AC"));
            var m2acB = m2ac.Where(s => s.SeatCode.Equals("2AC") && s.Status == true && s.UserId == 0);

            var m3ac = sg.Where(s => s.SeatCode.Equals("3AC"));
            var m3acB = m3ac.Where(s => s.SeatCode.Equals("3AC") && s.Status == true && s.UserId == 0);

            var msle = sg.Where(s => s.SeatCode.Equals("SLE"));
            var msleB = msle.Where(s => s.SeatCode.Equals("SLE") && s.Status == true && s.UserId == 0);

            var mgne = sg.Where(s => s.SeatCode.Equals("GNE"));
            var mgneB = mgne.Where(s => s.SeatCode.Equals("GNE") && s.Status == true && s.UserId == 0);

            ViewBag.m1ac = m1acB.Count().ToString() + "/" + m1ac.Count().ToString() + " seats left";
            ViewBag.m2ac = m2acB.Count().ToString() + "/" + m2ac.Count().ToString() + " seats left";
            ViewBag.m3ac = m3acB.Count().ToString() + "/" + m3ac.Count().ToString() + " seats left";
            ViewBag.msle = msleB.Count().ToString() + "/" + msle.Count().ToString() + " seats left";
            ViewBag.mgne = mgneB.Count().ToString() + "/" + mgne.Count().ToString() + " seats left";

            return View(service.GetTrainDetailsOne(varLocal));
        }
        //-----



    }
}
