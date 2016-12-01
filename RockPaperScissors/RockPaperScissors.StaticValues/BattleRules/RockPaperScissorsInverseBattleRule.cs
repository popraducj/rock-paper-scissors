using RockPaperScissors.BL.BattleWeapon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.BL.BattleRules
{
    public class RockPaperScissorsInverseBattleRule : BattleRule
    {
        public RockPaperScissorsInverseBattleRule()
        {
            var paper = new Paper(new List<WeaponType>(){
                WeaponType.Rock
            });
            var rock = new Rock(new List<WeaponType>(){
                WeaponType.Scissors
            });
            var scissors = new Scissors(new List<WeaponType>{
                WeaponType.Paper
            });

            Type = "rock-paper-scissors-inverse";
            Weapons = new List<Weapon>()
            {
                paper,
                rock,
                scissors
            };
        }
    }
}
