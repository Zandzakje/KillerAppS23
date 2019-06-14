using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpgApp_Data;
using RpgApp_Model;

namespace RpgApp_Logic.Interfaces
{
    interface ICombat
    {
        void InitializeCombat(User user, Enemy enemy);

        void Action(User user, Enemy enemy);

        int CalculateDamageDealt(User user, Enemy enemy);

        int CalculateDamageTaken(User user, Enemy enemy);

        void UserMessage(User user, Enemy enemy);

        void EnemyMessage(User user, Enemy enemy);

        int ExpEarned(User user, Enemy enemy);

        int NxtLv(User user);

        void ExperienceGained(User user, Enemy enemy);

        void ClassUp(User user);

        Enemy GetNewEnemy(int number);

        void GetUpdateUser(User user);

        void GetAddBattleLog(User user, Enemy enemy);
    }
}
