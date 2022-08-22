using AEAssist.Define;

namespace AEAssist.AI.GunBreaker.SpellEvent
{
    [SpellEvent(SpellsDefine.KeenEdge)]
    [SpellEvent(SpellsDefine.DemonSlice)]
    public class SpellEvent_A_State_Off : ISpellEvent
    {
        public void Run(uint spellId)
        {
            AIRoot.GetBattleData<GunBreakerBattleData>().A_State = false;
        }
    }
}