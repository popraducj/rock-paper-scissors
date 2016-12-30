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
    public class GameController : ApiController
    {
        //
        // GET: /Get
        [HttpGet]
        public HttpResponseMessage battle(WeaponType weaponType, string gameType = "rock-paper-scissors")
        {
            System.Threading.Thread.Sleep(2000);
            var weaponTypeLength = Enum.GetNames(typeof(WeaponType)).Length;
            if ((int)weaponType > weaponTypeLength)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            var randomWeapon = (WeaponType)new Random().Next(weaponTypeLength);
            var firstPlayer = new Player
            {
                Weapon = new Weapon
                {
                    Type = weaponType,
                    Damage = 1
                },
                Name = "Visitor",
                Strength = 1
            };
            var secondPlayer = new Player
            {
                Weapon = new Weapon
                {
                    Type = randomWeapon,
                    Damage = 1
                },
                Name = "Chuck Norris",
                Strength = 1
            };            

            try
            {
                var resultModel = new BattleResultModel(){
                    Result = new BattleRoom(gameType).Battle(firstPlayer, secondPlayer),
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