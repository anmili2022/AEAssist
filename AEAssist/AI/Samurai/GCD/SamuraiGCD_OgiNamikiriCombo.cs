using System.Threading.Tasks;
using AEAssist.AI.Samurai.SpellQueue;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Objects;

namespace AEAssist.AI.Samurai.GCD
{
    public class SamuraiGCD_OgiNamikiriCombo : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            var bd = AIRoot.GetBattleData<SamuraiBattleData>();
            if (bd.Bursting && bd.EvenBursting)
            {
                if (!SamuraiSpellHelper.TargetNeedsDot(Core.Me.CurrentTarget as Character))
                {
                    if (SamuraiSpellHelper.SenCounts() == 1)
                    {
                        return 0;
                    }
                }
            }
            return -1;
        }

        public async Task<SpellEntity> Run()
        {
            AISpellQueueMgr.Instance.Apply<SpellQueue_OgiNamikiriCombo>();
            await Task.CompletedTask;
            return null;
        }
    }
}