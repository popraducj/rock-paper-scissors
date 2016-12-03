using RockPaperScissors.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RockPaperScissors.WebApi.Models
{
    public class BattleResultModel
    {
        public BattleResult Result { get; set; }
        public WeaponType EnemeyWeapon { get; set; }
    }
}