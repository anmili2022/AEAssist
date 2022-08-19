using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using System.Threading.Tasks;

namespace AEAssist.AI.Astrologian.Ability
{
    internal class AstAbilityAstrodyne : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {

            if (!SpellsDefine.Astrodyne.IsReady()) return -1;
            //if (!Core.Me.HasAura(AurasDefine.Divination))
            //{
            //return -4;
            //}
            if (ActionResourceManager.CostTypesStruct.timer3 < 10)
            {
                return -1;
            }
            if (AIRoot.Instance.CloseBurst)
                return -2;
            
            return 0;

        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.Astrodyne.GetSpellEntity();
            if (spell == null) return null;
            //AIRoot.GetBattleData<AstBattleData>().AstNum = 0;
            //AIRoot.GetBattleData<AstBattleData>().half = true;
            //SettingMgr.GetSetting<AstSettings>().AstHalfCard = true;
            var ret = await spell.DoAbility();
            return ret ? spell : null;
        }
    }
}
