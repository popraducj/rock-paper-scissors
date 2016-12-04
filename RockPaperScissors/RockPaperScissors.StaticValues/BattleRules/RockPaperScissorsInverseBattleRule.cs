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

            Rules = new Dictionary<string, double>();
            Rules.Add(string.Format("{0},{1}", WeaponType.Rock, WeaponType.Paper), -0.25);
            Rules.Add(string.Format("{0},{1}", WeaponType.Paper, WeaponType.Rock), 0.25);
            Rules.Add(string.Format("{0},{1}", WeaponType.Scissors, WeaponType.Rock), -0.25);
            Rules.Add(string.Format("{0},{1}", WeaponType.Rock, WeaponType.Scissors), 0.25);
            Rules.Add(string.Format("{0},{1}", WeaponType.Paper, WeaponType.Scissors), -0.25);
            Rules.Add(string.Format("{0},{1}", WeaponType.Scissors, WeaponType.Paper), 0.25);
            Rules.Add(string.Format("{0},{1}", WeaponType.Scissors, WeaponType.Scissors), 1);
            Rules.Add(string.Format("{0},{1}", WeaponType.Paper, WeaponType.Paper), 1);
            Rules.Add(string.Format("{0},{1}", WeaponType.Rock, WeaponType.Rock), 1);

            Type = "rock-paper-scissors-inverse";
        }
    }
}
