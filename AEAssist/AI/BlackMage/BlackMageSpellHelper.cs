﻿using AEAssist.Define;
using AEAssist.Define.DataStruct;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.BlackMage
{
    public static class BlackMageHelper
    {
        public static bool CanCastFire4(SpellEntity lastSpell)
        {
            if (Core.Me.CurrentMana >= 2400 &&
                BlackMageHelper.IsMaxAstralStacks(lastSpell))
            {
                // not sure what numbders excatly to put here
                if (Core.Me.HasAura(AurasDefine.LeyLines) &&
                    ActionResourceManager.BlackMage.StackTimer.TotalMilliseconds > 4500)
                {
                    return true;
                }
                else if (ActionResourceManager.BlackMage.StackTimer.TotalMilliseconds > 5000)
                {
                    return true;
                }
            }

            return false;
        }

        public static ushort PolyglotTimer => ActionResourceManager.CostTypesStruct.timer;

        public static bool IsTargetNeedThunder(Character target, int timeLeft)
        {
            // check thunder 4,3,2,1
            var thunder4 = AurasDefine.Thunder4;
            var thunder3 = AurasDefine.Thunder3;
            var thunder2 = AurasDefine.Thunder2;
            var thunder1 = AurasDefine.Thunder;

            // if target has no dot from me, target needs dot
            if (!target.ContainMyAura((uint) thunder4) &&
                !target.ContainMyAura((uint) thunder3) &&
                !target.ContainMyAura((uint) thunder2) &&
                !target.ContainMyAura((uint) thunder1)
               )
            {
                return true;
            }

            // if not enough time left
            if (target.ContainMyAura((uint) thunder4) && 
                !target.ContainMyAura((uint) thunder4, timeLeft))
            {
                return true;
            }

            if (target.ContainMyAura((uint) thunder3) && 
                !target.ContainMyAura((uint) thunder3, timeLeft))
            {
                return true;
            }

            if (target.ContainMyAura((uint) thunder2) && 
                !target.ContainMyAura((uint) thunder2, timeLeft))
            {
                return true;
            }

            if (target.ContainMyAura((uint) thunder1) && 
                !target.ContainMyAura((uint) thunder1, timeLeft))
            {
                return true;
            }

            return false;
        }

        public static bool LearnedParadox()
        {
            return Core.Me.ClassLevel >= ConstValue.ParadoxLevelAcquired;
        }
        
        public static bool IsParadoxReady()
        {
            var spell = SpellsDefine.Paradox.GetSpellEntity().SpellData;
            if (ActionManager.CanCastOrQueue(spell, Core.Me.CurrentTarget))
            {
                return true;
            }

            return false;
        }

        public static SpellEntity GetBlizzard3()
        {
            if (DataBinding.Instance.UseAOE)
            {
                var aoeCount = TargetHelper.GetNearbyEnemyCount(Core.Me.CurrentTarget, 25, 5);
                if (aoeCount >= ConstValue.BlackMageAOECount)
                {
                    if (SpellsDefine.HighBlizzardII.IsUnlock())
                    {
                        return SpellsDefine.HighBlizzardII.GetSpellEntity();
                    }

                    // blizzard2 100 * 3 > blizzard3 260
                    if (aoeCount >= 3)
                    {
                        if (SpellsDefine.Blizzard2.IsUnlock())
                        {
                            return SpellsDefine.Blizzard2.GetSpellEntity();
                        }
                    }
                }
            }

            if (SpellsDefine.Blizzard3.IsUnlock())
            {
                return SpellsDefine.Blizzard3.GetSpellEntity();
            }

            return null;
        }

        public static SpellEntity GetDespair()
        {
            if (DataBinding.Instance.UseAOE)
            {
                var aoeCount = TargetHelper.GetNearbyEnemyCount(Core.Me.CurrentTarget, 25, 5);
                if (aoeCount >= ConstValue.BlackMageAOECount)
                {
                    if (SpellsDefine.Flare.IsUnlock())
                    {
                        return SpellsDefine.Flare.GetSpellEntity();
                    }
                }
            }
            if (SpellsDefine.Despair.IsUnlock())
            {
                return SpellsDefine.Despair.GetSpellEntity();
            }
            return null;
        }

        public static SpellEntity GetXenoglossy()
        {
            if (DataBinding.Instance.UseAOE)
            {
                var aoeCount = TargetHelper.GetNearbyEnemyCount(Core.Me.CurrentTarget, 25, 5);
                if (aoeCount >= ConstValue.BlackMageAOECount)
                {
                    if (SpellsDefine.Foul.IsUnlock())
                    {
                        return SpellsDefine.Foul.GetSpellEntity();
                    }
                }
            }
            if (SpellsDefine.Xenoglossy.IsUnlock())
            {
                return SpellsDefine.Xenoglossy.GetSpellEntity();
            }
            return null;
        }
        
        
        
        public static SpellEntity GetParadox()
        {
            // if we learned paradox, go only paradox
            if (BlackMageHelper.LearnedParadox())
            {
                if (BlackMageHelper.IsParadoxReady())
                {
                    return SpellsDefine.Paradox.GetSpellEntity();
                }
                LogHelper.Debug("Paradox is learned");
                return null;
            }
            // if we have not learned paradox, replace fire paradox with fire, nothing to go in ice
            // if (ActionResourceManager.BlackMage.AstralStacks > 0)
            // {
                if (SpellsDefine.Fire.IsUnlock())
                {
                    return SpellsDefine.Fire.GetSpellEntity();
                }
            // }

            return null;
        }

        public static SpellEntity GetBlizzard4()
        {
            if (DataBinding.Instance.UseAOE)
            {
                var aoeCount = TargetHelper.GetNearbyEnemyCount(Core.Me.CurrentTarget, 25, 5);
                // freeze 120 * 3 > blizzard4 310
                if (aoeCount >= 3)
                {
                    if (SpellsDefine.Freeze.IsUnlock())
                    {
                        return SpellsDefine.Freeze.GetSpellEntity();
                    }
                }
            }
            if (SpellsDefine.Blizzard4.IsUnlock())
            {
                return SpellsDefine.Blizzard4.GetSpellEntity();
            }
            return null;
        }

        public static SpellEntity GetThunder()
        {
            if (DataBinding.Instance.UseAOE)
            {
                var aoeCount = TargetHelper.GetNearbyEnemyCount(Core.Me.CurrentTarget, 25, 5);
                // thunder4 20 * 2 > thunder 3 35
                if (aoeCount >= ConstValue.BlackMageAOECount)
                {
                    if (SpellsDefine.Thunder4.IsUnlock())
                    {
                        return SpellsDefine.Thunder4.GetSpellEntity();
                    }
                    
                    if (SpellsDefine.Thunder2.IsUnlock())
                    {
                        return SpellsDefine.Thunder2.GetSpellEntity();
                    }

                    // thunder2 15 * 3 > thunder2 35
                    else
                    {
                        if (SpellsDefine.Thunder2.IsUnlock())
                        {
                            return SpellsDefine.Thunder2.GetSpellEntity();
                        }
                    }
                }
            }
            if (SpellsDefine.Thunder3.IsUnlock())
            {
                return SpellsDefine.Thunder3.GetSpellEntity();
            }
            
            if (SpellsDefine.Thunder.IsUnlock())
            {
                return SpellsDefine.Thunder.GetSpellEntity();
            }

            return null;
        }

        public static SpellEntity GetFire2()
        {
            if (SpellsDefine.HighFireII.IsUnlock())
            {
                return SpellsDefine.HighFireII.GetSpellEntity();
            }

            if (SpellsDefine.Fire2.IsUnlock())
            {
                return SpellsDefine.Fire2.GetSpellEntity();
            }

            return null;
        }
        
        public static SpellEntity GetFire4()
        {
            if (SpellsDefine.Fire4.IsUnlock())
            {
                return SpellsDefine.Fire4.GetSpellEntity();
            }

            if (SpellsDefine.Fire.IsUnlock())
            {
                return SpellsDefine.Fire.GetSpellEntity();
            }

            return null;
        }

        public static bool InstantCasting()
        {
            if (Core.Me.HasAura(AurasDefine.Triplecast) || Core.Me.HasAura(AurasDefine.Swiftcast))
            {
                return true;
            }

            return false;
        }
        
        public static bool UmbralHeatsReady()
        {
            // so this shit is, we need lv58 to have umbral hearts, and no requirements
            // and lv58, we need to finish request for have the blizzard4 to single target
            
            // if we can't even have  umbralhearts, always pass the check
            if (Core.Me.ClassLevel < 58)
            {
                return true;
            }

            if (ActionResourceManager.BlackMage.UmbralHearts == 3)
            {
                return true;
            }

            return false;

        }

        public static bool IsMaxAstralStacks(SpellEntity lastSpell)
        {
            if (ActionResourceManager.BlackMage.AstralStacks == 3)
            {
                return true;
            }

            if (lastSpell == SpellsDefine.Fire2.GetSpellEntity() ||
                lastSpell == SpellsDefine.Fire3.GetSpellEntity() ||
                lastSpell == SpellsDefine.HighFireII.GetSpellEntity()
               )
            {
                return true;
            }

            return false;
        }

        public static bool IsUmbralFinished()
        {
            // if we are in ice
            if (ActionResourceManager.BlackMage.UmbralStacks > 0)
            {
                if (BlackMageHelper.UmbralHeatsReady() &&
                    BlackMageHelper.IsParadoxReady() &&
                    Core.Me.CurrentMana == 10000)
                {
                    return true;
                }
            }

            return false;
        }
        
        public static bool IsGCDOpen(SpellEntity lastSpell)
        {
            if (Core.Me.HasAura(AurasDefine.Triplecast))
            {
                return true;
            }

            if (lastSpell == SpellsDefine.Fire3.GetSpellEntity() ||
                lastSpell == SpellsDefine.Blizzard3.GetSpellEntity())
            {
                return true;
            }

            return false;
        }
    }
}