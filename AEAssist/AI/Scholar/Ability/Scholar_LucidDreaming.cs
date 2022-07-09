using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;

namespace AEAssist.AI.Scholar.Ability
{
    public class ScholarAbility_LucidDreaming : IAIHandler
    {
        uint spell;
        static public uint GetSpell()
        {
            if (SpellsDefine.LucidDreaming.IsReady() && Core.Me.CurrentManaPercent >= SettingMgr.GetSetting<WhiteMageSettings>().LucidDreamingTrigger+2000)
                return SpellsDefine.LucidDreaming;//醒梦
            return 0;
        }
        public int Check(SpellEntity lastSpell)
        {
            spell = GetSpell();
            
            if (!spell.IsReady())
                return -1;
            //LogHelper.Debug("NO10:" + spell.ToString());
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            if (await spell.DoAbility()) return spell.GetSpellEntity();

            return null;
        }
    }

}