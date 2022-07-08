using System.Threading.Tasks;
using AEAssist.AI.Samurai.SpellQueue;
using AEAssist.Define;
using AEAssist.Helper;

namespace AEAssist.AI.Samurai.Ability
{
    public class SamuraiAbility_KaeshiSetsugekka : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            LogHelper.Info("Checking Kaeshi");
            if (AIRoot.GetBattleData<SamuraiBattleData>().CurrCombo == SamuraiComboStages.MidareSetsuGekka)
            {
                AIRoot.GetBattleData<SamuraiBattleData>().Bursting = true;
                return 0;
            }

            return -1;

        }

        public async Task<SpellEntity> Run()
        {
            AIRoot.GetBattleData<SamuraiBattleData>().CurrCombo = SamuraiComboStages.KaeshiSetsugekka;
            AISpellQueueMgr.Instance.Apply<SpellQueue_SetsugekkaCombo>();
            await Task.CompletedTask;
            return null;
        }
    }
}