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
    public class Login : ILogin
    {
        UserContext userContext = new UserContext();

        public User GetLoginUser(string name, string password)
        {
            return userContext.LoginUser(name, password);
        }

        public void GetRegisterUser(User user)
        {
            userContext.RegisterUser(user);
        }

        public string ErrorLogin()
        {
            string error = "Incorrect username or password, please try again.";
            return error;
        }
    }
}
