using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpgApp_Data;
using RpgApp_Model;

namespace RpgApp_Logic
{
    public class Login
    {
        ClassSql cs = new ClassSql();

        public User GetLoginCheck(User user)
        {
            return cs.LoginCheck(user);
        }

        public void GetRegistry(User user)
        {
            cs.Registry(user);
        }

        public string ErrorLogin()
        {
            string error = "Incorrect username or password, please try again.";
            return error;
        }
    }
}
