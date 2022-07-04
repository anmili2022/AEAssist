using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;

namespace AEAssist.AI.Samurai.GCD
{
    public class SamuraiGCD_OddMinuteBurst : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            var bd = AIRoot.GetBattleData<SamuraiBattleData>();
            if (!bd.Bursting)
            {
                return -10;
            }

            if (!bd.EvenBursting)
            {
                return 1;
            }

            if (lastSpell == SpellsDefine.MidareSetsugekka.GetSpellEntity())
            {
                bd.Bursting = false;
                bd.EvenBursting = false;
            }
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SamuraiSpellHelper.OddMinutesBurst();
            if (spell == null)
                return null;
            var ret = await spell.DoGCD();
            if (ret)
                return spell;
            return null;
        }
    }
}