using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using System.Threading.Tasks;

namespace AEAssist.AI.Warrior.Ability
{
    public class WarriorAbility_Upheaval : IAIHandler
    {
        uint spell = SpellsDefine.Upheaval;

        public int Check(SpellEntity lastSpell)
        {
            if (TargetHelper.CheckNeedUseAOEByMe(5, 5, 2)) return -1;

            if (!spell.IsReady())
                return -1;

            if (AIRoot.Instance.CloseBurst)
                return -2;

            if (Warrior_SpellHelper.OutOfMeleeRange())
                return -4;
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            if (await spell.DoAbility()) return spell.GetSpellEntity();

            return null;
        }
    }
}