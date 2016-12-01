using RockPaperScissors.StaticValues;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RockPaperScissors.WebApi.Controllers
{
    // /api/RockPaperScissorsGenerator
    public class RockPaperScissorsGeneratorController : ApiController
    {
        //
        // GET: /Get
        public Possibilities Get()
        {
            var randomPosibility = new Random().Next(3);
            return (Possibilities)randomPosibility;
        }
	}
}