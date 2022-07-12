using AEAssist.AI.Warrior.Ability;
using AEAssist.AI.Warrior.GCD;
using ff14bot.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace AEAssist.AI.Warrior
{
    [Job(ClassJobType.Warrior)]
    public class Warrior_AIPriorityQueue : IAIPriorityQueue
    {
        public List<IAIHandler> GCDQueue { get; } = new List<IAIHandler>()
        {
            //new WarriorGCD_BldeofXX(),
            //new WarriorGCD_HolySpirit(),
            //new WarriorGCD_Ranged(),
            new WarriorGCD_PrimalRend(),
            new WarriorGCD_Base()
        };

        public List<IAIHandler> AbilityQueue { get; } = new List<IAIHandler>()
        {
            new WarriorAbility_Onslaught(),//猛攻
            new WarriorAbility_Infuriate(),//战嚎
            new WarriorAbility_InnerRelease(),//原初的解放
            new WarriorAbility_Equilibrium(),//泰然自若
            new WarriorAbility_Upheaval(),//动乱
            new WarriorAbility_Orogeny(),//群山隆起
            new WarriorAbility_defense()//自主防御
        };
        public Task<bool> UsePotion()
        {
            return Task.FromResult(false);
        }
    }
}