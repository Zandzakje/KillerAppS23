using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RpgApp.Models.ViewModels
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public string Class { get; set; }
        public int CurrentExp { get; set; }
        public int NextExp { get; set; }
        public int TotalExp { get; set; }
        public int MaxHp { get; set; }
        public int HalfHp { get; set; }
        public int LowHp { get; set; }
        public double CurrentHp { get; set; }
        public string Message { get; set; }
        public string ExpMessage { get; set; }
        public string ClassMessage { get; set; }
        public bool Faster { get; set; }
        public bool ClassUp { get; set; }
        public bool Defeated { get; set; }

        public UserViewModel(string name, int level, string classString, int currentExp, int nextExp, int totalExp, int maxHp, int halfHp, int lowHp, double currentHp, string message, string expMessage, string classMessage, bool faster, bool classUp, bool defeated)
        {
            Name = name;
            Level = level;
            Class = classString;
            CurrentExp = currentExp;
            NextExp = nextExp;
            TotalExp = totalExp;
            MaxHp = maxHp;
            HalfHp = halfHp;
            LowHp = lowHp;
            CurrentHp = currentHp;
            Message = message;
            ExpMessage = expMessage;
            ClassMessage = classMessage;
            Faster = faster;
            ClassUp = classUp;
            Defeated = defeated;
        }
    }
}