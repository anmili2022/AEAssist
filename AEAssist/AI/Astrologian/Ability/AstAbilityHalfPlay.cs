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

namespace AEAssist.AI.Astrologian.Ability
{
    internal class AstAbilityHalfPlay:IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {

            if (!SpellsDefine.Play.IsReady()) return -1;
            if (ActionResourceManager.Astrologian.Arcana == 0) return -2;
            
                if (SpellsDefine.Divination.GetSpellEntity().Cooldown.TotalSeconds > 55 && SpellsDefine.Divination.GetSpellEntity().Cooldown.TotalSeconds < 65)
                {
                    if (SettingMgr.GetSetting<AstSettings>().AstHalfCard)
                    {
                        SettingMgr.GetSetting<AstSettings>().AstHalfCard = false;
                        return 0;
                    }

                }
                return -3;
            
        }

        public Task<SpellEntity> Run()
        {
            switch (ActionResourceManager.Astrologian.Arcana)
            {
                case ActionResourceManager.Astrologian.AstrologianCard.None:
                    return null;
                case ActionResourceManager.Astrologian.AstrologianCard.Balance:
                    LogHelper.Debug("发近战太阳神");
                    return AstSpellHelper.CastMeleeCardHalf();
                case ActionResourceManager.Astrologian.AstrologianCard.Bole:
                    LogHelper.Debug("发远程世界树");
                    return AstSpellHelper.CastRangedCardHalf();
                case ActionResourceManager.Astrologian.AstrologianCard.Arrow:
                    LogHelper.Debug("发近战放浪神");
                    return AstSpellHelper.CastMeleeCardHalf();
                case ActionResourceManager.Astrologian.AstrologianCard.Spear:
                    LogHelper.Debug("发近战战争神");
                    return AstSpellHelper.CastMeleeCardHalf();
                case ActionResourceManager.Astrologian.AstrologianCard.Ewer:
                    LogHelper.Debug("发远程河流神");
                    return AstSpellHelper.CastRangedCardHalf();
                case ActionResourceManager.Astrologian.AstrologianCard.Spire:
                    LogHelper.Debug("发远程建筑神");
                    return AstSpellHelper.CastRangedCardHalf();
                default:
                    return null;
            }
            return null;
        }
    }
}
