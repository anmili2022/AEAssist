using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot.Managers;

namespace AEAssist.AI.Paladin.Ability
{
    public class PaladinAbility_Intervene : IAIHandler
    {
        uint spell = SpellsDefine.Intervene;
       
        public int Check(SpellEntity lastSpell)
        {
            
            if (!spell.IsReady())
                return -1;
            if (!DataBinding.Instance.Intervene)
                return -2;
            if (MovementManager.IsMoving)
                return -3;
            if (AIRoot.Instance.CloseBurst)
                if (spell.GetSpellEntity().SpellData.Charges > 1.9)
                    return 1;
                else return -4;
            if (SpellsDefine.FightorFlight.IsReady()||SpellsDefine.FightorFlight.CoolDownInGCDs(3))
                return -2;
            if (Paladin_SpellHelper.OutOfMeleeRange())
                return 2;
            
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            if (await spell.DoAbility()) return spell.GetSpellEntity();

            return null;
        }
    }

}