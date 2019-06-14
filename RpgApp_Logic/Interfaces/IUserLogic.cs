using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpgApp_Model;

namespace RpgApp_Logic.Interfaces
{
    interface IUserLogic
    {
        int Healing(User user);

        User LevelUp(User user);

        int GetHalfHp(int MaxHp);

        int GetLowHp(int MaxHp);
    }
}
