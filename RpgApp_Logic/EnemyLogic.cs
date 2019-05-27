using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpgApp_Model;

namespace RpgApp_Logic
{
    public class EnemyLogic
    {
        public int RandomNumber()
        {
            Random random = new Random();
            int number = random.Next(4, 8); // 4 t/m 7

            return number;
        }

        public Enemy EnemyBalance(int userLevel, Enemy enemy)
        {
            while (userLevel != enemy.Level)
            {
                switch (enemy.Name)
                {
                    case "Bandit":
                        enemy.Level++;
                        enemy.MaxHp = enemy.MaxHp + 4;
                        enemy.Attack = enemy.Attack + 2;
                        enemy.Defense = enemy.Defense + 2;
                        enemy.Speed = enemy.Speed + 2;
                        break;
                    case "Chomper":
                        enemy.Level++;
                        enemy.MaxHp = enemy.MaxHp + 3;
                        enemy.Attack = enemy.Attack + 4;
                        enemy.Defense = enemy.Defense + 2;
                        enemy.Speed = enemy.Speed + 1;
                        break;
                    case "Spikey":
                        enemy.Level++;
                        enemy.MaxHp = enemy.MaxHp + 3;
                        enemy.Attack = enemy.Attack + 1;
                        enemy.Defense = enemy.Defense + 4;
                        enemy.Speed = enemy.Speed + 2;
                        break;
                    case "Stinger":
                        enemy.Level++;
                        enemy.MaxHp = enemy.MaxHp + 3;
                        enemy.Attack = enemy.Attack + 3;
                        enemy.Defense = enemy.Defense + 3;
                        enemy.Speed = enemy.Speed + 3;
                        break;
                }
            }

            return enemy;
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
