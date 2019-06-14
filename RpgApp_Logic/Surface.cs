using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpgApp_Logic.Interfaces;
using RpgApp_Data;
using RpgApp_Model;

namespace RpgApp_Logic
{
    public class Surface : ISurface
    {
        UserContext userContext = new UserContext();

        public User GetSummaryUser(string name)
        {
            return userContext.SummaryUser(name);
        }
    }
}
