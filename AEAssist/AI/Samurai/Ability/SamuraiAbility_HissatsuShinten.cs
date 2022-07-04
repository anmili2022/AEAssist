using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot.Managers;

namespace AEAssist.AI.Samurai.Ability
{
    public class SamuraiAbility_HissatsuShinten : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            var bd = AIRoot.GetBattleData<SamuraiBattleData>();

            if (SamuraiSpellHelper.SenCounts() == 3)
            {
                return -3;
            }

            if (ActionResourceManager.Samurai.Kenki == 100)
            {
                return 6;
            }

            if (ActionResourceManager.Samurai.Kenki >= 25)
            {
                if (bd.Bursting)
                {
                
                    if (bd.burstingShintenCount > 3)
                    {
                        return -1;
                    }
                    
                    if (lastSpell == SpellsDefine.Kasha.GetSpellEntity() || 
                        lastSpell == SpellsDefine.Gekko.GetSpellEntity()
                        || lastSpell == SpellsDefine.Yukikaze.GetSpellEntity())
                    {
                        
                        bd.burstingShintenCount++;
                        return 1;
                    }
                }
                
                if (bd.EvenBursting)
                {
                    if (bd.burstingShintenCount > 4)
                    {
                        return -2;
                    }
                    
                    if (lastSpell == SpellsDefine.Kasha.GetSpellEntity() || 
                        lastSpell == SpellsDefine.Gekko.GetSpellEntity()
                        || lastSpell == SpellsDefine.Yukikaze.GetSpellEntity())
                    {
                        
                        bd.burstingShintenCount++;
                        return 2;
                    }
                }
                
                // cooldown
                if (ActionManager.LastSpellId == SpellsDefine.Kasha)
                {
                    if (ActionResourceManager.Samurai.Kenki >= 60 && ActionResourceManager.Samurai.Kenki <= 100)
                    {
                        LogHelper.Debug("Inside CoolDown");
                        bd.burstingShintenCount = 0;
                        return 5;
                    }
                }
            }
            return -1;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.HissatsuShinten.GetSpellEntity();
            if (spell == null) return null;
            if (await spell.DoAbility())
                return spell;
            return null;
        }
    }
}