using RockPaperScissors.BL.BattleWeapon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.BL
{
    public class Player
    {
        public string Name { get; set; }
        public double Strength { get; set; }
        public Weapon Weapon { get; set; }

        public double GetTotalDamage() 
        {
            return Strength * Weapon.Damage;
        }
    }
}
