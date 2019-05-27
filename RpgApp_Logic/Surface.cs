using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpgApp_Data;
using RpgApp_Model;

namespace RpgApp_Logic
{
    public class Surface
    {
        UserSql userSql = new UserSql();

        public User GetSummaryUser(string name)
        {
            return userSql.SummaryUser(name);
        }
    }
}
