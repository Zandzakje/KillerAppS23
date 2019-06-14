using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RpgApp.Models.ViewModels
{
    public class EnemyViewModel
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int MaxHp { get; set; }
        public int HalfHp { get; set; }
        public int LowHp { get; set; }
        public double CurrentHp { get; set; }
        public string Message { get; set; }
        public bool Faster { get; set; }
        public bool Defeated { get; set; }

        public EnemyViewModel(string name, int level, int maxHp, int halfHp, int lowHp, double currentHp, string message, bool faster, bool defeated)
        {
            Name = name;
            Level = level;
            MaxHp = maxHp;
            HalfHp = halfHp;
            LowHp = lowHp;
            CurrentHp = currentHp;
            Message = message;
            Faster = faster;
            Defeated = defeated;
        }
    }
}