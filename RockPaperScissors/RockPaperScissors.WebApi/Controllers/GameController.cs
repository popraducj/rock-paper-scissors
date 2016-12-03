using RockPaperScissors.BL;
using RockPaperScissors.WebApi.Models;
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
        public HttpResponseMessage battle(WeaponType selection, string gameType = "rock-paper-scissors")
        {
            var weaponTypeLength = Enum.GetNames(typeof(WeaponType)).Length;
            if ((int)selection > weaponTypeLength)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            var randomSelection = (WeaponType)new Random().Next(weaponTypeLength);

            try
            {
                var resultModel = new BattleResultModel(){
                    Result = new BattleRoom(gameType).Battle(selection, randomSelection),
                    EnemeyWeapon = randomSelection
                };
                return Request.CreateResponse(HttpStatusCode.OK, resultModel);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

        }
    }
}