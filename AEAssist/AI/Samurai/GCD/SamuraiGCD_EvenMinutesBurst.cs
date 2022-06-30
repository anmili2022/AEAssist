using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;

namespace AEAssist.AI.Samurai.GCD
{
    public class SamuraiGCD_EvenMinutesBurst : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            var bd = AIRoot.GetBattleData<SamuraiBattleData>();
            if (!bd.Bursting)
            {
                return -10;
            }

            if (bd.EvenBursting)
            {
                return 1;
            }
            if (lastSpell == SpellsDefine.MidareSetsugekka.GetSpellEntity())
            {
                bd.Bursting = false;
                bd.EvenBursting = false;
            }
            return -1;
        }

        public async Task<SpellEntity> Run()
        {
            return await SamuraiSpellHelper.EvenMinutesBurst();
        }
    }
}