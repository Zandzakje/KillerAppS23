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
        public ActionResult LoginCheck(string name, string password)
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            Login login = new Login();
            User user = login.GetLoginUser(name, password);

            if (user != null)
            {
                Session["user"] = user;

                return RedirectToAction("Index", "Surface");
            }
            else
            {
                loginViewModel.ErrorMessage = login.ErrorLogin();

                return View("Index", loginViewModel);
            }
        }

        [HttpPost]
        public ActionResult RegisterCheck(User user)
        {
            Login login = new Login();
            login.GetRegisterUser(user);

            return RedirectToAction("Index", "Login");
        }
    }
}