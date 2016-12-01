using RockPaperScissors.BL;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RockPaperScissors.WebApi.Controllers
{
    // /api/GameController
    public class GameController : ApiController
    {
        //
        // GET: /Get
        [HttpGet]
        public HttpResponseMessage battle(WeaponType selection, string gameRule = "rock-paper-scissors-invers")
        {
            var weaponTypeLength = Enum.GetNames(typeof(WeaponType)).Length;
            if ((int)selection > weaponTypeLength)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            var randomSelection = (WeaponType)new Random().Next(weaponTypeLength);

            try
            {
                var result = new BattleRoom(gameRule).Battle(selection, randomSelection);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

        }
    }
}