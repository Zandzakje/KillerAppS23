using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RpgApp.Models.ViewModels;
using RpgApp_Logic;
using RpgApp_Model;

namespace RpgApp.Controllers
{
    public class SurfaceController : Controller
    {
        GlobalViewModel gvm = new GlobalViewModel();
        Combat c = new Combat();

        // GET: Surface
        public ActionResult Index()
        {
            gvm.user = (User)Session["user"];

            return View(gvm);
        }

        public ActionResult Summary()
        {
            gvm.user = (User)Session["user"];

            return View(gvm);
        }

        public ActionResult Combat()
        {
            int number = c.RandomNumber();
            gvm.enemy = c.GetNewEnemy(number);

            User user = (User)Session["user"];
            gvm.enemy = c.EnemyBalance(user, gvm.enemy);

            Session["enemy"] = gvm.enemy;

            return RedirectToAction("Index", "Combat");
        }

        public ActionResult Logout()
        {
            Session.Abandon();

            return RedirectToAction("Index", "Login");
        }
    }
}