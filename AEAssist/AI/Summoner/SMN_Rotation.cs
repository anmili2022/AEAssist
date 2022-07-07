using System.Threading.Tasks;
using AEAssist.AI.Summoner.GCD;
using AEAssist.Define;
using AEAssist.Helper;
using AEAssist.Rotations.Core;
using ff14bot;
using ff14bot.Enums;
using ff14bot.Managers;

namespace AEAssist.AI.Summoner
{
    [Job(ClassJobType.Summoner)]
    public class SMN_Rotation : IRotation
    {
        public void Init()
        {
            //CountDownHandler.Instance.AddListener(1500,
            //    () => PotionHelper.UsePotion(SettingMgr.GetSetting<GeneralSettings>().MindPotionId));


            CountDownHandler.Instance.AddListener(1200,
                () => SpellsDefine.Ruin.DoGCD());

            AEAssist.DataBinding.Instance.EarlyDecisionMode = DataBinding.Instance.SMNSettings.EarlyDecisionMode;
        }
        public async Task<bool> PreCombatBuff()
        {
            var summonCarbuncle = new SMNGCD_SummonCarbuncle();
            if (summonCarbuncle.Check(null) >= 0 && !Core.Me.IsMounted)
            {
                await summonCarbuncle.DelayedRun();
                return true;
            }


            return false;

        }

        public Task<bool> NoTarget()
        {

            return Task.FromResult(false);
        }

        public SpellEntity GetBaseGCDSpell()
        {
            return SMNGCD_Base.GetSpell().GetSpellEntity();
        }
    }
}