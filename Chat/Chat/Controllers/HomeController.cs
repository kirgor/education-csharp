using MvcApplication2.Data;
using MvcApplication2.Helpers;
using MvcApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var emailCookie = Request.Cookies["Email"];
            var passwordCookie = Request.Cookies["Password"];
            if (emailCookie != null && passwordCookie != null)
            {
                try
                {
                    Session["User"] = AuthHelper.Login(emailCookie.Value, passwordCookie.Value);
                }
                catch { }
            }

            using (var context = new ChatEntities())
            {
                var messages =
                    context.Messages
                    .OrderByDescending(m => m.Time)
                    .Take(5)
                    .ToArray();
                ViewBag.Messages = messages.Select(m => new MessageModel(m)).ToList();
                ViewBag.Messages.Reverse();
            }

            return View();
        }
    }
}