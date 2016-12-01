using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaperScissors.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RockPaperScissors.BL;
using System.Net.Http;
using System.Web.Http;

namespace RockPaperScissors.WebApi.Tests.Controllers
{
    [TestClass]
    public class GameControllerTest
    {
        private GameController _controller ;

        [TestInitialize]
        public void Initialize()
        {
            _controller = new GameController();
            _controller.Request = new HttpRequestMessage();
            _controller.Configuration = new HttpConfiguration();
        }

        [TestMethod]
        public void BattleSuccessResult()
        {
            var battleResult = _controller.battle(WeaponType.Scissors);
            BattleResult result;
            Assert.IsTrue(battleResult.TryGetContentValue<BattleResult>(out result));
        }

        [TestMethod]
        public void BattleBadRequestResult()
        {
            var battleResult = _controller.battle(WeaponType.Scissors|WeaponType.Paper);
            BattleResult result;
            Assert.IsFalse(battleResult.TryGetContentValue<BattleResult>(out result));
        }

        [TestCleanup]
        public void CleanUp()
        {
            _controller.Dispose();
        }
    }
}
