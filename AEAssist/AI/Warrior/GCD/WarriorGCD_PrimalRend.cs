using AEAssist.Define;
using AEAssist.Helper;
using ff14bot.Managers;
using System.Threading.Tasks;

namespace AEAssist.AI.Warrior.GCD
{
    public class WarriorGCD_PrimalRend : IAIHandler
    {
        uint spell;

        public int Check(SpellEntity lastSpell)
        {
            if (!SpellsDefine.PrimalRend.IsUnlock())
                return -2;
            if (!SettingMgr.GetSetting<WarriorSettings>().WarriorPrimalRend)
                return -5;
            if (!spell.IsReady())
                return -1;
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            if (await spell.DoGCD()) return spell.GetSpellEntity();

            return null;
        }
    }
}