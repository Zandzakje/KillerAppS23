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
        // GET: Surface
        public ActionResult Index()
        {
            User user = (User)Session["user"];

            SurfaceViewModel surfaceViewModel = new SurfaceViewModel
            {
                Username = user.Name
            };
            
            return View(surfaceViewModel);
        }

        public ActionResult Summary()
        {
            User user = (User)Session["user"];

            SummaryViewModel summaryViewModel = new SummaryViewModel
            {
                Username = user.Name,
                Class = user.Class,
                Level = user.Level,
                MaxHp = user.MaxHp,
                Attack = user.Attack,
                Defense = user.Defense,
                Speed = user.Speed,
                CurrentExp = user.CurrentExp,
                NextExp = user.NextExp,
                TotalExp = user.TotalExp
            };

            return View(summaryViewModel);
        }

        public ActionResult Combat()
        {
            User user = (User)Session["user"];
            Enemy enemy = new Enemy();
            UserLogic userLogic = new UserLogic();
            EnemyLogic enemyLogic = new EnemyLogic();
            Combat combat = new Combat();

            //random nummer waarmee de enemy wordt bepaald
            int number = enemyLogic.RandomNumber();

            //enemy ophalen uit de database
            enemy = combat.GetNewEnemy(number);

            //de stats van de enemy aanpassen gebaseerd op de user z'n level
            enemy = enemyLogic.EnemyBalance(user.Level, enemy);

            user.HalfHp = userLogic.GetHalfHp(user.MaxHp);
            user.LowHp = userLogic.GetLowHp(user.MaxHp);
            enemy.HalfHp = enemyLogic.GetHalfHp(enemy.MaxHp);
            enemy.LowHp = enemyLogic.GetLowHp(enemy.MaxHp);

            Session["enemy"] = enemy;

            return RedirectToAction("Index", "Combat");
        }

        public ActionResult Logout()
        {
            Session.Abandon();

            return RedirectToAction("Index", "Login");
        }
    }
}