using System;
using System.Linq;
using System.Windows.Media;
using AEAssist.Define;
using AEAssist.Define.DataStruct;
using AEAssist.Helper;
using Buddy.Coroutines;
using ff14bot;
using ff14bot.Helpers;
using ff14bot.Managers;
using ff14bot.Objects;
using ff14bot.RemoteWindows;
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
    }
}