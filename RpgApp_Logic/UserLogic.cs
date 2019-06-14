using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpgApp_Logic.Interfaces;
using RpgApp_Model;

namespace RpgApp_Logic
{
    public class UserLogic : IUserLogic
    {
        public int Healing(User user)
        {
            user.Heal = user.HalfHp;

            user.CurrentHp = user.CurrentHp + user.Heal;

            return user.Heal;
        }

        public User LevelUp(User user)
        {
            Random statsUp = new Random();
            int weak = statsUp.Next(1, 4);      // 0 t/m 3
            int normal = statsUp.Next(2, 5);    // 1 t/m 4
            int strong = statsUp.Next(3, 6);    // 2 t/m 5

            switch (user.Class)
            {
                case "Knight":
                case "Paladin":
                    user.MaxHp = user.MaxHp + normal;
                    user.Attack = user.Attack + strong;
                    user.Defense = user.Defense + normal;
                    user.Speed = user.Speed + weak;
                    break;
                case "Huntress":
                case "Valkyrie":
                    user.MaxHp = user.MaxHp + normal;
                    user.Attack = user.Attack + normal;
                    user.Defense = user.Defense + weak;
                    user.Speed = user.Speed + strong;
                    break;
                case "Spooky":
                case "Nightmare":
                    user.MaxHp = user.MaxHp + normal;
                    user.Attack = user.Attack + normal;
                    user.Defense = user.Defense + normal;
                    user.Speed = user.Speed + normal;
                    break;
            }

            return user;
        }

        public int GetHalfHp(int MaxHp)
        {
            double half = MaxHp * 0.5;
            Math.Round(half, 0, MidpointRounding.AwayFromZero);
            int HalfHp = Convert.ToInt32(half);

            return HalfHp;
        }

        public int GetLowHp(int MaxHp)
        {
            double min = MaxHp * 0.15;
            Math.Round(min, 0, MidpointRounding.AwayFromZero);
            int LowHp = Convert.ToInt32(min);

            return LowHp;
        }
    }
}
