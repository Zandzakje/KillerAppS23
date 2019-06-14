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
    public class Combat : ICombat
    {
        UserContext userContext = new UserContext();
        EnemyContext enemyContext = new EnemyContext();

      public void InitializeCombat(User user, Enemy enemy)
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
        
        public void Action(User user, Enemy enemy)
        {
            if(user.CurrentHp > 0 && enemy.CurrentHp > 0)
            {
                if (user.Speed >= enemy.Speed)
                {
                    user.Faster = true;

                    switch (user.Move)
                    {
                        case "Attack":
                            user.Damage = CalculateDamageDealt(user, enemy);
                            break;
                        case "Heal":
                            UserLogic userLogic = new UserLogic();
                            user.Heal = userLogic.Healing(user);
                            break;
                    }

                    UserMessage(user, enemy);

                    if (enemy.CurrentHp <= 0)
                    {
                        enemy.Defeated = true;
                    }
                    else
                    {
                        enemy.Damage = CalculateDamageTaken(user, enemy);
                        EnemyMessage(user, enemy);
                    }
                }
                else
                {
                    enemy.Damage = CalculateDamageTaken(user, enemy);
                    EnemyMessage(user, enemy);

                    if (user.CurrentHp <= 0)
                    {
                        user.Defeated = true;
                    }
                    else
                    {
                        switch (user.Move)
                        {
                            case "Attack":
                                user.Damage = CalculateDamageDealt(user, enemy);
                                break;
                            case "Heal":
                                UserLogic userLogic = new UserLogic();
                                user.Heal = userLogic.Healing(user);
                                break;
                        }

                        UserMessage(user, enemy);
                    }
                }
            }
            else
            {
                
            }
        }

        public int CalculateDamageDealt(User user, Enemy enemy)
        {
            Random random = new Random();
            int number = random.Next(85, 101);
            int attackPower = random.Next(75, 91);
            int accuracy = random.Next(1, 21);

            int damage = ((((2 * user.Level / 5 + 2) * user.Attack * attackPower / enemy.Defense) / 50) + 2) * number / 100;
            Math.Round(enemy.CurrentHp, 0, MidpointRounding.AwayFromZero);

            if (accuracy < 3)
            {
                damage = 0;
            }
            else
            {
                enemy.CurrentHp = enemy.CurrentHp - damage;
            }

            return damage;
        }

        public int CalculateDamageTaken(User user, Enemy enemy)
        {
            Random random = new Random();
            int number = random.Next(85, 101);
            int attackPower = random.Next(75, 91);
            int accuracy = random.Next(1, 21);

            int damage = ((((2 * enemy.Level / 5 + 2) * enemy.Attack * attackPower / user.Defense) / 50) + 2) * number / 100;
            Math.Round(user.CurrentHp, 0, MidpointRounding.AwayFromZero);

            if (accuracy < 3)
            {
                damage = 0;
            }
            else
            {
                user.CurrentHp = user.CurrentHp - damage;
            }

            return damage;
        }

        public void UserMessage(User user, Enemy enemy)
        {
            switch (user.Move)
            {
                case "Attack":
                    user.Message = user.Name + " dealt " + user.Damage + " damage!";
                    if (enemy.CurrentHp <= 0)
                    {
                        enemy.CurrentHp = 0;
                        user.Message = user.Message + " You win!";
                        ExperienceGained(user, enemy);
                    }
                    else if (user.Damage == 0)
                    {
                        user.Message = enemy.Name + " avoided the attack!";
                    }
                    else
                    {
                        //nothing
                    }
                    break;
                case "Heal":
                    if (user.CurrentHp < user.MaxHp)
                    {
                        user.Message = user.Name + " heals " + user.Heal + " HP!";
                    } 
                    else if (user.CurrentHp >= user.MaxHp)
                    {
                        user.CurrentHp = user.MaxHp;
                        user.Message = user.Name + "'s HP fully restored!";
                    }
                    break;
            }
        }

        public void EnemyMessage(User user, Enemy enemy)
        {
            enemy.Message = enemy.Name + " dealt " + enemy.Damage + " damage!";

            if (user.CurrentHp <= 0)
            {
                user.CurrentHp = 0;
                enemy.Message = enemy.Message + " You are defeated!";
            }
            else if (enemy.Damage == 0)
            {
                enemy.Message = user.Name + " avoided the attack!";
            }
            else
            {
                //nothing
            }
        }

        public int ExpEarned(User user, Enemy enemy)
        {
            user.Exp = (user.Level * enemy.Level) + (enemy.MaxHp / 10);

            return user.Exp;
        }

        public int NxtLv(User user)
        {
            user.NextExp = user.Level * user.Level * user.Level;
            return user.NextExp;
        }

        public void ExperienceGained(User user, Enemy enemy)
        {
            user.Exp = ExpEarned(user, enemy);
            user.CurrentExp = user.CurrentExp + user.Exp;
            user.TotalExp = user.TotalExp + user.Exp;
            user.ExpMessage = "You earned " + user.Exp + " exp!";
            enemy.Defeated = true;

            if (user.CurrentExp >= user.NextExp)
            {
                UserLogic userLogic = new UserLogic();

                user.Level++;
                user = userLogic.LevelUp(user);
                user.ExpMessage = user.ExpMessage + " Level up!";

                if (user.Level == 3)
                {
                    if (user.Class == "Knight" || user.Class == "Huntress" || user.Class == "Spooky")
                    {
                        user.ClassUp = true;
                        ClassUp(user);
                    }
                }

                int RemainingExp = 0;

                if(user.CurrentExp > user.NextExp)
                {
                    RemainingExp = user.CurrentExp - user.NextExp;
                    user.CurrentExp = RemainingExp;
                }

                user.NextExp = NxtLv(user);
            }
            else
            {
                //nothing happens
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
            return enemyContext.GenerateEnemy(number);
        }

        public void GetUpdateUser(User user)
        {
            userContext.UpdateUser(user);
        }

        public void GetAddBattleLog(User user, Enemy enemy)
        {
            if (enemy.CurrentHp <= 0)
            {
                user.Result = "Won";
            }
            else if (user.CurrentHp <= 0)
            {
                user.Result = "Lost";
            }
            else if (user.CurrentHp > 0 && enemy.CurrentHp > 0)
            {
                user.Result = "Fled";
            }

            userContext.AddBattleLog(user, enemy);
        }
    }
}
