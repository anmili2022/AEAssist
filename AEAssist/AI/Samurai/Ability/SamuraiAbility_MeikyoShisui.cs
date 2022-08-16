using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;
using System.Threading.Tasks;

namespace AEAssist.AI.Samurai.Ability
{
    public class SamuraiAbility_MeikyoShisui : IAIHandler//明镜止水
    {

        public int Check(SpellEntity lastSpell)
        {
            var tar = Core.Me.CurrentTarget as Character;
            var needUseAoe = TargetHelper.CheckNeedUseAOE(2, 5);
            return -1;
            if (needUseAoe)
            {
                if (SpellsDefine.MeikyoShisui.IsReady())
                {
                    return 0;
                }
            }
            if (Core.Me.HasMyAuraWithTimeleft(AurasDefine.MeikyoShisui, 1000))//如果自身有明镜buff直接跳过
                return -14;
            if (!SpellsDefine.MeikyoShisui.IsReady())//明镜cd中 跳过
                return -14;
            if (!tar.HasMyAuraWithTimeleft(AurasDefine.Higanbana, 10000))
                return 1;
            return -5;
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