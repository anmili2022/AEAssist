using System.Globalization;
using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;

namespace AEAssist.AI.Samurai.GCD
{
    public class SamuraiGCD_CoolDownPhase : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {

            if (SamuraiSpellHelper.SenCounts() == 3)
            {
                return -1;
            }
            
            if (AIRoot.GetBattleData<SamuraiBattleData>().CurrCombo == SamuraiComboStages.MidareSetsuGekka
                && SpellsDefine.TsubameGaeshi.GetSpellEntity().SpellData.Charges >= 1)
            {
                LogHelper.Info("Pausing for a bit.");
                return -1;
            }

            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            // CoolDownPhase
            
            var spell = SamuraiSpellHelper.CoolDownPhaseGCD(Core.Me.CurrentTarget);
            if (spell == null)
                return null;
            var ret = await spell.DoGCD();
            if (ret)
                return spell;
            return null;
        }
    }
}