using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.RedMage.GCD
{
    public class RedMageGCD_Base : IAIHandler
    {
        uint spell;

        static public bool RenMageMana()//白 < 黑
        {
            if (ActionResourceManager.RedMage.WhiteMana < ActionResourceManager.RedMage.BlackMana)
                return true;
            else
                return false;
        }
        static public uint GetSpell()
        {
            var aoeChecker = TargetHelper.CheckNeedUseAOE(5, 5, ConstValue.WhiteMageAOECount);

            var RedMage = ActionResourceManager.RedMage.WhiteMana > ActionResourceManager.RedMage.BlackMana;

            //if (RedMage && )
            //    return SpellsDefine.Verholy;
            //else
            //    return SpellsDefine.Verflare;

            if (aoeChecker)//判断是否需要AOE
                return GetSingleTarget();
            else
                return GetAOE();

            //if (ActionResourceManager.RedMage.WhiteMana<80 && ActionResourceManager.RedMage.BlackMana < 80)
            //    //近战，远程 判断
            //    return Savings();//积蓄
            //else
            //    return Release();//释放
        }

        public static uint GetSingleTarget()
        {

            if (ActionResourceManager.RedMage.WhiteMana > 80 && ActionResourceManager.RedMage.BlackMana > 80)
                return SpellsDefine.Riposte;

            switch (ActionManager.LastSpellId)
            { 
                case SpellsDefine.Riposte:
                    return SpellsDefine.Zwerchhau;
                case SpellsDefine.Zwerchhau:
                    return SpellsDefine.Redoublement;                

                case SpellsDefine.Jolt://摇荡
                    if (RenMageMana()) 
                        return SpellsDefine.Veraero;//赤疾风
                    else
                        return SpellsDefine.Verthunder;//赤闪雷
                
                case SpellsDefine.Veraero:
                    if (Core.Me.HasAura(AurasDefine.VerstoneReady))
                        return SpellsDefine.Verstone;//赤飞石
                    else 
                        return SpellsDefine.Jolt;

                case SpellsDefine.Verthunder:
                    if (Core.Me.HasAura(AurasDefine.VerfireReady))
                        return SpellsDefine.Verfire;//赤飞石
                    else
                        return SpellsDefine.Jolt;
                default:
                    return SpellsDefine.Jolt;
            }
            
        }
        
        public static uint GetAOE()
        {
            var RedMage = ActionResourceManager.RedMage.WhiteMana > ActionResourceManager.RedMage.BlackMana;

            switch (ActionManager.LastSpellId)
            {
                case SpellsDefine.Veraero2://赤烈风
                    return SpellsDefine.Scatter;//散碎

                case SpellsDefine.Verthunder2:
                    return SpellsDefine.Scatter;

                case SpellsDefine.Scatter:
                    if (RedMage)
                        return SpellsDefine.Verthunder2;//赤飞石
                    else
                        return SpellsDefine.Veraero2;
                default:
                    return SpellsDefine.Veraero2;
            }
        }
        public int Check(SpellEntity lastSpell)
        {
            spell = GetSpell();
            LogHelper.Debug("look this：" + spell.ToString());
            if (!spell.IsReady())
                return -1;
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            if (await spell.DoGCD()) return spell.GetSpellEntity();

            return null;
        }
    }
}