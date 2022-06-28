using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
namespace AEAssist.AI.Paladin.GCD
{
    public class PaladinGCD_HolySpirit : IAIHandler
    {
        uint spell;
        static public uint GetSpell()
        {
            if (LastStackorGCD() && SpellsDefine.Confiteor.IsUnlock())
                return SpellsDefine.Confiteor;
            if (Paladin_SpellHelper.CheckUseAOE(2) && SpellsDefine.HolyCircle.IsUnlock())
                return SpellsDefine.HolyCircle;
            return SpellsDefine.HolySpirit;
        }
        public int Check(SpellEntity lastSpell)
        {
            if (!Core.Me.HasAura(AurasDefine.Requiescat))
                return -5;

            spell = GetSpell();

            //超出距离只能打远程

            //一个gcd都不够了的情况下必须把安魂祈祷打掉

            //如果差一下就可以打出沥血剑 打沥血剑
            
            //剩下的时间保证把层数全部打完
            if (Core.Me.GetAuraById(AurasDefine.Requiescat).TimespanLeft.TotalMilliseconds < Core.Me.GetAuraById(AurasDefine.Requiescat).Value * AIRoot.Instance.GetGCDDuration())
                return 1;

            //如果有战逃反应 先打物理
            
            if (Core.Me.HasAura(AurasDefine.FightOrFight))
                return -4;




            if (!spell.IsReady())
                return -1;
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            if (await spell.DoGCD()) return spell.GetSpellEntity();

            return null;
        }

        static bool LastStackorGCD()
        {

            if (Core.Me.GetAuraById(AurasDefine.Requiescat).Value == 1)
                return true;
            if (Core.Me.GetAuraById(AurasDefine.Requiescat).TimespanLeft.TotalMilliseconds-100 < AIRoot.Instance.GetGCDDuration())
                return true;
            return false;
        }

    }
}