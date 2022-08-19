using AEAssist.Define;
using AEAssist.Helper;
using ff14bot.Objects;
using System.Linq;
using System.Threading.Tasks;

namespace AEAssist.AI.GunBreaker.Ability
{
    public class GunBreakerAbility_Aurora : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (!SpellsDefine.Aurora.IsReady())
                return -1;
            var skillTarget = GroupHelper.CastableAlliesWithin30.FirstOrDefault(r => r.CurrentHealth > 0 && r.CurrentHealthPercent <= 80f && r.IsTank());
            if (skillTarget == null)
            {
                return -3;
            }
            return 0;
        }
        public async Task<SpellEntity> Run()
        {
            var skillTarget = GroupHelper.CastableAlliesWithin30.FirstOrDefault(r => r.CurrentHealth > 0 && r.CurrentHealthPercent <= 80f && r.IsTank());
            var spell = new SpellEntity(SpellsDefine.Aurora, skillTarget as BattleCharacter);
            //await spell.DoAbility();
            if (await spell.DoAbility()) return spell;
            return null;
        }
    }
}
