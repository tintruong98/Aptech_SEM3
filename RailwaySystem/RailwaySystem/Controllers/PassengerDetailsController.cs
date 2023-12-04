using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RailwaySystem.Models;
using RailwaySystem.Repository;
using RailwaySystem.Services;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwaySystem.Controllers
{
    public class PassengerDetailsController : Controller
    {
        //------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------

        private static string link = "http://Railwaysystem.ddns.net/";
        //private static string link = "http://localhost:45821/";
        //private static string link = "http://127.0.0.1/";

        //------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------


        //-----
        private IHomeServices service;
        public PassengerDetailsController(IHomeServices _service)
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
        public IActionResult ListPassengerDetails(string varLocal)
        {
            SaveSession();
            if (!(ViewBag.role == "True" || ViewBag.username == "ADMIN"))
            {
                return RedirectToAction("Login", "LoginDetails");
            }
            var model = service.GetPassengerDetails();
            if (varLocal != null)
            {
                model = model.FindAll(u => u.Name.Contains(varLocal));
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
        public IActionResult Create(PassengerDetails varTable)
        {
            SaveSession();
            try
            {
                if (varTable.PhoneNo == null)
                {
                    varTable.PhoneNo = "";
                }
                if (varTable.Source == null)
                {
                    varTable.Source = "";
                }
                if (varTable.Destination == null)
                {
                    varTable.Destination = "";
                }
                if (varTable.Email == null)
                {
                    varTable.Email = "";
                }
                if (ModelState.IsValid)
                {
                    varTable.BookingDate = DateTime.Now;
                    service.PostPassengerDetails(varTable);
                    return RedirectToAction("ListPassengerDetails", "PassengerDetails");
                }
                else
                {
                    ViewBag.msg = "Create PassengerDetails failed!!!";
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
            return View(service.GetPassengerDetailsOne(varLocal));
        }
        //-----
        [HttpPost]
        public IActionResult Edit(PassengerDetails varTable)
        {
            SaveSession();
            try
            {
                if (varTable.PhoneNo == null)
                {
                    varTable.PhoneNo = "";
                }
                if (varTable.Source == null)
                {
                    varTable.Source = "";
                }
                if (varTable.Destination == null)
                {
                    varTable.Destination = "";
                }
                if (varTable.Email == null)
                {
                    varTable.Email = "";
                }
                PassengerDetails lgdetails = service.GetPassengerDetailsOne(varTable.PNR);
                if (lgdetails != null)
                {
                    if (ModelState.IsValid)
                    {
                        var model = service.PutPassengerDetails(varTable);
                        return RedirectToAction("ListPassengerDetails", "PassengerDetails");
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
            return View(service.GetPassengerDetailsOne(varLocal));
        }
        //-----
        [HttpPost]
        public IActionResult Delete(PassengerDetails varTable)
        {
            SaveSession();
            service.DeletePassengerDetails(varTable.PNR);
            return RedirectToAction("ListPassengerDetails", "PassengerDetails");
        }
        //-----
        public IActionResult FindTrainList(string varLocal, string varLocal2, DateTime departure)
        {
            SaveSession();
            ViewBag.source = varLocal;
            ViewBag.destination = varLocal2;
            ViewBag.departure = departure.Date;

            var listarr = service.GetStationArr();
            ViewBag.arr = new SelectList(listarr, "StationCode", "StationName");

            var listdep = service.GetStationDep();
            ViewBag.dep = new SelectList(listdep, "StationCode", "StationName");

            if (ViewBag.userid!=null)
            {
                int ticketbuy = service.GetPassengerDetails().Where(u => u.UserID == int.Parse(ViewBag.userid) && (u.Departure - DateTime.Now).TotalMinutes > 0).Count();
                if (ticketbuy>0)
                {
                    ViewBag.ticketbuy = ticketbuy;
                }
            }

            var model = service.GetTrainDetails().Where(t => t.Status == true && t.Departure.Date >= DateTime.Now.Date);

            if (varLocal == varLocal2 && varLocal != null && !varLocal.Contains("Choose your") && varLocal2 != null && !varLocal2.Contains("Choose your"))
            {
                ViewBag.msg = "Source can't same Destination!";
                return View(service.GetTrainDetails().Where(pr => pr.TrainNo == 0));
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
        //-----
        public IActionResult FindTrainDetails(int varLocal)
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
        public IActionResult FindSeat(int varLocal, int varLocal2)
        {
            SaveSession();
            ViewBag.trainno = varLocal;
            ViewBag.compartment = varLocal2;

            var tr = service.GetTrainDetailsOne(varLocal);
            ViewBag.source = tr.Source;
            ViewBag.destination = tr.Destination;
            ViewBag.departure = tr.Departure.Date;

            var rs = service.GetSeatDiagram();
            var model = rs.Where(k => k.TrainNo == varLocal && k.Compartment == varLocal2).ToList();
            return View(model);
        }
        //-----
        public IActionResult SetSeat(int id, int trainno, int compartment, string seatcode, int seatorder, decimal price,int userid, bool status)
        {
            SaveSession();
            var tr = service.GetTrainDetailsOne(trainno);
            ViewBag.source = tr.Source;
            ViewBag.destination = tr.Destination;
            ViewBag.departure = tr.Departure.Date;

            SeatDiagram model = new SeatDiagram()
            {
                Id = id,
                TrainNo = trainno,
                Compartment = compartment,
                SeatCode = seatcode,
                SeatOrder = seatorder,
                Price = price,
                UserId = userid,
                Status = status
            };
            service.PutSeatDiagram(model);
            return RedirectToAction("FindSeat", "PassengerDetails", new { varLocal = trainno, varLocal2 = compartment });
        }
        //-----
        public IActionResult BuyTicket(int varLocal, int varLocal2,int payment)
        {
            SaveSession();
            ViewBag.trainno = varLocal;
            ViewBag.compartment = varLocal2;

            var tr = service.GetTrainDetailsOne(varLocal);
            ViewBag.source = tr.Source;
            ViewBag.destination = tr.Destination;
            ViewBag.departure = tr.Departure.Date;
            ViewBag.trainname = tr.TrainName;

            var ur = service.GetLoginDetailsOne(int.Parse(ViewBag.userid));

            ViewBag.name = ur.Name;
            ViewBag.gender = (ur.Gender==true)?"Male":"Female";
            ViewBag.phone = ur.PhoneNo;
            ViewBag.email = ur.Email;

            var rs = service.GetSeatDiagram();
            var model = rs.Where(k => k.TrainNo.Equals(varLocal) && k.UserId.Equals(int.Parse(ViewBag.userid)) && k.Status==true).ToList();
            decimal sum = 0;
            foreach (var item in model)
            {
                sum = sum + item.Price;
            }
            ViewBag.sum = sum.ToString("#,##0.00");
            if (model.Count()>4)
            {
                ViewBag.msg = "Each account is only allowed to choose a maximum of 4 seats!";
                return View(model);
            }
            if (model.Count() <=0)
            {
                ViewBag.msg = "Choose at least one seat!";
                return View(model);
            }
            if (payment==1)
            {
                ViewBag.ok = "OK";
                //
                PassengerDetails passengerDetails;
                SeatDiagram seatDiagram;
                foreach (var item in model)
                {
                    passengerDetails = new PassengerDetails()
                    {
                        UserID = item.UserId,
                        Name = ur.Name,
                        Gender = ur.Gender,
                        PhoneNo = ur.PhoneNo,
                        Email = ur.Email,
                        Source = tr.Source,
                        Destination = tr.Destination,
                        Departure = tr.Departure,
                        TrainNo = item.TrainNo,
                        Compartment = item.Compartment,
                        SeatCode = item.SeatCode + item.SeatOrder.ToString(),
                        Price = item.Price,
                        BookingDate = DateTime.Now
                    };
                    service.PostPassengerDetails(passengerDetails);
                    //
                    seatDiagram = new SeatDiagram()
                    {
                        Id = item.Id,
                        TrainNo = item.TrainNo,
                        Compartment = item.Compartment,
                        SeatCode = item.SeatCode,
                        SeatOrder = item.SeatOrder,
                        Price = item.Price,
                        UserId = item.UserId,
                        Status = false
                    };
                    service.PutSeatDiagram(seatDiagram);
                }
                DateTime bd = DateTime.Now;
                while (true)
                {
                    if ((DateTime.Now - bd).TotalSeconds >3)
                    {
                        break;
                    }
                }
                string body = string.Format("Hello <b>" + ur.Name + "!</b><br/>" +
                                "Rail System is pleased to announce,<br/>"+
                                "You have paid for train tickets with the amount of " +ViewBag.sum+" VND.<br/>" +
                                "Thank you for using our service");
                var kq = fServices.SendMailGoogleSmtp("ngotranhunganh08@gmail.com", ur.Email, "Pay for train tickets.", body, "ngotranhunganh08@gmail.com");
            }
            return View(model);
        }
        //-----
        public IActionResult PrintTickets(int varLocal,string dow,string varLocal2)
        {
            SaveSession();
            ViewBag.dow = dow;
            if (ViewBag.username == null)
            {
                return RedirectToAction("Login", "LoginDetails");
            }
            var ps = service.GetPassengerDetails().OrderByDescending(p=>p.Departure);
            var pas = ps.Where(p => p.UserID == varLocal);
            if (varLocal2!=null)
            {
                pas = pas.Where(p => p.PNR.Equals(int.Parse(varLocal2)) || p.TrainNo.Equals(int.Parse(varLocal2)));
            }
            return View(pas);
        }
        //-----
        public IActionResult CancelTickets(int varLocal,string varLocal2)
        {
            SaveSession();
            if (ViewBag.username == null)
            {
                return RedirectToAction("Login", "LoginDetails");
            }
            var ps = service.GetPassengerDetails().OrderByDescending(p => p.Departure);
            var pas = ps.Where(p => p.UserID == varLocal);
            if (varLocal2 != null)
            {
                pas = pas.Where(p => p.PNR.Equals(int.Parse(varLocal2)) || p.TrainNo.Equals(int.Parse(varLocal2)));
            }
            return View(pas);
        }
        //-----
        public IActionResult DeleteTickets(int varLocal)
        {
            SaveSession();
            var model = service.GetPassengerDetailsOne(varLocal);
            var tr = service.GetTrainDetails().Where(t => t.Status == true && t.TrainNo == model.TrainNo);
            if (tr.Count() <= 0)
            {
                ViewBag.msg = "The ticket cannot be canceled because the train has already departed";
                return View(model);
            }
            if ((model.Departure - DateTime.Now).TotalHours < 4)
            {
                ViewBag.msg = "Tickets cannot be canceled because it is close to the departure train (<4 hours)";
                return View(model);
            }
            return View(model);
        }
        //-----
        [HttpPost]
        public IActionResult DeleteTickets(PassengerDetails varTable)
        {
            SaveSession();
            service.DeletePassengerDetails(varTable.PNR);

            var seatDiagram = service.GetSeatDiagram().FirstOrDefault(s => s.TrainNo == varTable.TrainNo
            && s.Compartment == varTable.Compartment
            && s.SeatCode + s.SeatOrder.ToString() == varTable.SeatCode
            && s.UserId == varTable.UserID);

            seatDiagram.UserId = 0;
            seatDiagram.Status = true;
            service.PutSeatDiagram(seatDiagram);
            return RedirectToAction("CancelTickets", "PassengerDetails", new { varLocal = ViewBag.userid });
        }
        //-----
        public IActionResult PrintQRCode(int varLocal)
        {
            SaveSession();
            var model = service.GetPassengerDetailsOne(varLocal);
            var tr = service.GetTrainDetailsOne(model.TrainNo);
            ViewBag.trainname = tr.TrainName;
            ViewBag.gender = (model.Gender == true) ? "Male" : "Female";
            ViewBag.stringcode = model.Name + "," +
                ViewBag.gender + "," +
                model.PhoneNo + "," +
                model.Email + "," +
                ViewBag.trainname + "," +
                model.Source + "," +
                model.Destination + "," +
                model.Departure + "," +
                model.Compartment + "," +
                model.SeatCode + "," +
                model.Price;
            //
            string body = string.Format("Hello <b>" + model.Name.Trim() + "!</b><br/>" +
                            "Railway system has sent you the train ticket link. <br/>" +
                            link + "PassengerDetails/PrintQRCode?varLocal=" + model.PNR);
            var kq = fServices.SendMailGoogleSmtp("ngotranhunganh08@gmail.com", model.Email, "Ticket information", body, "ngotranhunganh08@gmail.com");
            return View(model);
        }
        //-----
        public IActionResult ExportToPdf(string varLocal)
        {
            SaveSession();
            HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter();
            WebKitConverterSettings settings = new WebKitConverterSettings();
            settings.WebKitPath = Path.Combine("", "QtBinariesWindows");
            htmlConverter.ConverterSettings = settings;
            PdfDocument document = htmlConverter.Convert(link + "PassengerDetails/PrintQRCode?varLocal=" + varLocal);

            //MemoryStream stream = new MemoryStream();
            //document.Save(stream);
            //return File(stream.ToArray(), System.Net.Mime.MediaTypeNames.Application.Pdf, "Ticket_Railway.pdf");

            string FolderPath = "wwwroot/RailwaySystem";
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
            }
            ViewBag.dow = "Ticket_Railway.pdf";
            string PathFile = FolderPath + "/" + ViewBag.dow;
            if (System.IO.File.Exists(PathFile))
            {
                System.IO.File.Delete(PathFile);
            }
            FileStream fileStream = new FileStream(PathFile, FileMode.CreateNew, FileAccess.ReadWrite);
            document.Save(fileStream);
            fileStream.Close();
            document.Close(true);
            return RedirectToAction("PrintTickets", "PassengerDetails", new { varLocal = ViewBag.userid, dow = ViewBag.dow });
        }
        //-----
        public IActionResult ViewFilePDF()
        {
            SaveSession();
            return View();
        }
        //-----
    }
}
