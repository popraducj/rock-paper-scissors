using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaperScissors.BL;
using RockPaperScissors.BL.BattleRules;
using System;

namespace RockPaperScissors.BL.Tests
{
    [TestClass]
    public class BattleRoomTest
    {
        private int _weaponTypeLength = 0;
        private string _rockPaperScissors = "rock-paper-scissors"; 
        private string _rockPaperScissorsInverse = "rock-paper-scissors-inverse";
        [TestInitialize]
        public void Initialize()
        {
            _weaponTypeLength = Enum.GetNames(typeof(WeaponType)).Length;
        }

        [TestMethod]
        public void BattleRoomRPSWin()
        {
            var battleRoom = new BattleRoom(_rockPaperScissors);
            var randomWeapon = (WeaponType)new Random().Next(_weaponTypeLength);
            var ruleWeapons = new RockPaperScissorsBattleRule().Weapons;
            var losingWeapon = ruleWeapons.Find(x => x.Weakness.IndexOf(randomWeapon) > -1);
            var battleResult = battleRoom.Battle(randomWeapon, losingWeapon.Type);
            Assert.AreEqual(battleResult, BattleResult.Win);
        }

        [TestMethod]
        public void BattleRoomRPSLose()
        {

            var battleRoom = new BattleRoom(_rockPaperScissors);
            var randomWeapon = (WeaponType)new Random().Next(_weaponTypeLength);
            var ruleWeapons = new RockPaperScissorsBattleRule().Weapons;
            var losingWeapon = ruleWeapons.Find(x => x.Weakness.IndexOf(randomWeapon) > -1);
            var battleResult = battleRoom.Battle(losingWeapon.Type, randomWeapon);
            Assert.AreEqual(battleResult, BattleResult.Lose);
        }

        [TestMethod]
        public void BattleRoomRPSEqual()
        {
            var battleRoom = new BattleRoom(_rockPaperScissors);
            var randomWeapon = (WeaponType)new Random().Next(_weaponTypeLength);
            var battleResult = battleRoom.Battle(randomWeapon, randomWeapon);
            Assert.AreEqual(battleResult, BattleResult.Equal);
        }

        [TestMethod]
        public void BattleRoomRPSInverseWin()
        {
            var battleRoom = new BattleRoom(_rockPaperScissorsInverse);
            var randomWeapon = (WeaponType)new Random().Next(_weaponTypeLength);
            var ruleWeapons = new RockPaperScissorsInverseBattleRule().Weapons;
            var losingWeapon = ruleWeapons.Find(x => x.Weakness.IndexOf(randomWeapon) > -1);
            var battleResult = battleRoom.Battle(randomWeapon, losingWeapon.Type);
            Assert.AreEqual(battleResult, BattleResult.Win);
        }

        [TestMethod]
        public void BattleRoomRPSInverseLose()
        {

            var battleRoom = new BattleRoom(_rockPaperScissorsInverse);
            var randomWeapon = (WeaponType)new Random().Next(_weaponTypeLength);
            var ruleWeapons = new RockPaperScissorsInverseBattleRule().Weapons;
            var losingWeapon = ruleWeapons.Find(x => x.Weakness.IndexOf(randomWeapon) > -1);
            var battleResult = battleRoom.Battle(losingWeapon.Type, randomWeapon);
            Assert.AreEqual(battleResult, BattleResult.Lose);
        }

        [TestMethod]
        public void BattleRoomRPSInverseEqual()
        {
            var battleRoom = new BattleRoom(_rockPaperScissorsInverse);
            var randomWeapon = (WeaponType)new Random().Next(_weaponTypeLength);
            var battleResult = battleRoom.Battle(randomWeapon, randomWeapon);
            Assert.AreEqual(battleResult, BattleResult.Equal);
        }
    }
}
