using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.Scholar.GCD
{
    public class ScholarGCD_Base : IAIHandler
    {
        uint spell;
        static public uint GetSpell()
        {
            var aoeChecker = TargetHelper.CheckNeedUseAOE(5, 5, ConstValue.ScholarAOECount);
            if (aoeChecker)//判断是否需要AOE
                return GetAOE();
            else
                return GetSingleTarget();
        }

        public int Check(SpellEntity lastSpell)
        {
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



        public static uint GetSingleTarget()
        {
            if (MovementManager.IsMoving)
                return SpellsDefine.SchRuin2;//毁坏
            else
            //GCD-毁灭-毁坏-气炎法-魔炎法-死炎法-极炎法
            if (SpellsDefine.SchBroil4.IsUnlock())//极炎法
                if (SpellsDefine.SchBroil3.IsUnlock())//死炎法
                    if (SpellsDefine.SchBroil2.IsUnlock())//魔炎法
                        if (SpellsDefine.SchBroil.IsUnlock())//气炎法
                            return SpellsDefine.SchBroil4;//毁灭
                        else
                            return SpellsDefine.SchBroil;
                    else
                        return SpellsDefine.SchBroil2;
                else
                    return SpellsDefine.SchBroil3;
            else
                return SpellsDefine.SchBroil4;
        }

        public static uint GetAOE()
        {
            if (!SpellsDefine.ArtOfWarII.IsUnlock())//
                if (!SpellsDefine.ArtOfWar.IsUnlock())
                    if (!MovementManager.IsMoving)
                        return SpellsDefine.SchBroil4;//毁灭
                    else
                        return SpellsDefine.SchRuin2;//毁坏
                else
                    return SpellsDefine.ArtOfWar;
            else
                return SpellsDefine.ArtOfWarII;



            
        }

    }
}