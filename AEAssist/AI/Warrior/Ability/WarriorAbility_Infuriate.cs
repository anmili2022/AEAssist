using AEAssist.Define;
using AEAssist.Helper;
using ff14bot.Managers;
using System.Threading.Tasks;

namespace AEAssist.AI.Warrior.Ability
{
    public class WarriorAbility_Infuriate : IAIHandler
    {
        uint spell = SpellsDefine.Infuriate;
        //战嚎
        public int Check(SpellEntity lastSpell)
        {
            //if (SpellsDefine.InnerRelease.GetSpellEntity().Cooldown.TotalSeconds < 10) return 0;//
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