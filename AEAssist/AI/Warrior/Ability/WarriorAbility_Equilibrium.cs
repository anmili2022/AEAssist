using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;

namespace AEAssist.AI.Warrior.Ability
{
    public class WarriorAbility_Equilibrium : IAIHandler
    {
        uint spell = SpellsDefine.Equilibrium;

        public int Check(SpellEntity lastSpell)
        {
            if (Core.Me.CurrentHealthPercent > 30) return -1;

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