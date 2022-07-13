using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using System.Globalization;
using System.Threading.Tasks;

namespace AEAssist.AI.Astrologian.GCD
{
    public class AstAOE : IAIHandler
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
            var aoeChecker = TargetHelper.CheckNeedUseAOE(25, 5, 3);
            if (!aoeChecker)
            {
                return -2;
            }
            return 0;
        }
        public async Task<SpellEntity> Run()
        {
            var spell = AstSpellHelper.GetGravity();
            if (spell == null) return null;
            var ret = await spell.DoGCD();
            return ret ? spell : null;
        }
    }
}
