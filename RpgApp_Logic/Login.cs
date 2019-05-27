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
        UserSql userSql = new UserSql();

        public User GetLoginUser(string name, string password)
        {
            return userSql.LoginUser(name, password);
        }

        public void GetRegistryUser(User user)
        {
            userSql.RegistryUser(user);
        }

        public string ErrorLogin()
        {
            string error = "Incorrect username or password, please try again.";
            return error;
        }
    }
}
