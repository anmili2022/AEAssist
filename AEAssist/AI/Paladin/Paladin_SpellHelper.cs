using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;

namespace AEAssist.AI.Paladin
{
    public static class Paladin_SpellHelper
    {

        public static bool Debugging { get; set; } = true;
     

        public static uint LastGCDSpellID()
        {
            var spell = AIRoot.GetBattleData<BattleData>().lastGCDSpell;
            if (spell == null)
                return 0;
            return spell.Id;
        }

        public static bool FightorFlightCooldownSoon()
        {
            if (!SpellsDefine.FightorFlight.IsUnlock())
                return false;

            if (Core.Me.HasAura(AurasDefine.FightOrFight))
                return false;

            if (SpellsDefine.FightorFlight.CoolDownInGCDs(2))
                return true;

            return false;
        }

        public static bool OutOfMeleeRange()
        {
            return !Core.Me.CanAttackTargetInRange(Core.Me.CurrentTarget, 3);
        }

        //AOE 这个距离判定有点迷
        public static bool OutOfAOERange()
        {
            return Core.Me.Distance(Core.Me.CurrentTarget) > 5 && OutOfMeleeRange();
        }

        public static bool CheckUseAOE(int count = 3)
        {
            if (!DataBinding.Instance.UseAOE)
                return false;

            if (TargetHelper.CheckNeedUseAOE(0, 5, count))
                return true;
            return false;
        }


    }
}