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

            //huidige hp van de user en enemy vaststellen bij het begin van een gevecht
            combat.InitializeCombat(user, enemy);

            CombatViewModel combatViewModel = new CombatViewModel
            {
                userViewModel = new UserViewModel(user.Name, user.Level, user.Class, user.CurrentExp, user.NextExp, user.TotalExp, user.MaxHp, user.HalfHp, user.LowHp, user.CurrentHp, user.Message, user.ExpMessage, user.ClassMessage, user.Faster, user.ClassUp, user.Defeated),
                enemyViewModel = new EnemyViewModel(enemy.Name, enemy.Level, enemy.MaxHp, enemy.HalfHp, enemy.LowHp, enemy.CurrentHp, enemy.Message, enemy.Faster, enemy.Defeated)
            };

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

            combat.GetUpdateUser(user);
            combat.GetAddBattleLog(user, enemy);

            //bepaalde variables resetten
            user.CurrentHp = 0;
            enemy.CurrentHp = 0;
            user.Message = "";
            user.ExpMessage = "";
            user.ClassMessage = "";
            enemy.Message = "";
            user.Faster = false;
            enemy.Faster = false;
            user.ClassUp = false;
            user.Defeated = false;
            enemy.Defeated = false;

            return RedirectToAction("Index", "Surface");
        }
    }
}