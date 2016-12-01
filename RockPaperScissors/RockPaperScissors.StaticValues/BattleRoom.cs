using RockPaperScissors.BL.BattleRules;
using RockPaperScissors.BL.BattleWeapon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.BL
{
    public class BattleRoom
    {
        private List<Weapon> weapons;

        public BattleRoom(string rule)
        {
            var rules = new List<BattleRule>()
            {
                new RockPaperScissorsBattleRule(),
                new RockPaperScissorsInverseBattleRule()
            };
            var battleRule = rules.Where(r => r.Type.Equals(rule)).First();
            if (battleRule != null)
            {
                weapons = battleRule.Weapons;
            }
            else
            {
                throw new Exception("not a valid battle rule");
            }
        }

        public BattleResult Battle(WeaponType firstWeaponType, WeaponType secondWeaponType)
        {
            if (firstWeaponType.Equals(secondWeaponType))
            {
                return BattleResult.Equal;
            }
            else 
            {
                var firstWeapon = weapons.Find(x => x.Type.Equals(firstWeaponType));
                if (firstWeapon.Weakness.Where(s => s.Equals(secondWeaponType)).Count() == 1)
                {
                    return BattleResult.Lose;
                }
                return BattleResult.Win; 
            }
        }
    }
}
