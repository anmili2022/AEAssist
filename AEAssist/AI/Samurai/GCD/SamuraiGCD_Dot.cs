using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;
using ff14bot.Managers;
using System.Threading.Tasks;

namespace AEAssist.AI.Samurai.GCD
{
    public class SamuraiGCD_Dot : IAIHandler
    {
        uint spell = SpellsDefine.Higanbana;
        public int Check(SpellEntity lastSpell)
        {
            var tar = Core.Me.CurrentTarget as Character;
            bool hasHig = tar.HasMyAuraWithTimeleft(AurasDefine.Higanbana, 10000);
            return -1;
            if (hasHig)//不需要补dot直接跳过
                return -1;
            if (SamuraiSpellHelper.SenCounts()>1)
                return -1;

                if (ActionManager.LastSpellId == 7477)//如果已经释放刃风就打雪风
                    spell = SpellsDefine.Yukikaze;
                else
                    spell = SpellsDefine.Hakaze;

            if(Core.Me.HasMyAuraWithTimeleft(AurasDefine.MeikyoShisui, 1000))//如果自身有明镜buff直接打雪风
                spell = SpellsDefine.Yukikaze;

            if (!hasHig && SamuraiSpellHelper.SenCounts() == 1)//需要补dot并且有闪就打彼岸花
                spell = SpellsDefine.Higanbana;

            //LogHelper.Info($"闪的数量为：{SamuraiSpellHelper.SenCounts()},{hasHig}，dot需要补吗 {adddot}");
            if (!spell.IsReady())
                return -1;
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            if (await spell.DoGCD()) return spell.GetSpellEntity();

            return null;
        }
    }
}