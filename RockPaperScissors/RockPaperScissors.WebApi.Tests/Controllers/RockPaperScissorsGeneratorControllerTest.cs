using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaperScissors.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RockPaperScissors.StaticValues;

namespace RockPaperScissors.WebApi.Tests.Controllers
{
    [TestClass]
    public class RockPaperScissorsGeneratorControllerTest
    {
        private RockPaperScissorsGeneratorController _controller ;

        [TestInitialize]
        public void Initialize()
        {
            _controller = new RockPaperScissorsGeneratorController();
        }

        [TestMethod]
        public void GetRandomPreference()
        {
            var choise = _controller.GetRandomPreference();
            Assert.IsTrue(Enum.IsDefined(typeof(Possibilities), choise), "The result is not for rock paper scissors game");

        }

        [TestCleanup]
        public void CleanUp()
        {
            _controller.Dispose();
        }
    }
}
