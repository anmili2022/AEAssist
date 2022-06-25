using System.Collections.Generic;
using System.Threading.Tasks;
using AEAssist.Helper;
using ff14bot.Enums;
using AEAssist.AI.Paladin.GCD;
using AEAssist.AI.Paladin.Ability;
namespace AEAssist.AI.Paladin
{
    [Job(ClassJobType.Paladin)]
    public class Paladin_AIPriorityQueue : IAIPriorityQueue
    {
        public List<IAIHandler> GCDQueue { get; } = new List<IAIHandler>()
        {
        };

        public List<IAIHandler> AbilityQueue { get; } = new List<IAIHandler>()
        {

        };
        public Task<bool> UsePotion()
        {
            return Task.FromResult(false);
        }
    }
}