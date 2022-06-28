using System;
using System.Linq;
using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using Buddy.Coroutines;
using ff14bot;
using ff14bot.Helpers;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.Astrologian.Ability
{
    internal class AstAbilityAstrodyne:IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            
            if (!SpellsDefine.Astrodyne.IsReady()) return -1;
            if (!Core.Me.HasAura(AurasDefine.Divination))
            {
                return -4;
            }
            if (AIRoot.GetBattleData<AstBattleData>().AstNum < 3)
            {
                LogHelper.Debug("印"+ Convert.ToString(AIRoot.GetBattleData<AstBattleData>().AstNum));
                return -2;
            }
            return 0;

        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.Astrodyne.GetSpellEntity();
            if (spell == null) return null;
            AIRoot.GetBattleData<AstBattleData>().AstNum = 0;
            var ret = await spell.DoAbility();            
            return ret ? spell : null;
        }
    }
}
