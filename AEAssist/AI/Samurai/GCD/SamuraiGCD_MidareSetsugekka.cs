using System.Threading.Tasks;
using AEAssist.AI.Samurai.SpellQueue;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;

namespace AEAssist.AI.Samurai.GCD
{
    public class SamuraiGCD_MidareSetsugekka : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (SamuraiSpellHelper.SenCounts() == 3 && !MovementManager.IsMoving)
            {
                return 1;
            }

            return -1;
        }

        public async Task<SpellEntity> Run()
        {
            if (!Core.Me.HasAura(AurasDefine.Kaiten))
                await SpellsDefine.HissatsuKaiten.DoAbility();
            if (SpellsDefine.KaeshiSetsugekka.GetSpellEntity().SpellData.Charges > 0.99)
            {
                AISpellQueueMgr.Instance.Apply<SpellQueue_SetsugekkaCombo>();
                await Task.CompletedTask;
            }
            else
            {
                if (await SpellsDefine.MidareSetsugekka.DoGCD())
                    return SpellsDefine.MidareSetsugekka.GetSpellEntity();
            }

            return null;
        }
    }
}