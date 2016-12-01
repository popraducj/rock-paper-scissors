using RockPaperScissors.BL.BattleWeapon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.BL.BattleRules
{
    public class RockPaperScissorsBattleRule : BattleRule
    {
        public RockPaperScissorsBattleRule()
        {
            var paper = new Paper(new List<WeaponType>(){
                WeaponType.Scissors
            });
            var rock = new Rock(new List<WeaponType>(){
                WeaponType.Paper
            });
            var scissors = new Scissors(new List<WeaponType>{
                WeaponType.Rock
            });

            Type = "rock-paper-scissors";
            Weapons = new List<Weapon>()
            {
                paper,
                rock,
                scissors
            };
        }
    }
}
