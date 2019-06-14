using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpgApp_Data;
using RpgApp_Model;

namespace RpgApp_Logic.Interfaces
{
    interface ISurface
    {
        User GetSummaryUser(string name);
    }
}
