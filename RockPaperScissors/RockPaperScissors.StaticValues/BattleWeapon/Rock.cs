using System.Collections.Generic;

namespace RockPaperScissors.BL.BattleWeapon
{
    public class Rock : Weapon
    {
        public Rock(List<WeaponType> weakness) : base(weakness) {
            Type = WeaponType.Rock;
        }
    }
}
