using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RpgApp_Data;
using RpgApp_Model;

namespace RpgApp_Logic
{
    public class Combat
    {
        ClassSql cs = new ClassSql();
        int damageUser;
        int damageEnemy;

        public int RandomNumber()
        {
            Random random = new Random();
            int number = random.Next(4, 8); // 4 t/m 7

            return number;
        }

        public void Start(User user, Enemy enemy)
        {
            if (user.CurrentHp == 0 && enemy.CurrentHp == 0)
            {
                user.CurrentHp = user.MaxHp;
                enemy.CurrentHp = enemy.MaxHp;
            }
            else
            {

            }
        }
        
        public void CheckSpeed(User user, Enemy enemy)
        {
            if(user.CurrentHp == 0 || enemy.CurrentHp == 0)
            {
                goto Done;
            }
            else
            {
                if (user.Speed >= enemy.Speed)
                {
                    damageUser = CalculateDamageDealt(user, enemy);
                    CheckHealth(user, enemy);

                    if (enemy.CurrentHp <= 0)
                    {
                        goto Done;
                    }
                    else
                    {
                        CalculateDamageTaken(user, enemy);
                        CheckHealth(user, enemy);
                    }
                }
                else if (user.Speed < enemy.Speed)
                {
                    CalculateDamageTaken(user, enemy);
                    CheckHealth(user, enemy);

                    if (user.CurrentHp <= 0)
                    {
                        goto Done;
                    }
                    else
                    {
                        damageUser = CalculateDamageDealt(user, enemy);
                        CheckHealth(user, enemy);
                    }
                }
            }

            Done:
                string dummy = "dummy string zodat de goto werkt";
        }

        public int CalculateDamageDealt(User user, Enemy enemy)
        {
            Random random = new Random();
            int number = random.Next(85, 101);

            damageUser = ((((2 * user.Level / 5 + 2) * user.Attack * 90 / enemy.Defense) / 50) + 2) * number / 100;
            Math.Round(enemy.CurrentHp, 0, MidpointRounding.AwayFromZero);

            enemy.CurrentHp = enemy.CurrentHp - damageUser;

            return damageUser;
        }

        public int CalculateDamageTaken(User user, Enemy enemy)
        {
            Random random = new Random();
            int number = random.Next(85, 101);

            damageEnemy = ((((2 * enemy.Level / 5 + 2) * enemy.Attack * 90 / user.Defense) / 50) + 2) * number / 100;
            Math.Round(user.CurrentHp, 0, MidpointRounding.AwayFromZero);

            user.CurrentHp = user.CurrentHp - damageEnemy;

            return damageEnemy;
        }

        public void CheckHealth(User user, Enemy enemy)
        {
            if(enemy.CurrentHp <= 0)
            {
                //Experience(user, enemy);

                if (user.Speed >= enemy.Speed && user.TotalExp < user.NextLevel)
                {
                    enemy.CurrentHp = 0;
                    enemy.Message = "";
                    user.Message = user.Name + " dealt " + damageUser + " damage, You win!";
                }
                else if (user.Speed < enemy.Speed && user.TotalExp < user.NextLevel)
                {
                    enemy.CurrentHp = 0;
                    user.Message = user.Name + " dealt " + damageUser + " damage, You win!";
                }
                else if (user.Speed >= enemy.Speed && user.TotalExp >= user.NextLevel)
                {
                    enemy.CurrentHp = 0;
                    enemy.Message = "";
                    user.Message = user.Name + " dealt " + damageUser + " damage, You win! Level up!";
                }
                else if (user.Speed < enemy.Speed && user.TotalExp >= user.NextLevel)
                {
                    enemy.CurrentHp = 0;
                    user.Message = user.Name + " dealt " + damageUser + " damage, You win! Level up!";
                }
            }
            else
            {
                if (user.CurrentHp <= 0 && user.Speed < enemy.Speed)
                {
                    user.CurrentHp = 0;
                    user.Message = "";
                    enemy.Message = enemy.Name + " dealt " + damageEnemy + " damage, You are defeated!";
                }
                else if (user.CurrentHp <= 0 && user.Speed >= enemy.Speed)
                {
                    user.CurrentHp = 0;
                    enemy.Message = enemy.Name + " dealt " + damageEnemy + " damage, You are defeated!";
                }
                else
                {
                    user.Message = user.Name + " dealt " + damageUser + " damage!";
                    enemy.Message = enemy.Name + " dealt " + damageEnemy + " damage!";
                }
            }
        }

        public int ExpEarned(User user)
        {
            user.Exp = user.Level * 15;
            return user.Exp;
        }

        public int NxtLv(User user)
        {
            user.NextLevel = user.Level * user.Level * user.Level;
            return user.NextLevel;
        }

        public void Experience(User user, Enemy enemy)
        {
            user.Exp = ExpEarned(user);
            user.NextLevel = NxtLv(user);

            user.TotalExp = user.TotalExp + user.Exp;

            if(user.TotalExp >= user.NextLevel)
            {
                user.Level++;
                LevelUp(user);
            }
            else
            {
                //nothing happens
            }
        }

        public void LevelUp(User user)
        {
            Random statsUp = new Random();
            int weak = statsUp.Next(0, 3);      // 0 t/m 2
            int normal = statsUp.Next(2, 5);    // 2 t/m 4
            int strong = statsUp.Next(4, 7);    // 4 t/m 6

            switch (user.Class)
            {
                case "Knight":
                    user.MaxHp = user.MaxHp + normal;
                    user.Attack = user.Attack + strong;
                    user.Defense = user.Defense + normal;
                    user.Speed = user.Speed + weak;
                    break;
                case "Valkyrie":
                    user.MaxHp = user.MaxHp + normal;
                    user.Attack = user.Attack + normal;
                    user.Defense = user.Defense + weak;
                    user.Speed = user.Speed + strong;
                    break;
                case "Spooky":
                    user.MaxHp = user.MaxHp + normal;
                    user.Attack = user.Attack + normal;
                    user.Defense = user.Defense + normal;
                    user.Speed = user.Speed + normal;
                    break;
            }
        }

        public Enemy GetNewEnemy(int number)
        {
            return cs.NewEnemy(number);
        }

        public Enemy EnemyBalance(User user, Enemy enemy)
        {
            while(user.Level != enemy.Level)
            {
                switch (enemy.Name)
                {
                    case "Bandit":
                        enemy.Level++;
                        enemy.MaxHp = enemy.MaxHp + 2;
                        enemy.Attack = enemy.Attack + 2;
                        enemy.Defense = enemy.Defense + 2;
                        enemy.Speed = enemy.Speed + 2;
                        break;
                    case "Chomper":
                        enemy.Level++;
                        enemy.MaxHp = enemy.MaxHp + 3;
                        enemy.Attack = enemy.Attack + 4;
                        enemy.Defense = enemy.Defense + 2;
                        enemy.Speed = enemy.Speed + 2;
                        break;
                    case "Spikey":
                        enemy.Level++;
                        enemy.MaxHp = enemy.MaxHp + 3;
                        enemy.Attack = enemy.Attack + 2;
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

        public void GetUpdateUser(User user)
        {
            cs.UpdateUser(user);
        }
    }
}
