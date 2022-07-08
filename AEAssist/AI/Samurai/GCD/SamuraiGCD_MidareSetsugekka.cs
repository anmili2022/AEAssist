using System.Threading.Tasks;
using AEAssist.Define;
using ff14bot;

namespace AEAssist.AI.Samurai.GCD
{
    public class SamuraiGCD_MidareSetsugekka : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            var midareSetsugekkaCount = AIRoot.GetBattleData<SamuraiBattleData>().MidareSetsugekkaCount;
            if (SamuraiSpellHelper.SenCounts() == 3)
            {
                if (midareSetsugekkaCount < 1)
                {
                    // AIRoot.GetBattleData<SamuraiBattleData>().MidareSetsugekkaCount++;
                    return 0;
                }
                
            }

            return -1;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SamuraiSpellHelper.CoolDownPhaseGCD(Core.Me.CurrentTarget);
            if (spell == null)
                return null;
            var ret = await SamuraiSpellHelper.GetMidareSetsuGekka().DoGCD();
            if (ret)
                return spell;
            return null;
            
        }
    }
}