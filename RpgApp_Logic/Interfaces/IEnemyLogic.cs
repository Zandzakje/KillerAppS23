using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpgApp_Model;

namespace RpgApp_Logic.Interfaces
{
    interface IEnemyLogic
    {
        int RandomNumber();

        Enemy EnemyBalance(int userLevel, Enemy enemy);

        int GetHalfHp(int MaxHp);

        int GetLowHp(int MaxHp);
    }
}
