using System.Collections.Generic;
using System.Threading.Tasks;
using AEAssist.AI.Paladin.Ability;
using AEAssist.AI.Paladin.GCD;
using ff14bot.Enums;
namespace AEAssist.AI.Paladin
{
    [Job(ClassJobType.Paladin)]
    public class Paladin_AIPriorityQueue : IAIPriorityQueue
    {
        public List<IAIHandler> GCDQueue { get; } = new List<IAIHandler>()
        {
            new PaladinGCD_Ranged(),
            new PaladinGCD_Base()
        };

        public List<IAIHandler> AbilityQueue { get; } = new List<IAIHandler>()
        {
            new PaladinAbility_FightorFlight(),
            new PaladinAbility_SpiritsWithin(),
            new PaladinAbility_CircleofScorn(),

        };
        public Task<bool> UsePotion()
        {
            return Task.FromResult(false);
        }
    }
}