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
            if (AIRoot.GetBattleData<SamuraiBattleData>().CurrCombo == SamuraiComboStages.MidareSetsuGekka
                && SpellsDefine.TsubameGaeshi.GetSpellEntity().SpellData.Charges >= 1
                )
            {
                AIRoot.GetBattleData<SamuraiBattleData>().Bursting = true;
                return 0;
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