using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
namespace AEAssist.AI.Paladin
{
    public static class Paladin_SpellHelper
    {

        public static bool Debugging { get; set; } = true;
        public static bool CheckUseAOE()
        {
            return false;
        }

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
            return Core.Me.CanAttackTargetInRange(Core.Me.CurrentTarget, 3);
        }
        public static bool OutOfAOERange()
        {
            return Core.Me.CanAttackTargetInRange(Core.Me.CurrentTarget, 5);
        }
    }
}