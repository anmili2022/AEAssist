using AEAssist.Define;
using AEAssist.Helper;
using System.Threading.Tasks;
namespace AEAssist.AI.Warrior.Ability
{
    public class WarriorAbility_InnerRelease : IAIHandler
    {
        uint spell;

        public int Check(SpellEntity lastSpell)
        {
            spell = SpellsDefine.InnerRelease;
            if (SpellsDefine.Infuriate.IsReady()) return -1;//打完战嚎再放原初的解放
            if (!SpellsDefine.InnerRelease.IsUnlock()) spell = SpellsDefine.Berserk;
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