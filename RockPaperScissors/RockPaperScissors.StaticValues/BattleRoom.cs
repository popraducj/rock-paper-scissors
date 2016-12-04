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
        private Dictionary<string, double> _rules;

        public BattleRoom(string rule)
        {
            var rules = new List<BattleRule>()
            {
                new RockPaperScissorsBattleRule(),
                new RockPaperScissorsInverseBattleRule()
            };
            var battleRule = rules.Where(r => r.Type.Equals(rule)).FirstOrDefault();
            if (battleRule != null)
            {
                _rules = battleRule.Rules;
            }
            else
            {
                throw new Exception("Not a valid battle rule");
            }
        }

        public BattleResult Battle(Player firstPlayer, Player secondPlayer, bool isAdvanced = false)
        {
            var playerDamageRatio = 1.0;
            if (!_rules.TryGetValue(string.Format("{0},{1}", firstPlayer.Weapon.Type, secondPlayer.Weapon.Type), out playerDamageRatio))
            {
                throw new Exception(string.Format("Not a valid battle {0} against {1}!", firstPlayer.Weapon.Type, secondPlayer.Weapon.Type));

            }
            var result = "The player {0} has Won by inflicting {1} damage while {2} have done only {3}";
            var battleResult = new BattleResult();
            var firstPlayerDamage = firstPlayer.GetTotalDamage();
            var secondPlayerDamage = secondPlayer.GetTotalDamage();
            if (playerDamageRatio > 0)
            {
                firstPlayerDamage *= playerDamageRatio;
            }
            else
            {
                secondPlayerDamage *= -1 * playerDamageRatio;
            }

            if (firstPlayerDamage > secondPlayerDamage)
            {
                result = isAdvanced ? string.Format(result, firstPlayer.Name, firstPlayerDamage, secondPlayer.Name, secondPlayerDamage) : "You have won!";
                battleResult.BattleResultType = BattleResultType.Win;
            }
            else if (firstPlayerDamage < secondPlayerDamage)
            {
                result = isAdvanced ? string.Format(result, secondPlayer.Name, secondPlayerDamage, firstPlayer.Name, firstPlayerDamage) : "Unfortunately you have lost.";
                battleResult.BattleResultType = BattleResultType.Lose;
            }
            else
            {
                result = isAdvanced ? string.Format("Both {0} and {1} have done {2} damage. This is a draw.", firstPlayer.Name, secondPlayer.Name, firstPlayerDamage): "This is a draw. Not bad!";
                battleResult.BattleResultType = BattleResultType.Draw;
            }
           

            battleResult.Message = result;
            return battleResult;
        }
    }
}
