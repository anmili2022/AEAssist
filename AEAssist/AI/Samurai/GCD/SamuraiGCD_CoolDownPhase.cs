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
            // Pause for second to use Tsubame ability..
            if (AIRoot.GetBattleData<SamuraiBattleData>().CurrCombo == SamuraiComboStages.MidareSetsuGekka)
            {
                LogHelper.Info("Pausing for a bit.");
                return -1;
            }
            
            LogHelper.Info("Current combo: " + AIRoot.GetBattleData<SamuraiBattleData>().CurrCombo);
            
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