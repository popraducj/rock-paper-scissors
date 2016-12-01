using System.Collections.Generic;

namespace RockPaperScissors.BL.BattleWeapon
{
    public class Scissors : Weapon
    {
        public Scissors(List<WeaponType> weakness) : base(weakness) {
            Type = WeaponType.Scissors;
        }
       
    }
}
