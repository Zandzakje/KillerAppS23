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

        // GET: Combat
        public ActionResult Index()
        {
            Combat combat = new Combat();
            User user = (User)Session["user"];            
            Enemy enemy = (Enemy)Session["enemy"];

            CombatViewModel combatViewModel = new CombatViewModel
            {
                userViewModel = new UserViewModel
                {
                    Name = user.Name,
                    Level = user.Level,
                    Class = user.Class,
                    MaxHp = user.MaxHp,
                    HalfHp = user.HalfHp,
                    LowHp = user.LowHp,
                    CurrentHp = user.CurrentHp,
                    Message = user.Message,
                },

                enemyViewModel = new EnemyViewModel
                {
                    Name = enemy.Name,
                    Level = enemy.Level,
                    MaxHp = enemy.MaxHp,
                    HalfHp = enemy.HalfHp,
                    LowHp = enemy.LowHp,
                    CurrentHp = enemy.CurrentHp,
                    Message = enemy.Message
                }
            };
            
            combat.InitializeCombat(user, enemy);

            return View(combatViewModel);
        }
        
        [HttpPost]
        public ActionResult Attack()
        {
            Combat combat = new Combat();
            User user = (User)Session["user"];
            Enemy enemy = (Enemy)Session["enemy"];

            user.Move = "Attack";
            combat.Action(user, enemy);
            
            return RedirectToAction("Index", "Combat");
        }

        [HttpPost]
        public ActionResult Heal()
        {
            Combat combat = new Combat();
            User user = (User)Session["user"];
            Enemy enemy = (Enemy)Session["enemy"];

            user.Move = "Heal";
            combat.Action(user, enemy);

            return RedirectToAction("Index", "Combat");
        }

        [HttpPost]
        public ActionResult Escape()
        {
            Combat combat = new Combat();
            User user = (User)Session["user"];
            Enemy enemy = (Enemy)Session["enemy"];

            //bepaalde variables resetten
            user.CurrentHp = 0;
            enemy.CurrentHp = 0;
            user.Message = "";
            user.ExpMessage = "";
            user.ClassMessage = "";
            enemy.Message = "";
            
            combat.GetUpdateUser(user);

            return RedirectToAction("Index", "Surface");
        }
    }
}