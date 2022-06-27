using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using AEAssist.Rotations.Core;
using ff14bot.Enums;

namespace AEAssist.AI.Paladin
{
    [Job(ClassJobType.Paladin)]
    public class Paladin_Rotation : IRotation
    {
        public void Init()
        {
            //CountDownHandler.Instance.AddListener(1500,
            //    () => PotionHelper.UsePotion(SettingMgr.GetSetting<GeneralSettings>().MindPotionId));


            AEAssist.DataBinding.Instance.EarlyDecisionMode = SettingMgr.GetSetting<PaladinSettings>().EarlyDecisionMode;
        }
        public async Task<bool> PreCombatBuff()
        {

            return false;

        }

        public async Task<bool> NoTarget()
        {

            return false;
        }

        public SpellEntity GetBaseGCDSpell()
        {
            return SpellsDefine.FastBlade.GetSpellEntity();
        }
    }
}