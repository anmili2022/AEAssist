using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;

namespace AEAssist.AI.Paladin.Ability
{
    public class PaladinAbility_FightorFlight : IAIHandler
    {
        uint spell = SpellsDefine.FightorFlight;


        public int Check(SpellEntity lastSpell)
        {
            if (!spell.IsReady())
                return -1;

            if (AIRoot.Instance.CloseBurst)
                return -2;


            if (!AIRoot.Instance.Is2ndAbilityTime())
                return -3;

            //add setting when to use fof
            if (Paladin_SpellHelper.LastGCDSpellID() != SpellsDefine.RiotBlade)

                return -4;

            if (Core.Me.HasAura(AurasDefine.Requiescat))
                return -5;

            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            if (await spell.DoAbility()) return spell.GetSpellEntity();

            return null;
        }
    }
}