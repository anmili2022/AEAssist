using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.Scholar.GCD
{
    public class ScholarGCD_Dot : IAIHandler
    {
        uint spell;
        uint schdot;
        static public uint GetAura()
        {

            if (SpellsDefine.Biolysis.IsUnlock())//已学习蛊毒法
                return AurasDefine.Biolysis;
            if (SpellsDefine.Bio2.IsUnlock())//已学习猛毒菌
                return AurasDefine.Bio2;
            return AurasDefine.Bio;


        }
        public int Check(SpellEntity lastSpell)
        {
            schdot = GetAura();
            spell = SpellsDefine.Bio;
            //if (!SpellsDefine.GoringBlade.IsUnlock())
            //    return -2;

            //if (!DataBinding.Instance.UseDot)
            //    return -3;

            //if (!Scholar_SpellHelper.NeedRenewDot(spell))
            //    return -4;

            var target = Core.Me.CurrentTarget as Character;
            if (target == null)
                return -2;
            //LogHelper.Info($"dot {target.HasAura(schdot)}");
            if (target.HasMyAura(schdot))
                if (!target.HasMyAuraWithTimeleft(schdot, 3000))//id，剩余时间
                {
                    //LogHelper.Info($"renewing dot.");
                }
                else
                { 
                    //LogHelper.Info($"Target's dot expires in {target.GetAuraById(schdot).TimeLeft} ms, no dot.");
                    return -2;
                }


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