using System;
using System.Linq;
using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using Buddy.Coroutines;
using ff14bot;
using ff14bot.Helpers;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.Astrologian
{
    internal class AstSpellHelper
    {
        public static SpellEntity GetBaseGcd()
        {
            return SpellsDefine.Malefic.GetSpellEntity();
        }
        public static SpellEntity GetGravity()
        {
            if (!SpellsDefine.Gravity.IsUnlock())
            {
                LogHelper.Debug("Gravity not unlocked. skipping.");
                return null;
            }
            return SpellsDefine.Gravity.GetSpellEntity();
        }
        public static SpellEntity GetCombust()
        {
            if (!SpellsDefine.Combust.IsUnlock())
            {
                LogHelper.Debug("Combust not unlocked. skipping.");
                return null;
            }
            return SpellsDefine.Combust.GetSpellEntity();
        }
        private static int GetCombustAura()
        {
            LogHelper.Debug("Checking if Combust is unlocked...");
            if (!SpellsDefine.Combust.IsUnlock())
            {
                LogHelper.Debug("Combust not unlocked...");
                return 0;
            }
            LogHelper.Debug("Checking if Combust2 is unlocked...");
            if (!SpellsDefine.Combust2.IsUnlock())
            {
                LogHelper.Debug("Combust2 not unlocked.. trying to use Combust instead.. ");                
                return AurasDefine.Combust;
            }
            LogHelper.Debug("Checking if Combust3 is unlocked...");
            if (!SpellsDefine.Combust3.IsUnlock())
            {
                LogHelper.Debug("Combust3 not unlocked.. trying to use Combust32 instead.. ");                
                return AurasDefine.Combust2;
            }                      
            return AurasDefine.Combust3;
        }
        public static bool IsTargetHasAuraCombust(Character target)
        {
            var id = GetCombustAura();
            LogHelper.Debug("Checking if target has Combust: " + target.EnglishName);
            return id == 0 || target.HasMyAuraWithTimeleft((uint)id);
        }
        public static void RecordCombust()
        {
            var targetId = Core.Me.CurrentTarget.ObjectId;
            AIRoot.GetBattleData<AstBattleData>().lastCombustWithObj[targetId] = true;
        }
        public static void RemoveRecordCombust()
        {
            var targetId = Core.Me.CurrentTarget.ObjectId;
            AIRoot.GetBattleData<AstBattleData>().lastCombustWithObj[targetId] = false;
        }
        public static bool IsTargetNeedCombust(Character target, int timeLeft)
        {
            var CombustId = GetCombustAura();
            LogHelper.Debug("Checking if target need Combust id: " + CombustId);
            if (CombustId == 0) return false;

            var ttkAero = SettingMgr.GetSetting<AstSettings>().TTK_Aero;
            if (Core.Me.ClassLevel < 46)
            {
                ttkAero = 18;
            }
            bool NormalCheck()
            {
                if (DataBinding.Instance.EarlyDecisionMode)
                    timeLeft += SettingMgr.GetSetting<GeneralSettings>().ActionQueueMs;
                return !target.HasMyAuraWithTimeleft((uint)CombustId, timeLeft);
            }

            if (AIRoot.GetBattleData<AstBattleData>().IsTargetLastCombust()) return NormalCheck();
            if (ttkAero > 0 && target.HasMyAuraWithTimeleft((uint)CombustId, ttkAero * 1000) &&
                TTKHelper.IsTargetTTK(target, ttkAero, false))
                return NormalCheck();

            return NormalCheck();
        }
    }
}
