using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RpgApp.Models.ViewModels
{
    public class CombatViewModel
    {
        public UserViewModel userViewModel { get; set; }
        public EnemyViewModel enemyViewModel { get; set; }
    }
}