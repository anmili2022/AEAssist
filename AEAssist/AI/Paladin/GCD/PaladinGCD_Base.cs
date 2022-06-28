using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
namespace AEAssist.AI.Paladin.GCD
{
    public class PaladinGCD_Base : IAIHandler
    {
        uint spell;
        static public uint GetSpell()
        {
            if (Paladin_SpellHelper.CheckUseAOE() && SpellsDefine.TotalEclipse.IsUnlock())
                return GetAOE();
            return GetSingleTarget();
        }
        public int Check(SpellEntity lastSpell)
        {
            spell = GetSpell();

            //一个dot设置 
            if (!DataBinding.Instance.UseDot)
                return -3;
            //检查dot剩余时间

            if (!spell.IsReady())
                return -1;
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            if (await spell.DoGCD()) return spell.GetSpellEntity();

            return null;
        }



        public static uint GetSingleTarget()
        {
            if (Core.Me.HasAura(AurasDefine.SwordOath))
                return SpellsDefine.Atonement;

            if (Paladin_SpellHelper.LastSpellCombo(SpellsDefine.FastBlade) && SpellsDefine.RiotBlade.IsUnlock())
                return SpellsDefine.RiotBlade;

            if (Paladin_SpellHelper.LastSpellCombo(SpellsDefine.RiotBlade) && SpellsDefine.RageofHalone.IsUnlock())
                return GetRoyalAuthority();

            return SpellsDefine.FastBlade;
        }

        public static uint GetRoyalAuthority()
        {
            if (SpellsDefine.RoyalAuthority.IsUnlock())
                return SpellsDefine.RoyalAuthority;
            return SpellsDefine.RageofHalone;
        }
        public static uint GetAOE()
        {

            if (Paladin_SpellHelper.LastSpellCombo(SpellsDefine.TotalEclipse) && SpellsDefine.Prominance.IsUnlock())
                return SpellsDefine.Prominance;

            return SpellsDefine.TotalEclipse;

        }

    }
}