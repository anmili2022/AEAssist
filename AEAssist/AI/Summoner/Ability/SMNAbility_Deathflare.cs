using AEAssist.Define;
using AEAssist.Helper;
using ff14bot.Managers;
using System.Threading.Tasks;

namespace AEAssist.AI.Summoner.Ability
{

    public class SMNAbility_Deathflare : IAIHandler
    {
        uint spell;
        
        uint GetSpell()
        {
            if (SMN_SpellHelper.PhoenixTrance())
                return SpellsDefine.Rekindle;
            
            return SpellsDefine.Deathflare;
        }
        
        public int Check(SpellEntity lastSpell)
        {
            spell = GetSpell();
            if (SMN_SpellHelper.PhoenixTrance())
            {
                //only at last gcd to cast to self
                if (ActionResourceManager.Summoner.TranceTimer > (int)AIRoot.Instance.GetGCDDuration())
                    return -4;
            }

            if (!spell.IsReady())
                return -1;

            if (ActionResourceManager.Summoner.TranceTimer <= 0 || SMN_SpellHelper.AnyPet())
            {
                return -3;
            }



            return 0;
        }

        public async Task<SpellEntity> Run()
        {   
            
            if (await spell.DoAbility()) return spell.GetSpellEntity();

            return null;
        }
    }
}