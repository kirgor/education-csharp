using MvcApplication2.Data;
using MvcApplication2.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Login(string email, string password)
        {
            try
            {
                var user = AuthHelper.Login(email, password);
                Session["User"] = user;
                DateTime expire = DateTime.Now.AddDays(2);
                Response.Cookies.Set(new HttpCookie("Email", email) { Expires = expire });
                Response.Cookies.Set(new HttpCookie("Password", password) { Expires = expire });
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            Session.Abandon();

            Response.SetCookie(new HttpCookie("Email") { Expires = new DateTime() });
            Response.SetCookie(new HttpCookie("Password") { Expires = new DateTime() });

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string email, string password, string passwordConfirm, string name, string lastName)
        {
            ViewBag.Email = email;
            ViewBag.Name = name;
            ViewBag.LastName = lastName;

            if (password != passwordConfirm)
            {
                ViewBag.Message = "Passwords do not match each other!";
                return View();
            }

            try
            {
                AuthHelper.Register(email, password, name, lastName);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View();
            }
        }
    }
}