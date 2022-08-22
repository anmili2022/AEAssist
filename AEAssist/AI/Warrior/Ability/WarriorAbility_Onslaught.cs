using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using System.Threading.Tasks;

namespace AEAssist.AI.Warrior.Ability
{
    public class WarriorAbility_Onslaught : IAIHandler
    {
        uint spell = SpellsDefine.Onslaught;


        public int Check(SpellEntity lastSpell)
        {
            if (!SettingMgr.GetSetting<WarriorSettings>().WarriorOnslaught)
                return -5;
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