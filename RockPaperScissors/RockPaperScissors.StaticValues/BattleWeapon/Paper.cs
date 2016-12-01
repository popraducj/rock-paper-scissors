using System.Collections.Generic;

namespace RockPaperScissors.BL.BattleWeapon
{
    public class Paper : Weapon
    {
        public Paper(List<WeaponType> weakness) : base(weakness) {
            Type = WeaponType.Paper;
        }
    }
}
