using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using System.Linq;
using System.Threading.Tasks;

namespace AEAssist.AI.Sage.GCD
{
    internal class SageGCDEukrasianPrognosis : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (!SettingMgr.GetSetting<SageSettings>().Heal)
            {
                return -2;
            }
            if (!SpellsDefine.Prognosis.IsUnlock())
            {
                return -5;
            }
            var skillTarget = GroupHelper.CastableAlliesWithin15.Count(r => r.CurrentHealth > 0 && r.CurrentHealthPercent <= 75f && !r.HasAura(AurasDefine.EukrasianPrognosis));
            LogHelper.Debug(skillTarget.ToString());
            if (skillTarget > 3)
            {
                return 0;
            }
            return -1;
        }

        public Task<SpellEntity> Run()
        {
            LogHelper.Debug("刷群盾");
            //Character character = GroupHelper.CastableAlliesWithin30.FirstOrDefault(r => r.CurrentHealth > 0 && !r.HasAura(AurasDefine.EukrasianDiagnosis) && !r.HasAura(AurasDefine.DifferentialDiagnosis));
            //var spell = SageSpellHelper.CastEukrasianDiagnosis(character);
            //return SageSpellHelper.CastEukrasianDiagnosisTest();
            return SageSpellHelper.CastEukrasianPrognosisTest();
        }
    }
}
