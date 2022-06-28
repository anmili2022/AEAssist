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
using ff14bot.Enums;

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
        private static int GetWeight(Character c)
        {
            switch (c.CurrentJob)
            {
                case ClassJobType.Astrologian:
                    return SettingMgr.GetSetting<AstSettings>().AstCardWeight;

                case ClassJobType.Monk:
                case ClassJobType.Pugilist:
                    return SettingMgr.GetSetting<AstSettings>().MnkCardWeight;

                case ClassJobType.BlackMage:
                case ClassJobType.Thaumaturge:
                    return SettingMgr.GetSetting<AstSettings>().BlmCardWeight;

                case ClassJobType.Dragoon:
                case ClassJobType.Lancer:
                    return SettingMgr.GetSetting<AstSettings>().DrgCardWeight;

                case ClassJobType.Samurai:
                    return SettingMgr.GetSetting<AstSettings>().SamCardWeight;

                case ClassJobType.Machinist:
                    return SettingMgr.GetSetting<AstSettings>().MchCardWeight;

                case ClassJobType.Summoner:
                case ClassJobType.Arcanist:
                    return SettingMgr.GetSetting<AstSettings>().SmnCardWeight;

                case ClassJobType.Bard:
                case ClassJobType.Archer:
                    return SettingMgr.GetSetting<AstSettings>().BrdCardWeight;

                case ClassJobType.Ninja:
                case ClassJobType.Rogue:
                    return SettingMgr.GetSetting<AstSettings>().NinCardWeight;

                case ClassJobType.RedMage:
                    return SettingMgr.GetSetting<AstSettings>().RdmCardWeight;

                case ClassJobType.Dancer:
                    return SettingMgr.GetSetting<AstSettings>().DncCardWeight;

                case ClassJobType.Paladin:
                case ClassJobType.Gladiator:
                    return SettingMgr.GetSetting<AstSettings>().PldCardWeight;

                case ClassJobType.Warrior:
                case ClassJobType.Marauder:
                    return SettingMgr.GetSetting<AstSettings>().WarCardWeight;

                case ClassJobType.DarkKnight:
                    return SettingMgr.GetSetting<AstSettings>().DrkCardWeight;

                case ClassJobType.Gunbreaker:
                    return SettingMgr.GetSetting<AstSettings>().GnbCardWeight;

                case ClassJobType.WhiteMage:
                case ClassJobType.Conjurer:
                    return SettingMgr.GetSetting<AstSettings>().WhmCardWeight;

                case ClassJobType.Scholar:
                    return SettingMgr.GetSetting<AstSettings>().SchCardWeight;

                case ClassJobType.Reaper:
                    return SettingMgr.GetSetting<AstSettings>().RprCardWeight;

                case ClassJobType.Sage:
                    return SettingMgr.GetSetting<AstSettings>().SgeCardWeight;

                case ClassJobType.BlueMage:
                    return SettingMgr.GetSetting<AstSettings>().BluCardWeight;
            }

            return c.CurrentJob == ClassJobType.Adventurer ? 70 : 0;
        }
        public static async Task<SpellEntity> CastMeleeCard()
        {

            if (GroupHelper.InParty)
            {
                var skillTarget = GroupHelper.CastableAlliesWithin30.Where(a => !a.HasMyAura(AurasDefine.TheArrow) && !a.HasMyAura(AurasDefine.TheBalance) && !a.HasMyAura(AurasDefine.TheSpear) &&  a.CurrentHealth > 0 && (a.IsTank() || a.IsMeleeDps())).OrderBy(GetWeight);
                LogHelper.Debug(Convert.ToString(skillTarget));
                LogHelper.Debug(Convert.ToString(skillTarget.FirstOrDefault()));
                var skillt = GroupHelper.CastableAlliesWithin30;
                foreach (Character chara in skillTarget)
                    LogHelper.Debug(Convert.ToString(chara));
                foreach (Character chara in skillt)
                    LogHelper.Debug(Convert.ToString(chara) + Convert.ToString(chara.IsMeleeDps()));
                if (skillTarget.FirstOrDefault() == null)
                    return null;
                
                //return await Spells.Play.Cast(ally.FirstOrDefault());
                //var skillTarget = GroupHelper.CastableAlliesWithin30.FirstOrDefault(r => r.CurrentHealth > 0 && r.CurrentHealthPercent <= SettingMgr.GetSetting<WhiteMageSettings>().TetragrammatonHp);
                if (!SpellsDefine.Draw.IsUnlock()) return null;
                var spell = new SpellEntity(SpellsDefine.Play, skillTarget.FirstOrDefault() as BattleCharacter);
                AIRoot.GetBattleData<AstBattleData>().AstNum = AIRoot.GetBattleData<AstBattleData>().AstNum + 1;
                await spell.DoAbility();                
                //await CastTetragrammaton(skillTarget);
            }
            return null;
        }
        public static async Task<SpellEntity> CastRangedCard()
        {

            if (GroupHelper.InParty)
            {
                var skillTarget = GroupHelper.CastableAlliesWithin30.Where(a => !a.HasMyAura(AurasDefine.TheBole) && !a.HasMyAura(AurasDefine.TheEwer) && !a.HasMyAura(AurasDefine.TheSpire) && a.CurrentHealth > 0 && (a.IsRangedDpsCard())).OrderBy(GetWeight);
                LogHelper.Debug(Convert.ToString(skillTarget));
                LogHelper.Debug(Convert.ToString(skillTarget.FirstOrDefault()));
                var skillt = GroupHelper.CastableAlliesWithin30;
                foreach (Character chara in skillt)
                    LogHelper.Debug(Convert.ToString(chara) + Convert.ToString(chara.IsRangedDpsCard()));
                foreach (Character chara in skillTarget)
                    LogHelper.Debug(Convert.ToString(chara));
                if (skillTarget.FirstOrDefault() == null)
                    return null;

                //return await Spells.Play.Cast(ally.FirstOrDefault());
                //var skillTarget = GroupHelper.CastableAlliesWithin30.FirstOrDefault(r => r.CurrentHealth > 0 && r.CurrentHealthPercent <= SettingMgr.GetSetting<WhiteMageSettings>().TetragrammatonHp);
                if (!SpellsDefine.Draw.IsUnlock()) return null;
                var spell = new SpellEntity(SpellsDefine.Play, skillTarget.FirstOrDefault() as BattleCharacter);
                AIRoot.GetBattleData<AstBattleData>().AstNum = AIRoot.GetBattleData<AstBattleData>().AstNum + 1;
                await spell.DoAbility();               
                //await CastTetragrammaton(skillTarget);
            }
            return null;
        }

    }
}
