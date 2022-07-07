using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using System.Threading.Tasks;

namespace AEAssist.AI.Summoner.GCD
{
    public class SMNGCD_PetGarudaSlipstream : IAIHandler
    {
        uint spell = SpellsDefine.Slipstream;
        public int Check(SpellEntity lastSpell)
        {
            if (!Core.Me.HasAura(AurasDefine.GarudasFavor))
                return -3;
            if (!spell.IsReady())
                return -1;
            if (SpellsDefine.Swiftcast.IsReady() && !AIRoot.Instance.CloseBurst)
            {
                return -4;
            }

            //如果必须要读条 还有平a没打的话 先打平a
            if (!Core.Me.HasAura(AurasDefine.Swiftcast) && MovementManager.IsMoving && SMNGCD_PetBase.GetSingleTarget().IsReady())
                return -5;
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            if (await spell.DoGCD()) return spell.GetSpellEntity();

            return null;
        }
    }
}