using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
namespace AEAssist.AI.Paladin.Ability
{
    public class PaladinAbility_FightorFlight : IAIHandler
    {
        uint spell = SpellsDefine.FightorFlight;
       
        public int Check(SpellEntity lastSpell)
        {

            if (!spell.IsReady())
                return -1;
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            if (await spell.DoAbility()) return spell.GetSpellEntity();

            return null;
        }
    }
}