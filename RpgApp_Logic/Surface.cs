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
        ClassSql cs = new ClassSql();

        public User GetSummary(string name)
        {
            return cs.Summary(name);
        }
    }
}
