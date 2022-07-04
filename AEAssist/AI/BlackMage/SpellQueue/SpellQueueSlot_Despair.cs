using System;
using AEAssist.Define;

namespace AEAssist.AI.BlackMage.SpellQueue
{
    public class SpellQueueSlot_Despair : IAISpellQueueSlot
    {
        public int Check(int index)
        {
            return 1;
        }

        public void Fill(SpellQueueSlot slot)
        {
            var GCDSpellId = BlackMageHelper.GetDespair().Id;
            slot.SetGCD(GCDSpellId, SpellTargetType.CurrTarget);
            if (BlackMageHelper.GetSpellCastTimeSpan(BlackMageHelper.GetDespair()) == TimeSpan.Zero)
            {
                slot.Abilitys.Enqueue((SpellsDefine.ManaFont, SpellTargetType.Self));
            }
        }
    }
}