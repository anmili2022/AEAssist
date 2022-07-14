using AEAssist.Define;
using ff14bot.Managers;
using System.Threading.Tasks;
using ff14bot;

namespace AEAssist.AI.Astrologian.GCD
{
    public class AstBaseGCD : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {

            if (MovementManager.IsMoving)
            {
                if (!Core.Me.HasAura(AurasDefine.Lightspeed))
                {
                    return -1;
                }

            }
            return 0;

        }
        public async Task<SpellEntity> Run()
        {
            var spell = AstSpellHelper.GetBaseGcd();
            if (spell == null) return null;
            var ret = await spell.DoGCD();
            return ret ? spell : null;
        }
    }
}
