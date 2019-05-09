using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RpgApp_Logic;
using RpgApp_Model;
using RpgApp.Models.ViewModels;

namespace RpgApp.Controllers
{
    public class LoginController : Controller
    {
        Login l = new Login();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginCheck(User user)
        {
            GlobalViewModel gvm = new GlobalViewModel();

            User loginCheck = l.GetLoginCheck(user);

            if (loginCheck != null)
            {
                Session["user"] = loginCheck;

                return RedirectToAction("Index", "Surface");
            }
            else
            {
                gvm.ErrorMessage = l.ErrorLogin();
                user = new User();

                return View("Index", gvm);
            }
        }

        [HttpPost]
        public ActionResult RegisterCheck(User user)
        {
            l.GetRegistry(user);

            return RedirectToAction("Index", "Login");
        }
    }
}