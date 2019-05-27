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
        public int MaxHp { get; set; }
        public int HalfHp { get; set; }
        public int LowHp { get; set; }
        public double CurrentHp { get; set; }
        public string Message { get; set; }

        public bool Faster { get; set; }
        public bool ClassUp { get; set; }
    }
}