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
    public class StatisticsController : Controller
    {
        private IHomeServices service;
        public StatisticsController(IHomeServices _service)
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

        public IActionResult SeatStatistics(DateTime FromDate, DateTime ToDate)
        {
            SaveSession();
            if (!(ViewBag.role == "True" || ViewBag.username == "ADMIN"))
            {
                return RedirectToAction("Login", "LoginDetails");
            }
            if (FromDate.Date > ToDate.Date)
            {
                ToDate = FromDate;
            }
            if (FromDate.Year <= 1900 && ToDate.Year <= 1900)
            {
                FromDate = DateTime.Now.Date;
                ToDate = DateTime.Now.Date;
            }
            if (FromDate.Year > 1900 && ToDate.Year <= 1900)
            {
                ToDate = FromDate;
            }
            if (FromDate.Year <= 1900 && ToDate.Year > 1900)
            {
                FromDate = ToDate;
            }
            ViewBag.FromDate = FromDate.ToShortDateString();
            ViewBag.ToDate = ToDate.ToShortDateString();

            var pricedetails = service.GetPriceDetails();
            var model = service.GetPassengerDetails().Where(d => d.BookingDate.Date >= FromDate && d.BookingDate.Date <= ToDate).ToList();

            var to = (from pr in model
                      select new { SeatCode = pr.SeatCode.Substring(0, 3), PriceTotal = pr.Price }).ToList();

            var toa = (from pr in to
                       join fr in pricedetails
                       on pr.SeatCode equals fr.SeatCode
                       select new { SeatCode = pr.SeatCode, ClassName = fr.ClassName, SeatsTotal = 1, PriceTotal = pr.PriceTotal }).ToList();

            //var ta = toa
            //    .GroupBy(a => a.SeatCode)
            //    .Select(a => new { SeatCode = a.Key, ClassName = a.SingleOrDefault().ClassName, SeatsTotal = a.Sum(s => s.SeatsTotal), PriceTotal = a.Sum(s => s.PriceTotal) })
            //    .ToList();

            foreach (var item in pricedetails)
            {
                if (item.SeatCode == "1AC")
                {
                    ViewBag.D1AC = item.SeatCode;
                    ViewBag.C1AC = item.ClassName;
                }
                if (item.SeatCode == "2AC")
                {
                    ViewBag.D2AC = item.SeatCode;
                    ViewBag.C2AC = item.ClassName;
                }
                if (item.SeatCode == "3AC")
                {
                    ViewBag.D3AC = item.SeatCode;
                    ViewBag.C3AC = item.ClassName;
                }
                if (item.SeatCode == "SLE")
                {
                    ViewBag.DSLE = item.SeatCode;
                    ViewBag.CSLE = item.ClassName;
                }
                if (item.SeatCode == "GNE")
                {
                    ViewBag.DGNE = item.SeatCode;
                    ViewBag.CGNE = item.ClassName;
                }

            }


            //ViewBag.D1AC = "1AC";
            //ViewBag.D2AC = "2AC";
            //ViewBag.D3AC = "3AC";
            //ViewBag.DSLE = "SLE";
            //ViewBag.DGNE = "GNE";

            //ViewBag.C1AC = "FirstClass";
            //ViewBag.C2AC = "SecondClass";
            //ViewBag.C3AC = "ThirdClass";
            //ViewBag.CSLE = "SleepRoom";
            //ViewBag.CGNE = "Generral";

            ViewBag.S1AC = to.Where(w => w.SeatCode == "1AC").Count();
            ViewBag.S2AC = to.Where(w => w.SeatCode == "2AC").Count();
            ViewBag.S3AC = to.Where(w => w.SeatCode == "3AC").Count();
            ViewBag.SSLE = to.Where(w => w.SeatCode == "SLE").Count();
            ViewBag.SGNE = to.Where(w => w.SeatCode == "GNE").Count();

            ViewBag.P1AC = to.Where(w => w.SeatCode == "1AC").Sum(s => s.PriceTotal);
            ViewBag.P2AC = to.Where(w => w.SeatCode == "2AC").Sum(s => s.PriceTotal);
            ViewBag.P3AC = to.Where(w => w.SeatCode == "3AC").Sum(s => s.PriceTotal);
            ViewBag.PSLE = to.Where(w => w.SeatCode == "SLE").Sum(s => s.PriceTotal);
            ViewBag.PGNE = to.Where(w => w.SeatCode == "GNE").Sum(s => s.PriceTotal);

            //-----
            var totalSeats = new TotalSeats[]
            {
                new TotalSeats { SeatCode = ViewBag.D1AC, ClassName = ViewBag.C1AC, SeatsTotal = ViewBag.S1AC, PriceTotal = ViewBag.P1AC },
                new TotalSeats { SeatCode = ViewBag.D2AC, ClassName = ViewBag.C2AC, SeatsTotal = ViewBag.S2AC, PriceTotal = ViewBag.P2AC },
                new TotalSeats { SeatCode = ViewBag.D3AC, ClassName = ViewBag.C3AC, SeatsTotal = ViewBag.S3AC, PriceTotal = ViewBag.P3AC },
                new TotalSeats { SeatCode = ViewBag.DSLE, ClassName = ViewBag.CSLE, SeatsTotal = ViewBag.SSLE, PriceTotal = ViewBag.PSLE },
                new TotalSeats { SeatCode = ViewBag.DGNE, ClassName = ViewBag.CGNE, SeatsTotal = ViewBag.SGNE, PriceTotal = ViewBag.PGNE }
            };

            ViewBag.sum = Convert.ToInt32(totalSeats.Sum(s => s.PriceTotal)).ToString("#,##0.00") ;

            return View(totalSeats);
        }
    }
}
