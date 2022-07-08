using System.Globalization;
using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;

namespace AEAssist.AI.Samurai.GCD
{
    public class SamuraiGCD_KaeshiSetsugekka : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            LogHelper.Info("Checking Kaeshi");
            if (AIRoot.GetBattleData<SamuraiBattleData>().CurrCombo == SamuraiComboStages.MidareSetsuGekka)
            {
                LogHelper.Info("Ok let's use it.");
                // AIRoot.GetBattleData<SamuraiBattleData>().Bursting = true;
                return 0;
            }
            LogHelper.Info(SpellsDefine.TsubameGaeshi.GetSpellEntity().SpellData.Charges.ToString(CultureInfo.InvariantCulture));
            if (SpellsDefine.TsubameGaeshi.GetSpellEntity().SpellData.Charges == 0)
            {
                // Not ready.
                LogHelper.Info("Note ready..");
                AIRoot.GetBattleData<SamuraiBattleData>().CurrCombo = SamuraiComboStages.None;
                return -1;
            }
            
            return -1;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.KaeshiSetsugekka.GetSpellEntity();
            if (spell == null)
                return null;
            var ret = await spell.DoGCD();
            if (ret)
            {
                AIRoot.GetBattleData<SamuraiBattleData>().CurrCombo = SamuraiComboStages.KaeshiSetsugekka;
                return spell;
            }
            return null;
        }
    }
}