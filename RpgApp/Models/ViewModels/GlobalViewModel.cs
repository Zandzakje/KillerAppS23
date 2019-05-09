using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RpgApp_Model;

namespace RpgApp.Models.ViewModels
{
    public class GlobalViewModel
    {
        public User user { get; set; }
        public Enemy enemy { get; set; }
        
        public string ErrorMessage { get; set; }
    }
}