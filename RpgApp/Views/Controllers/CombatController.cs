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
    public class CombatController : Controller
    {
        GlobalViewModel gvm = new GlobalViewModel();
        Combat c = new Combat();

        // GET: Combat
        public ActionResult Index()
        {
            gvm.user = (User)Session["user"];            
            gvm.enemy = (Enemy)Session["enemy"];

            c.Start(gvm.user, gvm.enemy);

            return View(gvm);
        }
        
        [HttpPost]
        public ActionResult Attack()
        {
            gvm.user = (User)Session["user"];
            gvm.enemy = (Enemy)Session["enemy"];

            c.CheckSpeed(gvm.user, gvm.enemy);

            //return RedirectToAction("Index", "Combat");
            return View("Index", gvm);
        }

        [HttpPost]
        public ActionResult Escape()
        {
            User user = (User)Session["user"];
            Enemy enemy = (Enemy)Session["enemy"];
            user.CurrentHp = 0;
            enemy.CurrentHp = 0;
            user.Message = "";
            user.ExpMessage = "";
            user.ClassMessage = "";
            enemy.Message = "";

            c.GetUpdateUser(user);

            return RedirectToAction("Index", "Surface");
        }
    }
}