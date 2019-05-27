using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RpgApp.Models.ViewModels
{
    public class SummaryViewModel
    {
        public string Username { get; set; }
        public string Class { get; set; }
        public int Level { get; set; }
        public int MaxHp { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }
        public int CurrentExp { get; set; }
        public int NextExp { get; set; }
        public int TotalExp { get; set; }
    }
}