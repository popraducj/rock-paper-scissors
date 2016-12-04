using RockPaperScissors.BL.BattleWeapon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.BL.BattleRules
{
    public class BattleRule
    {
        public Dictionary<string, double> Rules { get; internal set; }
        public string Type { get; set; }
    }
}
