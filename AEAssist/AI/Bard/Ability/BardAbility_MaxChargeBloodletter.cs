using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using System.Threading.Tasks;

namespace AEAssist.AI.Bard.Ability
{
    public class BardAbility_MaxChargeBloodletter : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (lastSpell == SpellsDefine.Bloodletter.GetSpellEntity())
                return -1;
            if (!AEAssist.DataBinding.Instance.Bloodletter) return -3;
            if (!SpellsDefine.Bloodletter.IsReady())
                return -2;
            if (SpellsDefine.Bloodletter.IsMaxChargeReady(0.1f))
                return 0;
            return -3;
        }

        public async Task<SpellEntity> Run()
        {
            var SpellEntity = SpellsDefine.Bloodletter.GetSpellEntity();
            //LogHelper.Info($"{ConstValue.BardAOECount} {TargetHelper.CheckNeedUseAOE(25, 8, ConstValue.BardAOECount)}");
            if (TargetHelper.CheckNeedUseAOE(25, 8, ConstValue.BardAOECount))
            {
                if (!SpellsDefine.RainofDeath.IsReady())
                    return null;
                SpellEntity = SpellsDefine.RainofDeath.GetSpellEntity();
            }
            if (await SpellEntity.DoAbility()) return SpellEntity;

            return null;
        }
    }
}