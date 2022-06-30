using System;
using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using AEAssist.Rotations.Core;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.Samurai
{
    public class SamuraiSpellHelper
    {
        public static SpellEntity GetBaseSpell()
        {
            if (!Core.Me.HasAura(AurasDefine.MeikyoShisui))
            {
                if (ActionManager.LastSpellId == SpellsDefine.Hakaze)
                {
                    if (!ActionResourceManager.Samurai.Sen.HasFlag(ActionResourceManager.Samurai.Iaijutsu.Setsu))
                        return SpellsDefine.Yukikaze.GetSpellEntity();
                    if (Core.Me.GetAuraById(AurasDefine.Shifu)?.TimeLeft <
                        Core.Me.GetAuraById(AurasDefine.Jinpu)?.TimeLeft ||
                        !Core.Me.HasAura(AurasDefine.Shifu))
                        return SpellsDefine.Shifu.GetSpellEntity();
                    return SpellsDefine.Jinpu.GetSpellEntity();
                }

                if (ActionManager.LastSpellId == SpellsDefine.Shifu)
                    return SpellsDefine.Kasha.GetSpellEntity();
                if (ActionManager.LastSpellId == SpellsDefine.Jinpu)
                    return SpellsDefine.Gekko.GetSpellEntity();
                return SpellsDefine.Hakaze.GetSpellEntity();
            }

            if (Core.Me.HasAura(AurasDefine.MeikyoShisui))
            {
                if (!ActionResourceManager.Samurai.Sen.HasFlag(ActionResourceManager.Samurai.Iaijutsu.Ka))
                    return SpellsDefine.Kasha.GetSpellEntity();
                if (!ActionResourceManager.Samurai.Sen.HasFlag(ActionResourceManager.Samurai.Iaijutsu.Getsu))
                    return SpellsDefine.Gekko.GetSpellEntity();
                if (!ActionResourceManager.Samurai.Sen.HasFlag(ActionResourceManager.Samurai.Iaijutsu.Setsu))
                    return SpellsDefine.Yukikaze.GetSpellEntity();
            }

            return null;
        }

        // public static bool IsMidareSetsugekkaReady()
        // {
        //     if (ActionResourceManager.Samurai.Sen.HasFlag(ActionResourceManager.Samurai.Iaijutsu.Ka) &&
        //         ActionResourceManager.Samurai.Sen.HasFlag(ActionResourceManager.Samurai.Iaijutsu.Getsu) &&
        //         ActionResourceManager.Samurai.Sen.HasFlag(ActionResourceManager.Samurai.Iaijutsu.Setsu))
        //     {
        //         return true;
        //     }
        //
        //     return false;
        // }
        
        public static SpellEntity CoolDownPhaseGCD(GameObject target)
        {
            // https://www.thebalanceffxiv.com/jobs/melee/samurai/basic-guide/
            // Hakaze -> Yukikaze -> Hakaze -> Jinpu -> Gekko -> Hakaze -> Shifu -> Kasha -> Midare Setsugekka -> repeat
            // refer to the balance level 90 samurai
            var lastGCD = ActionManager.LastSpellId;
            
            if (SenCounts() == 3)
            {
                return SpellsDefine.MidareSetsugekka.GetSpellEntity();
            }
            
            if (lastGCD == SpellsDefine.Hakaze)
            {
                if (!ActionResourceManager.Samurai.Sen.HasFlag(ActionResourceManager.Samurai.Iaijutsu.Setsu))
                {
                    return SpellsDefine.Yukikaze.GetSpellEntity();
                }
                if (!ActionResourceManager.Samurai.Sen.HasFlag(ActionResourceManager.Samurai.Iaijutsu.Getsu))
                {
                    return SpellsDefine.Jinpu.GetSpellEntity();
                }
                if (!ActionResourceManager.Samurai.Sen.HasFlag(ActionResourceManager.Samurai.Iaijutsu.Ka))
                {
                    return SpellsDefine.Shifu.GetSpellEntity();
                }
            }

            if (lastGCD == SpellsDefine.Jinpu)
            {
                return SpellsDefine.Gekko.GetSpellEntity();
            }

            if (lastGCD == SpellsDefine.Shifu)
            {
                return SpellsDefine.Kasha.GetSpellEntity();
            }

            return SpellsDefine.Hakaze.GetSpellEntity();
            
        }

        public static  SpellEntity OddMinutesBurst()
        {
            // https://www.thebalanceffxiv.com/jobs/melee/samurai/basic-guide/
            // get battle time first

            // do odd minute bursts

            if (SamuraiSpellHelper.SenCounts() == 3)
            {
                return SpellsDefine.MidareSetsugekka.GetSpellEntity();
            }

            if (SpellsDefine.MeikyoShisui.RecentlyUsed() || Core.Me.HasMyAura(AurasDefine.MeikyoShisui))
            {
                if (SenCounts() < 1)
                {
                    return SpellsDefine.Gekko.GetSpellEntity();
                }

                return SpellsDefine.Kasha.GetSpellEntity();
            }

            if (ActionManager.LastSpellId == SpellsDefine.Hakaze)
            {
                return SpellsDefine.Yukikaze.GetSpellEntity();
            }

            return SpellsDefine.Hakaze.GetSpellEntity();
        }
        
        public static async Task<SpellEntity> EvenMinutesBurst()
        {
            // https://www.thebalanceffxiv.com/jobs/melee/samurai/basic-guide/
            if (SamuraiSpellHelper.SenCounts() == 3)
            {
                return SpellsDefine.MidareSetsugekka.GetSpellEntity();
            }

            if (SpellsDefine.MeikyoShisui.RecentlyUsed() || Core.Me.HasMyAura(AurasDefine.MeikyoShisui))
            {
                if (SenCounts() < 1)
                {
                    return SpellsDefine.Gekko.GetSpellEntity();
                }

                return SpellsDefine.Kasha.GetSpellEntity();
            }

            if (ActionManager.LastSpellId == SpellsDefine.Hakaze)
            {
                return SpellsDefine.Yukikaze.GetSpellEntity();
            }

            return SpellsDefine.Hakaze.GetSpellEntity();
        }

        public static bool TargetNeedsDot(Character tar)
        {
            if (!AEAssist.DataBinding.Instance.UseDot)
                return false;
            if (TTKHelper.IsTargetTTK(tar))
                return false;

            if (DotBlacklistHelper.IsBlackList(Core.Me.CurrentTarget as Character))
                return false;
            if (!tar.HasMyAuraWithTimeleft(AurasDefine.Higanbana, 10000))
            {
                return true;
            }

            return false;
        }
        public static async Task<SpellEntity> FillerRotations()
        {
            var baseGcdTime = RotationManager.Instance.GetBaseGCDSpell().AdjustedCooldown.TotalMilliseconds;

            if (Math.Abs(baseGcdTime - 2140) == 0) // 2.14second gcd 2 filler gcd needed
            {
                if (SpellsDefine.Hakaze.IsUnlock())
                {
                    if (SpellsDefine.Hakaze.IsReady())
                    {
                        await SpellsDefine.Hakaze.DoGCD();
                        return SpellsDefine.Hakaze.GetSpellEntity();
                    }
                    
                }
                
                if (SpellsDefine.Yukikaze.IsUnlock())
                {
                    if (SpellsDefine.Yukikaze.IsReady())
                    {
                        await SpellsDefine.Yukikaze.DoGCD();
                        return SpellsDefine.Yukikaze.GetSpellEntity();
                    }
                    
                }
                
                
                if (SpellsDefine.Hagakure.IsUnlock())
                {
                    if (SpellsDefine.Hagakure.IsReady())
                    {
                        await SpellsDefine.Hagakure.DoAbility();
                        return SpellsDefine.Hagakure.GetSpellEntity();
                    }
                    
                }
                
            } else if (Math.Abs(baseGcdTime - 2070) == 0) // 2.07sec gcd 3 filler gcd needed
            {
                
                if (SpellsDefine.Hakaze.IsUnlock())
                {
                    if (SpellsDefine.Hakaze.IsReady())
                    {
                        await SpellsDefine.Hakaze.DoGCD();
                        return SpellsDefine.Hakaze.GetSpellEntity();
                    }
                    
                }
                
                if (SpellsDefine.Jinpu.IsUnlock())
                {
                    if (SpellsDefine.Jinpu.IsReady())
                    {
                        await SpellsDefine.Jinpu.DoGCD();
                        return SpellsDefine.Jinpu.GetSpellEntity();
                    }
                    
                }
                
                if (SpellsDefine.Gekko.IsUnlock())
                {
                    if (SpellsDefine.Gekko.IsReady())
                    {
                        await SpellsDefine.Gekko.DoGCD();
                        return SpellsDefine.Gekko.GetSpellEntity();
                    }
                    
                }
                
                if (SpellsDefine.Hagakure.IsUnlock())
                {
                    if (SpellsDefine.Hagakure.IsReady())
                    {
                        await SpellsDefine.Hagakure.DoAbility();
                        return SpellsDefine.Hagakure.GetSpellEntity();
                    }
                    
                }
                
            }else if (Math.Abs(baseGcdTime - 2000) == 0) // 2.00 seconds gcd 4 filler gcd needed (get better gear lol)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (SpellsDefine.Hakaze.IsUnlock())
                    {
                        if (SpellsDefine.Hakaze.IsReady())
                        {
                            await SpellsDefine.Hakaze.DoGCD();
                            return SpellsDefine.Hakaze.GetSpellEntity();
                        }
                    
                    }
                    
                    if (SpellsDefine.Yukikaze.IsUnlock())
                    {
                        if (SpellsDefine.Yukikaze.IsReady())
                        {
                            await SpellsDefine.Yukikaze.DoGCD();
                            return SpellsDefine.Yukikaze.GetSpellEntity();
                        }
                    
                    }
                    
                    if (SpellsDefine.Hagakure.IsUnlock())
                    {
                        if (SpellsDefine.Hagakure.IsReady())
                        {
                            await SpellsDefine.Hagakure.DoGCD();
                            return SpellsDefine.Hagakure.GetSpellEntity();
                        }
                    
                    }
                }
            }
            return null;
        }


        public static int CheckOddOrEvenBattleTime()
        {
            var currentBattleTime = AIRoot.GetBattleData<BattleData>().CurrBattleTimeInMs;
            var battleTimeInMinutes = currentBattleTime / 60000;
            var reminderInMinutes = battleTimeInMinutes % 2;
            
            // ODD
            if (reminderInMinutes == 1)
            {
                return 1;
            }
            
            // EVEN 
            if (reminderInMinutes == 0)
            {
                return 0;
            }

            return -1;
        }
        
        
        
        public static async Task<SpellEntity> AoEGCD()
        {

            if (TargetHelper.CheckNeedUseAOE(8, 5))
            {
                if (SpellsDefine.Fuga.IsUnlock())
                {
                    if (SpellsDefine.Fuga.IsReady())
                    {
                        await SpellsDefine.Fuga.DoGCD();
                        return SpellsDefine.Fuga.GetSpellEntity();
                    }
                }
            }
            
            if (TargetHelper.CheckNeedUseAOE(0, 5))
            {
                if (SpellsDefine.Oka.IsUnlock())
                {
                    if (SpellsDefine.Oka.IsReady())
                    {
                        await SpellsDefine.Oka.DoGCD();
                        return SpellsDefine.Oka.GetSpellEntity();
                    }
                }
            }
            
            if (TargetHelper.CheckNeedUseAOE(8, 5))
            {
                if (SpellsDefine.Fuga.IsUnlock())
                {
                    if (SpellsDefine.Fuga.IsReady())
                    {
                        await SpellsDefine.Fuga.DoGCD();
                        return SpellsDefine.Fuga.GetSpellEntity();
                    }
                }
            }
            
            if (TargetHelper.CheckNeedUseAOE(0, 5))
            {
                if (SpellsDefine.Mangetsu.IsUnlock())
                {
                    if (SpellsDefine.Mangetsu.IsReady())
                    {
                        await SpellsDefine.Mangetsu.DoGCD();
                        return SpellsDefine.Mangetsu.GetSpellEntity();
                    }
                }
            }

            await GetHissatsuShinten().DoAbility();
            
            if (TargetHelper.CheckNeedUseAOE(0, 5))
            {
                if (SpellsDefine.TenkaGoken.IsUnlock())
                {
                    if (SpellsDefine.TenkaGoken.IsReady())
                    {
                        await SpellsDefine.TenkaGoken.DoGCD();
                        return SpellsDefine.TenkaGoken.GetSpellEntity();
                    }
                }
            }
            
            return null;
        }
        
        public static SpellEntity GetHissatsuShinten()
        {
            
            if (!SpellsDefine.HissatsuShinten.IsUnlock())
            {
                return null;
            }
            if (!SpellsDefine.HissatsuShinten.IsReady())
            {
                return null;
            }

            if (!ActionManager.CanCastOrQueue(SpellsDefine.HissatsuShinten.GetSpellEntity().SpellData,
                    Core.Me.CurrentTarget)) return null;
            return ActionResourceManager.Samurai.Kenki >= 25 ? SpellsDefine.HissatsuShinten.GetSpellEntity() : null;
        }

        public static SpellEntity IaijutsuCanSpell()
        {
            if (!Core.Me.HasAura(AurasDefine.Kaiten))
                return null;
            if (!Core.Me.HasAura(AurasDefine.Kaiten))
                return null;
            return null;
        }

        public static uint SenCounts()
        {
            uint counts = 0;
            if (ActionResourceManager.Samurai.Sen.HasFlag(ActionResourceManager.Samurai.Iaijutsu.Getsu))
                counts++;

            if (ActionResourceManager.Samurai.Sen.HasFlag(ActionResourceManager.Samurai.Iaijutsu.Setsu))
                counts++;

            if (ActionResourceManager.Samurai.Sen.HasFlag(ActionResourceManager.Samurai.Iaijutsu.Ka))
                counts++;
            return counts;
        }

        public static bool IaijutsuCanSpellTime()
        {
            var target = Core.Me as GameObject;
            if (Core.Me.HasAura(AurasDefine.MeikyoShisui))
                return false;
            return true;
        }

        public static SpellEntity GetIaijutsuSpell()
        {
            var spell = SpellsDefine.MidareSetsugekka;
            var Sen = SenCounts();
            var ta = Core.Me.CurrentTarget as Character;
            // if (spell.Cooldown.TotalSeconds != 0 && Core.Me.HasAura(AurasDefine.OgiReady) && ta.HasMyAura(AurasDefine.Higanbana))
            //     return SpellsDefine.OgiNamikiri;
            if (Sen == 0) return null;
            if (Sen == 1) spell = SpellsDefine.Higanbana;
            if (Sen == 2)
            {
                if (TargetHelper.CheckNeedUseAOE(Core.Me.CurrentTarget, 5, 5))
                    return SpellsDefine.TenkaGoken.GetSpellEntity();
                return null;
            }

            return spell.GetSpellEntity();
        }

        public static SpellEntity KaeshiCanSpell()
        {
            if (AIRoot.GetBattleData<SamuraiBattleData>().KaeshiSpell == KaeshiSpell.MidareSetsugekka)
                return SpellsDefine.KaeshiSetsugekka.GetSpellEntity();
            if (AIRoot.GetBattleData<SamuraiBattleData>().KaeshiSpell == KaeshiSpell.OgiNamikiri)
                return SpellsDefine.KaeshiNamikiri.GetSpellEntity();
            return null;
        }

        public static bool NeedUseKaiten()
        {
            if (false) ;
            return false;
        }
    }
}