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
    internal class AstAbilityLightspeed:IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (!SpellsDefine.Lightspeed.IsReady()) return -1;
            if (SpellsDefine.Divination.GetSpellEntity().Cooldown.TotalSeconds > 3) return -2;
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.Lightspeed.GetSpellEntity();
            if (spell == null) return null;            
            var ret = await spell.DoAbility();
            return ret ? spell : null;
        }
    }
}
