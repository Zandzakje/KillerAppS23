using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RpgApp_Model
{
    public class Character
    {
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int MaxHp { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }

        public int HalfHp { get; set; }
        public int MinHp { get; set; }
        public double CurrentHp { get; set; }

        public string Message { get; set; }
    }

    public class User : Character
    {
        public string Password { get; set; }
        public string Class { get; set; }
        public int TotalExp { get; set; }

        public int Exp { get; set; } 
        public int NextLevel { get; set; }
    }

    public class Enemy : Character
    {
        public string Type { get; set; }
    }
}