using AEAssist.Define;

namespace AEAssist.AI.GunBreaker.SpellEvent
{
    [SpellEvent(SpellsDefine.SolidBarrel)]
    public class SpellEvent_A_State : ISpellEvent
    {
        public void Run(uint spellId)
        {
            AIRoot.GetBattleData<GunBreakerBattleData>().A_State = true;
        }
    }
}