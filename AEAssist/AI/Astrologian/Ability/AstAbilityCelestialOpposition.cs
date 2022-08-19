using AEAssist.Define;
using AEAssist.Helper;
using System.Linq;
using System.Threading.Tasks;

namespace AEAssist.AI.Astrologian.Ability
{
    internal class AstAbilityCelestialOpposition : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (!SettingMgr.GetSetting<AstSettings>().Heal)
            {
                return -5;
            }
            if (!SpellsDefine.CelestialOpposition.IsReady()) return -1;
            var skillTarget = GroupHelper.CastableAlliesWithin30.Count(r => r.CurrentHealth > 0 && r.CurrentHealthPercent <= 80f);
            if (skillTarget < 4)
            {
                return -2;
            }            
            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = SpellsDefine.CelestialOpposition.GetSpellEntity();
            if (spell == null) return null;
            var ret = await spell.DoAbility();
            return ret ? spell : null;
        }
    }
}
