using System.Linq;
using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using Buddy.Coroutines;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.Sage.GCD
{
    internal class SageGCDEukrasianDiagnosis:IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {            
            if (!MovementManager.IsMoving) return -1;
            return 0;
        }

        public  Task<SpellEntity> Run()
        {
            LogHelper.Debug("刷单盾");
            //Character character = GroupHelper.CastableAlliesWithin30.FirstOrDefault(r => r.CurrentHealth > 0 && !r.HasAura(AurasDefine.EukrasianDiagnosis) && !r.HasAura(AurasDefine.DifferentialDiagnosis));
            //var spell = SageSpellHelper.CastEukrasianDiagnosis(character);
            return SageSpellHelper.CastEukrasianDiagnosisTest();
            
        }
    }
}
