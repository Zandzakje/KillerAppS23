﻿using System;
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
        public int LowHp { get; set; }
        public double CurrentHp { get; set; }

        public string Move { get; set; }
        public string Message { get; set; }
        public int Damage { get; set; }

        public bool Faster { get; set; }
        public bool Defeated { get; set; }
    }
}