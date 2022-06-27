using System.Collections.Generic;
using System.Threading.Tasks;
using AEAssist.AI.Astrologian.Ability;
using AEAssist.AI.Astrologian.GCD;
using AEAssist.Helper;
using ff14bot.Enums;

namespace AEAssist.AI.Astrologian
{
    [Job(ClassJobType.Astrologian)]
    internal class Ast_AIPriorityQueue:IAIPriorityQueue
    {
        public List<IAIHandler> GCDQueue { get; } = new List<IAIHandler>()
        {
            //new SageGCDEgeiro(),
            new AstGCDDot(),
            //new SageGcdToxikon(),
            //new SageGcdPhlegma(),
            new AstBaseGCD(),
            //new SageGCDDyskrasia(),
        };

        public List<IAIHandler> AbilityQueue { get; } = new List<IAIHandler>()
        {

            new AstAbilityDraw(),
            new AstAbilityPlay()
            //new SageAbilityLucidDreaming(),
            //new SageAbilityUsePotion(),
        };
        public async Task<bool> UsePotion()
        {
            return await PotionHelper.ForceUsePotion(SettingMgr.GetSetting<GeneralSettings>().MindPotionId);
        }
    }
}
