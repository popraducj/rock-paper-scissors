using RockPaperScissors.BL;
using RockPaperScissors.BL.BattleWeapon;
using RockPaperScissors.WebApi.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RockPaperScissors.WebApi.Controllers
{
    // /api/GameController
    public class AdvancedGameController : ApiController
    {
        //
        // GET: /Get
        [Authorize]
        [HttpGet]
        public HttpResponseMessage battle(WeaponType weaponType, string playerName, string gameType = "rock-paper-scissors")
        {
            var weaponTypeLength = Enum.GetNames(typeof(WeaponType)).Length;
            if ((int)weaponType > weaponTypeLength)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            var randomGenerator = new Random();
            var randomWeapon = (WeaponType)randomGenerator.Next(weaponTypeLength);
            var firstPlayer = new Player
            {
                Weapon = new Weapon
                {
                    Type = weaponType,
                    Damage = randomGenerator.Next(5) + 1
                },
                Name = string.IsNullOrEmpty(playerName) ? "John Doe" : playerName,
                Strength = randomGenerator.Next(5) + 5
            };
            var secondPlayer = new Player
            {
                Weapon = new Weapon
                {
                    Type = randomWeapon,
                    Damage = randomGenerator.Next(5) + 1
                },
                Name = "AI Bot",
                Strength = randomGenerator.Next(5) + 5
            };            

            try
            {
                var resultModel = new BattleResultModel(){
                    Result = new BattleRoom(gameType).Battle(firstPlayer, secondPlayer, true),
                    EnemeyWeapon = randomWeapon
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