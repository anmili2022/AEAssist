using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using System.Threading.Tasks;

namespace AEAssist.AI.Samurai.Ability
{
    public class SamuraiAbility_MeikyoShisui : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {

            var needUseAoe = TargetHelper.CheckNeedUseAOE(2, 5);
            if (needUseAoe)
            {
                if (SpellsDefine.MeikyoShisui.IsReady())
                {
                    return 0;
                }
            }

            if (!AIRoot.GetBattleData<SamuraiBattleData>().Bursting || !AIRoot.GetBattleData<SamuraiBattleData>().EvenBursting)
            {
                return -4;
            }
            if (!SpellsDefine.MeikyoShisui.IsReady())
                return -14;
            if (Core.Me.HasAura(AurasDefine.MeikyoShisui) || SpellsDefine.MeikyoShisui.RecentlyUsed())
            {
                return -13;
            }
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.MeikyoShisui;
            if (await spell.DoAbility())
                return spell.GetSpellEntity();
            return null;
        }
    }
}