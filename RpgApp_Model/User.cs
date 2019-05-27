using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RpgApp_Model
{
    public class User : Character
    {
        public string Password { get; set; }
        public string Class { get; set; }
        public int CurrentExp { get; set; }         //Exp progress to the next level
        public int NextExp { get; set; }            //Exp required to go to the next level
        public int TotalExp { get; set; }           //Exp earned since lv.1

        public int Exp { get; set; }                //Exp earned after defeating a enemy
        public string ExpMessage { get; set; }      //Exp shown you earned after battle and if you levelled up
        public string ClassMessage { get; set; }    //Message which appears when the user evolves into another class
        public int Heal { get; set; }

        public bool ClassUp { get; set; }
    }
}
