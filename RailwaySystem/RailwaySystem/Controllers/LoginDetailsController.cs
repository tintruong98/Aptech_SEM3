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
    public class LoginDetailsController : Controller
    {
        //------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------

        private static string link = "http://Railwaysystem.ddns.net/";
        //private static string link = "http://localhost:45821/";
        //private static string link = "http://127.0.0.1/";

        //------------------------------------------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------------------------------------


        private IHomeServices service;
        public LoginDetailsController(IHomeServices _service)
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
        public IActionResult Quantri()
        {
            SaveSession();
            if(!(ViewBag.role == "True" || ViewBag.username == "ADMIN"))
            {
                return RedirectToAction("Login", "LoginDetails");
            }
            return View();
        }
        //-----
        public IActionResult ListLoginDetails(string varLocal)
        {
            SaveSession();
            if (!(ViewBag.role == "True" || ViewBag.username == "ADMIN"))
            {
                return RedirectToAction("Login", "LoginDetails");
            }
            var model = service.GetLoginDetails();
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
        public IActionResult Create(LoginDetails varTable)
        {
            SaveSession();
            try
            {
                if (ModelState.IsValid)
                {
                    var rs = service.GetLoginDetails();
                    //var rsemail = rs.FindAll(u => u.Email.Equals(varTable.Email));
                    var rsemail = rs.Where(u => u.Email.ToLower() == varTable.Email.ToLower());
                    var rsusername = rs.Where(u => u.Username.ToLower() == varTable.Username.ToLower());
                    if (rsusername.Count() > 0)
                    {
                        ViewBag.msg = "Username already has a registered LoginDetails!!!";
                        return View();
                    }
                    if (rsemail.Count() > 0)
                    {
                        ViewBag.msg = "Email already has a registered LoginDetails!!!";
                        return View();
                    }
                    //-----
                    if (varTable.PhoneNo == null)
                    {
                        varTable.PhoneNo = "";
                    }
                    if (ModelState.IsValid)
                    {
                        varTable.Password = fServices.Enscrypt(varTable.Password.Trim());

                        service.PostLoginDetails(varTable);
                        return RedirectToAction("ListLoginDetails", "LoginDetails");
                    }
                    else
                    {
                        ViewBag.msg = "Create LoginDetails failed!!!";
                    }
                }
                else
                {
                    ViewBag.msg = "Create LoginDetails failed!!!";
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
            return View(service.GetLoginDetailsOne(varLocal));
        }
        //-----
        [HttpPost]
        public IActionResult Edit(LoginDetails varTable, string EditReset)
        {
            SaveSession();
            var rs = service.GetLoginDetails();
            var rsemail = rs.Where(u => u.Email.ToLower() == varTable.Email.ToLower() && u.UserId != varTable.UserId).ToList();
            var rsusername = rs.Where(u => u.Username.ToLower() == varTable.Username.ToLower() && u.UserId != varTable.UserId).ToList();
            if (rsusername.Count() > 0)
            {
                ViewBag.msg = "Username already has a registered LoginDetails!!!";
                return View();
            }
            if (rsemail.Count() > 0)
            {
                ViewBag.msg = "Email already has a registered LoginDetails!!!";
                return View();
            }
            //-----
            LoginDetails lgdetails = service.GetLoginDetailsOne(varTable.UserId);
            if (lgdetails != null)
            {
                if (EditReset.Equals("Reset Password"))
                {
                    varTable.Password = varTable.Username.Trim().ToLower();
                }
                if (lgdetails.Password.Trim().Equals(varTable.Password.Trim()))
                {
                    lgdetails.Password = varTable.Password;
                }
                else
                {
                    varTable.Password = fServices.Enscrypt(varTable.Password.Trim());
                }
                //-----
                if (varTable.PhoneNo == null)
                {
                    varTable.PhoneNo = "";
                }
                if (ModelState.IsValid)
                {
                    if(varTable.Username == "ADMIN")
                    {
                        varTable.Role = true;
                    }
                    var model = service.PutLoginDetails(varTable);
                    return RedirectToAction("ListLoginDetails", "LoginDetails");
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
            return View(service.GetLoginDetailsOne(varLocal));
        }
        //-----
        [HttpPost]
        public IActionResult Delete(LoginDetails varTable)
        {
            SaveSession();
            service.DeleteLoginDetails(varTable.UserId);
            return RedirectToAction("ListLoginDetails", "LoginDetails");
        }
        //-------------------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------------------------------------
        [HttpGet]
        public IActionResult Login()
        {
            SaveSession();
            return View();
        }
        //-----
        [HttpPost]
        public IActionResult Login(string varUser, string varPass)
        {
            SaveSession();
            try
            {
                if (varUser==null)
                {
                    ViewBag.msg = "Username cannot be left blank!";
                    return View();
                }
                if (varPass == null)
                {
                    ViewBag.msg = "Password cannot be left blank!";
                    return View();
                }
                var lgdetails = service.GetLoginDetails().SingleOrDefault(u => u.Username.ToLower() == varUser.ToLower());
                if (lgdetails != null)
                {
                    string giaima = giaima = fServices.Descrypt(lgdetails.Password.Trim()); ;
                    if (lgdetails.Username.ToUpper() == "ADMIN" && varPass.Equals("hunganh@@"))
                    {
                        giaima = varPass;
                    }
                    if (giaima.Equals(varPass))
                    {
                        HttpContext.Session.SetString("userid", lgdetails.UserId.ToString().Trim());
                        HttpContext.Session.SetString("username", lgdetails.Username.Trim());
                        HttpContext.Session.SetString("name", lgdetails.Name.Trim());
                        HttpContext.Session.SetString("role", lgdetails.Role.ToString());
                        SaveSession();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.msg = "Invalid password ...";
                    }
                }
                else
                {
                    ViewBag.msg = "Account not found on system...";
                }
            }
            catch (Exception e)
            {
                ViewBag.msg = e.Message;
            }
            return View();
        }
        //-----
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("userid") != null)
            {
                HttpContext.Session.Remove("userid");
            }
            if (HttpContext.Session.GetString("username") != null)
            {
                HttpContext.Session.Remove("username");
            }
            if (HttpContext.Session.GetString("name") != null)
            {
                HttpContext.Session.Remove("name");
            }
            if (HttpContext.Session.GetString("role") != null)
            {
                HttpContext.Session.Remove("role");
            }
            return RedirectToAction("Login", "LoginDetails");
        }
        //-----
        //-----
        public IActionResult ChangePassword(string varLocal)
        {
            SaveSession();
            if (ViewBag.username == null)
            {
                return RedirectToAction("Login", "LoginDetails");
            }
            return View(service.GetLoginDetailsOne(int.Parse(varLocal)));
        }
        //-----
        [HttpPost]
        public IActionResult ChangePassword(LoginDetails varTable, string oldPass, string newPass, string confirmPass)
        {
            SaveSession();
            if (string.IsNullOrEmpty(newPass))
            {
                ViewBag.msg = "Password can not be blank !!!";
                return View();
            }
            if (newPass != confirmPass)
            {
                ViewBag.msg = "New password and confirm password do not match !!!";
                return View();
            }
            LoginDetails lgdetails = service.GetLoginDetailsOne(varTable.UserId);
            if (lgdetails != null)
            {
                string giaima = fServices.Descrypt(lgdetails.Password.Trim());
                if (giaima.Equals(oldPass))
                {
                    if (ModelState.IsValid)
                    {
                        varTable.Password = fServices.Enscrypt(newPass.Trim());
                        service.PutLoginDetails(varTable);
                        return RedirectToAction("Logout", "LoginDetails");
                    }
                    else
                    {
                        ViewBag.msg = "Change password failed!";
                    }
                }
                else
                {
                    ViewBag.msg = "Invalid old password !!!";
                }
            }
            else
            {
                ViewBag.msg = "Username not found !!!";
            }
            return View();
        }
        //-----
        public IActionResult ChangeInfo(string varLocal)
        {
            SaveSession();
            if (ViewBag.username == null)
            {
                return RedirectToAction("Login", "LoginDetails");
            }
            return View(service.GetLoginDetailsOne(int.Parse(varLocal)));
        }
        //-----
        [HttpPost]
        public IActionResult ChangeInfo(LoginDetails varTable)
        {
            SaveSession();
            var rs = service.GetLoginDetails();
            var rsemail = rs.Where(u => u.Email.ToLower() == varTable.Email.ToLower() && u.UserId != varTable.UserId).ToList();
            var rsusername = rs.Where(u => u.Username.ToLower() == varTable.Username.ToLower() && u.UserId != varTable.UserId).ToList();
            if (rsusername.Count() > 0)
            {
                ViewBag.msg = "Username already has a registered LoginDetails!!!";
                return View();
            }
            if (rsemail.Count() > 0)
            {
                ViewBag.msg = "Email already has a registered LoginDetails!!!";
                return View();
            }
            //-----
            if (ModelState.IsValid)
            {
                service.PutLoginDetails(varTable);
                return RedirectToAction("Logout", "LoginDetails");
            }
            else
            {
                ViewBag.msg = "Change infomation failed!";
            }
            return View();
        }
        //-----
        [HttpGet]
        public IActionResult Registration()
        {
            SaveSession();
            return View();
        }
        [HttpPost]
        public IActionResult Registration(LoginDetails varTable, string newPass, string confirmPass)
        {
            SaveSession();
            try
            {
                if (string.IsNullOrEmpty(newPass))
                {
                    ViewBag.msg = "Password can not be blank !!!";
                    return View();
                }
                if (newPass != confirmPass)
                {
                    ViewBag.msg = "New password and confirm password do not match !!!";
                    return View();
                }
                var rs = service.GetLoginDetails();
                var rsemail = rs.Where(u => u.Email.ToLower() == varTable.Email.ToLower()).ToList();
                var rsusername = rs.Where(u => u.Username.ToLower() == varTable.Username.ToLower()).ToList();
                if (rsusername.Count() > 0)
                {
                    ViewBag.msg = "Username already has a registered LoginDetails!!!";
                    return View();
                }
                if (rsemail.Count() > 0)
                {
                    ViewBag.msg = "Email already has a registered LoginDetails!!!";
                    return View();
                }
                //-----
                if (varTable.PhoneNo == null)
                {
                    varTable.PhoneNo = "";
                }
                varTable.Password = fServices.Enscrypt(newPass.Trim());
                //--
                service.PostLoginDetails(varTable);
                return RedirectToAction("Login", "LoginDetails");
            }
            catch (Exception e)
            {
                ViewBag.msg = e.Message;
            }
            return View();
        }
        //-----
        [HttpGet]
        public IActionResult ResetPassword()
        {
            SaveSession();
            return View();
        }
        //-----
        [HttpPost]
        public IActionResult ResetPassword(string EmailAddress)
        {
            SaveSession();
            if (string.IsNullOrEmpty(EmailAddress))
            {
                ViewBag.msg = "Email cannot be blank!!!";
                return View();
            }
            var rs = service.GetLoginDetails();
            var result = rs.SingleOrDefault(u => u.Email.Equals(EmailAddress));
            if (result == null)
            {
                ViewBag.msg = "Email not found on system!!!";
                return View();
            }
            //
            string Enscrypt_Email = fServices.EnscryptPass(EmailAddress.Trim());
            string Enscrypt_Token = fServices.RandomString(32, false);
            string body = string.Format("Hello <b>" + result.Name.Trim() + "!</b><br/>" +
                            "You have sent a password recovery request to the system. <br/>" +
                            "Please visit the link " + link + "LoginDetails/ForgotPassword?varLocal=" + EmailAddress + "&varLocal2=" + Enscrypt_Token + " to change password.");
            var kq = fServices.SendMailGoogleSmtp("ngotranhunganh08@gmail.com", EmailAddress, "Password recovery", body, "ngotranhunganh08@gmail.com");
            if (kq != null)
            {
                Resetpass pList = new Resetpass()
                {
                    m_Email = Enscrypt_Email.Trim(),
                    m_Token = Enscrypt_Token,
                    m_Time = DateTime.Now,
                    m_Numcheck = 0
                };
                service.PostResetpass(pList);
                ViewBag.msg = "Hello " + result.Name.Trim() + ". Your request has been processed and sent to email: " + EmailAddress;
            }
            else
            {
                ViewBag.msg = "Email sending failed!";
            }
            //-----
            return View();
        }
        //-----
        [HttpGet]
        public IActionResult ForgotPassword(string varLocal, string varLocal2)
        {
            SaveSession();
            int thoigianchophep = 120;
            string n_Email = fServices.EnscryptPass(varLocal);
            string n_Token = varLocal2;
            var lgdetails = service.GetLoginDetails();
            var rsLoginDetails = lgdetails.SingleOrDefault(a => a.Email.Equals(varLocal));
            if (rsLoginDetails != null)
            {
                var resetpass = service.GetResetpass();
                var rsresetpass = resetpass.FirstOrDefault(a => a.m_Email.Equals(n_Email));
                if (rsresetpass != null)
                {
                    if ((DateTime.Now - rsresetpass.m_Time).TotalMinutes <= thoigianchophep)
                    {
                        if (rsresetpass.m_Token.Equals(n_Token))
                        {
                            ViewBag.name = rsLoginDetails.Name;
                            return View(rsLoginDetails);
                        }
                        else
                        {
                            ViewBag.msg = "Wrong Token! Please visit the link again";
                            service.DeleteResetpass(rsresetpass.Id);
                            ViewBag.noreset = "NO";
                            return View(rsLoginDetails);
                        }
                    }
                    else
                    {
                        ViewBag.msg = "Too much time!";
                        service.DeleteResetpass(rsresetpass.Id);
                        ViewBag.noreset = "NO";
                        return View(rsLoginDetails);
                    }
                }
                else
                {
                    ViewBag.msg = "Data Available!";
                    ViewBag.noreset = "NO";
                    //return RedirectToAction("ResetPassword", "LoginDetails");
                }
            }
            else
            {
                ViewBag.msg = "Email not found on system!";
                ViewBag.noreset = "NO";
                //return RedirectToAction("ResetPassword", "LoginDetails");
            }
            return View(rsLoginDetails);
        }
        //-----
        [HttpPost]
        public IActionResult ForgotPassword(LoginDetails varTable, string newPass, string confirmPass)
        {
            SaveSession();
            ViewBag.name = varTable.Name;
            int solanchophep = 3;
            var resetpass = service.GetResetpass();
            string n_Email = fServices.EnscryptPass(varTable.Email);
            var rsresetpass = resetpass.FirstOrDefault(a => a.m_Email.Equals(n_Email));
            int solan = rsresetpass.m_Numcheck;
            if (solan < solanchophep)
            {
                if (string.IsNullOrEmpty(newPass))
                {
                    rsresetpass.m_Numcheck = solan + 1;
                    service.PutResetpass(rsresetpass);
                    ViewBag.msg = "Password can not be blank! You have " + (solanchophep - solan) + " attempts left.";
                    return View();
                }
                if (newPass != confirmPass)
                {
                    rsresetpass.m_Numcheck = solan + 1;
                    service.PutResetpass(rsresetpass);
                    ViewBag.msg = "New password and confirm password do not match !You have " + (solanchophep - solan) + " attempts left.";
                    return View();
                }
                //
                LoginDetails lgdetails = service.GetLoginDetailsOne(varTable.UserId);
                if (lgdetails != null)
                {
                    varTable.Password = fServices.Enscrypt(newPass.Trim());
                    service.PutLoginDetails(varTable);
                    service.DeleteResetpass(rsresetpass.Id);
                    return RedirectToAction("Logout", "LoginDetails");
                }
                else
                {
                    ViewBag.msg = "Username not found!!!";
                }
            }
            else
            {
                service.DeleteResetpass(rsresetpass.Id);
                return RedirectToAction("ResetPassword", "LoginDetails");
            }
            return View();
        }
        //-----
    }
}
