using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RpgApp_Logic;
using RpgApp_Model;

namespace RpgApp_UnitTests
{
    [TestClass]
    public class Combat_Test
    {
        Combat combat = new Combat();
        User user;
        Enemy enemy;

        [TestMethod]
        public void TestInitializeCombat()
        {
            user = new User
            {
                MaxHp = 100
            };

            enemy = new Enemy
            {
                MaxHp = 100
            };

            combat.InitializeCombat(user, enemy);

            Assert.AreEqual(100, user.CurrentHp);
            Assert.AreEqual(100, enemy.CurrentHp);
        }

        [TestMethod]
        public void TestCalculateDamage()
        {
            user = new User
            {
                Level = 5,
                Attack = 20
            };

            enemy = new Enemy
            {
                Defense = 15,
                CurrentHp = 100
            };

            combat.CalculateDamageDealt(user, enemy);

            Assert.AreNotEqual(100, enemy.CurrentHp);
        }

        [TestMethod]
        public void TestUserMessage_Hit()
        {
            user = new User
            {
                Move = "Attack",
                Name = "Jan",
                Damage = 20
            };

            enemy = new Enemy
            {
                Name = "Jan2",
                CurrentHp = 100
            };

            combat.UserMessage(user, enemy);

            Assert.AreEqual("Jan dealt 20 damage!", user.Message);
        }

        [TestMethod]
        public void TestUserMessage_Miss()
        {
            user = new User
            {
                Move = "Attack",
                Name = "Jan",
                Damage = 0
            };

            enemy = new Enemy
            {
                Name = "Jan2",
                CurrentHp = 100
            };

            combat.UserMessage(user, enemy);

            Assert.AreEqual("Jan2 avoided the attack!", user.Message);
        }
    }
}
