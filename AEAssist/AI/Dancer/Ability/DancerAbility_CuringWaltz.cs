using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using System.Linq;
using System.Threading.Tasks;

namespace AEAssist.AI.Dancer.Ability
{
    public class DancerAbility_CuringWaltz : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (!SpellsDefine.CuringWaltz.IsUnlock())
            {
                return -10;
            }
            if (!SpellsDefine.CuringWaltz.IsReady())
            {
                return -10;
            }
            var skillTarget = GroupHelper.CastableAlliesWithin30.Count(r => r.CurrentHealth > 0 && r.CurrentHealthPercent <= 70f);
            if (skillTarget < 4)
            {
                return -2;
            }
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.CuringWaltz.GetSpellEntity();
            if (spell == null)
                return null;
            var ret = await spell.DoAbility();
            if (ret)
                return spell;
            return null;
        }
    }
}