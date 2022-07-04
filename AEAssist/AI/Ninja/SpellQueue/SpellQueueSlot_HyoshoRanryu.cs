using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;

namespace AEAssist.AI.Ninja.SpellQueue
{
    public class SpellQueueSlot_HyoshoRanryu : IAISpellQueueSlot
    {
        public int Check(int index)
        {
            if (!Core.Me.HasAura(AurasDefine.Kassatsu) ||
                !SpellsDefine.Kassatsu.RecentlyUsed())
            {
                return -10;
            }

            return NinjaSpellHelper.NinjutsuCheck();

        }

        public void Fill(SpellQueueSlot slot)
        {
        }
    }
}