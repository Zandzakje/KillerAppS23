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
                Experience(user, enemy);
            }
            else
            {
                EnemyMessage(user, enemy);
            }
        }

        public int ExpEarned(User user, Enemy enemy)
        {
            user.Exp = (user.Level * user.Level) + (enemy.MaxHp / 10);

            return user.Exp;
        }

        public void UserMessage(User user, Enemy enemy)
        {
            if (user.Speed >= enemy.Speed && user.CurrentExp < user.NextExp)
            {
                enemy.CurrentHp = 0;
                enemy.Message = "";
                user.Message = user.Name + " dealt " + damageUser + " damage, You win!";
                user.ExpMessage = "You earned " + user.Exp + " Exp!";
            }
            else if (user.Speed < enemy.Speed && user.CurrentExp < user.NextExp)
            {
                enemy.CurrentHp = 0;
                user.Message = user.Name + " dealt " + damageUser + " damage, You win!";
                user.ExpMessage = "You earned " + user.Exp + " Exp!";
            }
            else if (user.Speed >= enemy.Speed && user.CurrentExp >= user.NextExp)
            {
                enemy.CurrentHp = 0;
                enemy.Message = "";
                user.Message = user.Name + " dealt " + damageUser + " damage, You win!";
                user.ExpMessage = "You earned " + user.Exp + " Exp!" + " Level up!";
            }
            else if (user.Speed < enemy.Speed && user.CurrentExp >= user.NextExp)
            {
                enemy.CurrentHp = 0;
                user.Message = user.Name + " dealt " + damageUser + " damage, You win!";
                user.ExpMessage = "You earned " + user.Exp + " Exp!" + " Level up!";
            }
        }

        public void EnemyMessage(User user, Enemy enemy)
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

        public int NxtLv(User user)
        {
            user.NextExp = user.Level * user.Level * user.Level;
            return user.NextExp;
        }

        public void Experience(User user, Enemy enemy)
        {
            user.Exp = ExpEarned(user, enemy);
            user.CurrentExp = user.CurrentExp + user.Exp;
            user.TotalExp = user.TotalExp + user.Exp;
            
            UserMessage(user, enemy);

            if(user.CurrentExp >= user.NextExp)
            {
                user.Level++;
                LevelUp(user);

                if (user.Level == 50)
                {
                    if (user.Class == "Knight" || user.Class == "Huntress" || user.Class == "Spooky")
                    {
                        ClassUp(user);
                    }
                }

                int RemainingExp = 0;

                if(user.CurrentExp > user.NextExp)
                {
                    RemainingExp = user.CurrentExp - user.NextExp;
                }

                user.CurrentExp = RemainingExp;
                user.NextExp = NxtLv(user);
            }
            else
            {
                //nothing happens
            }
        }

        public void LevelUp(User user)
        {
            Random statsUp = new Random();
            int weak = statsUp.Next(1, 4);      // 0 t/m 3
            int normal = statsUp.Next(2, 5);    // 1 t/m 4
            int strong = statsUp.Next(3, 6);    // 2 t/m 5

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

        public void ClassUp(User user)
        {
            switch (user.Class)
            {
                case "Knight":
                    user.ClassMessage = "Congratulations! Your class evolved from Knight to Paladin!";
                    user.Class = "Paladin";
                    break;
                case "Huntress":
                    user.ClassMessage = "Congratulations! Your class evolved from Huntress to Valkyrie!";
                    user.Class = "Valkyrie";
                    break;
                case "Spooky":
                    user.ClassMessage = "Congratulations! Your class evolved from Spooky to Nightmare!";
                    user.Class = "Nightmare";
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
                        enemy.MaxHp = enemy.MaxHp + 4;
                        enemy.Attack = enemy.Attack + 3;
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

        public void GetUpdateUser(User user)
        {
            cs.UpdateUser(user);
        }
    }
}
