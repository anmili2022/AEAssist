using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.Paladin
{
    public static class Paladin_SpellHelper
    {

        public static bool Debugging { get; set; } = true;

        public static bool FightorFlightCooldownSoon()
        {
            if (!SpellsDefine.FightorFlight.IsUnlock())
                return false;

            if (Core.Me.HasAura(AurasDefine.FightOrFight))
                return false;

            if (SpellsDefine.FightorFlight.CoolDownInGCDs(3))
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

        public static bool NeedRenewDot()
        {
            if (CheckUseAOE())
                return false;

            var target = Core.Me.CurrentTarget as Character;
            if (target == null)
                return false;

            if (!target.HasMyAuraWithTimeleft(AurasDefine.BladeOfValor, 3 * (int)AIRoot.Instance.GetGCDDuration()) && !target.HasMyAura(AurasDefine.GoringBlade))
            {
                LogHelper.Info($"Target's dot expires in {target.GetAuraById(AurasDefine.BladeOfValor).TimeLeft} ms, renewing dot.");
                return true;
            }
            if (!target.HasMyAuraWithTimeleft(AurasDefine.GoringBlade, 3 * (int)AIRoot.Instance.GetGCDDuration()) && ! target.HasMyAura(AurasDefine.BladeOfValor))
            {
                LogHelper.Info($"Target's dot expires in {target.GetAuraById(AurasDefine.GoringBlade).TimeLeft} ms, renewing dot.");
                return true;
            }
            
            return false;
        }

        public static int GCDNeededforCombo()
        {
            switch (ActionManager.LastSpellId)
            {
                case SpellsDefine.FastBlade:
                    return 2;
                case SpellsDefine.RiotBlade:
                    return 1;
                default:
                    return 3;
            }
        }



    }
}