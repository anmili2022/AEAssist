using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
namespace AEAssist.AI.Paladin.GCD
{
    public class PaladinGCD_Dot : IAIHandler
    {
        uint spell;
        static public uint GetSpell()
        {
            switch (Paladin_SpellHelper.LastGCDSpellID())
            {
                case SpellsDefine.FastBlade:
                    return SpellsDefine.RiotBlade;
                case SpellsDefine.RiotBlade:
                    return SpellsDefine.GoringBlade;

            }
            return SpellsDefine.FastBlade;
        }
        public int Check(SpellEntity lastSpell)
        {
            if (!SpellsDefine.GoringBlade.IsUnlock())
                return -2;

            spell = GetSpell();

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