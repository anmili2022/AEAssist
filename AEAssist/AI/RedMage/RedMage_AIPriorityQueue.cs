using AEAssist.AI.RedMage.Ability;
using AEAssist.AI.RedMage.GCD;
using ff14bot.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AEAssist.AI.RedMage
{
    [Job(ClassJobType.RedMage)]
    public class RedMage_AIPriorityQueue : IAIPriorityQueue
    {
        public List<IAIHandler> GCDQueue { get; } = new List<IAIHandler>()
        {
            //new RedMageGCD_BldeofXX(),
            //new RedMageGCD_HolySpirit(),
            //new RedMageGCD_Ranged(),
            new RedMageGCD_Moulinet(),
            new RedMageGCD_Base()
        };

        public List<IAIHandler> AbilityQueue { get; } = new List<IAIHandler>()
        {
            //促进
            //鼓励
            new RedMageAbility_ContreSixte(),//六分反击
            new RedMageAbility_Engagement(),//交剑
            new RedMageAbility_Fleche()//飞刺
        };
        public Task<bool> UsePotion()
        {
            return Task.FromResult(false);
        }
    }
}