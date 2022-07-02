using AEAssist.Define;

namespace AEAssist.AI.Samurai.SpellQueue
{
    public class SpellQueueSlot_KaeshiNamikiri : IAISpellQueueSlot
    {
        public int Check(int index)
        {
            return 0;
        }

        public void Fill(SpellQueueSlot slot)
        {
            slot.SetGCDQueue((SpellsDefine.OgiNamikiri, SpellTargetType.CurrTarget),
                (SpellsDefine.KaeshiNamikiri, SpellTargetType.CurrTarget));
        }
    }
}