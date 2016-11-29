

using RockPaperScissors.StaticValues;
using System;
using System.Web.Http;
namespace RockPaperScissors.WebApi.Controllers
{
    public class RockPaperScissorsGeneratorController : ApiController
    {
        //
        // GET: /RockPaperScissorsGenerator/
        public Possibilities GetRandomPreference()
        {
            var randomPosibility = new Random().Next(3);
            return (Possibilities)randomPosibility;
        }
	}
}