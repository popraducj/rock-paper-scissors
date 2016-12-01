using System.Collections.Generic;
namespace RockPaperScissors.BL.BattleWeapon
{
    public class Weapon
    {
        public List<WeaponType> Weakness { get; internal set; }

        public Weapon(List<WeaponType> weakness)
        {
            Weakness = weakness;
        }

        public WeaponType Type { get; set; }
        
    }
}
