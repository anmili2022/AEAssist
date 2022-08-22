using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;

namespace AEAssist.AI.RedMage.Ability
{
    public class RedMageAbility_Engagement : IAIHandler
    {
        uint spell;

        public int Check(SpellEntity lastSpell)
        {
            var test = !RedMage_SpellHelper.OutOfMeleeRange();
            //LogHelper.Info($"交剑判定 目标在攻击范围内：{test.ToString()}.");
            if (!SettingMgr.GetSetting<RedMageSettings>().Engagement)
                return -5;
            
            spell = SpellsDefine.Engagement;
            if (RedMage_SpellHelper.OutOfMeleeRange()) return -1;
            if (!spell.IsReady())
                return -1;
            //LogHelper.Info($"释放交剑 目标在攻击范围内：{test.ToString()}.");
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            if (await spell.DoAbility()) return spell.GetSpellEntity();

            return null;
        }
    }

}