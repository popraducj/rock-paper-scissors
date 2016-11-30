using RockPaperScissors.StaticValues;
using System;
using System.Web.Http;

namespace RockPaperScissors.WebApi.Controllers
{
    // /api/RockPaperScissorsGenerator
    public class RockPaperScissorsGeneratorController : ApiController
    {
        //
        // GET: /GetRandomPreference
        public Possibilities Get()
        {
            var randomPosibility = new Random().Next(3);
            return (Possibilities)randomPosibility;
        }
	}
}