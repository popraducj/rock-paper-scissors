using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaperScissors.BL;
using RockPaperScissors.BL.BattleRules;
using RockPaperScissors.BL.BattleWeapon;
using System;

namespace RockPaperScissors.BL.Tests
{
    [TestClass]
    public class BattleRoomTest
    {
        private Player _playerRock;
        private Player _playerPaper;
        private BattleRoom _battleRoom;
        private BattleRoom _battleRoomInvers;

        [TestInitialize]
        public void Initialize()
        {
            _battleRoom = new BattleRoom("rock-paper-scissors");
            _battleRoomInvers = new BattleRoom("rock-paper-scissors-inverse");
            _playerRock = new Player
            {
                Weapon = new Weapon
               {
                   Type = WeaponType.Rock,
                   Damage = 1
               },
                Name = "Visitor",
                Strength = 1
            };
            _playerPaper = new Player
            {
                Weapon = new Weapon
                {
                    Type = WeaponType.Paper,
                    Damage = 1
                },
                Name = "Visitor",
                Strength = 1
            };
        }

        [TestMethod]
        public void BattleRoomRPSWin()
        {
            var battleResult = _battleRoom.Battle(_playerPaper, _playerRock);
            Assert.AreEqual(battleResult.BattleResultType, BattleResultType.Win);
        }

        [TestMethod]
        public void BattleRoomRPSLose()
        {
            var battleResult = _battleRoom.Battle(_playerRock, _playerPaper);
            Assert.AreEqual(battleResult.BattleResultType, BattleResultType.Lose);
        }

        [TestMethod]
        public void BattleRoomRPSDraw()
        {
            var battleResult = _battleRoom.Battle(_playerRock, _playerRock);
            Assert.AreEqual(battleResult.BattleResultType, BattleResultType.Draw);
        }

        [TestMethod]
        public void BattleRoomRPSInverseWin()
        {
            var battleResult = _battleRoomInvers.Battle(_playerRock, _playerPaper);
            Assert.AreEqual(battleResult.BattleResultType, BattleResultType.Win);
        }

        [TestMethod]
        public void BattleRoomRPSInverseLose()
        {
            var battleResult = _battleRoomInvers.Battle(_playerPaper, _playerRock);
            Assert.AreEqual(battleResult.BattleResultType, BattleResultType.Lose);
        }

        [TestMethod]
        public void BattleRoomRPSInverseDraw()
        {
            var battleResult = _battleRoomInvers.Battle(_playerRock, _playerRock);
            Assert.AreEqual(battleResult.BattleResultType, BattleResultType.Draw);
        }

    }
}