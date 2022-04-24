﻿using System.Threading.Tasks;
using AEAssist.Define;
using AEAssist.Helper;
using ff14bot;
using ff14bot.Managers;
using ff14bot.Objects;

namespace AEAssist.AI.Reaper
{
    public class ReaperGCD_EnshroudGCD : IAIHandler
    {
        public int Check(SpellEntity lastSpell)
        {
            if (!SpellsDefine.CrossReaping.IsUnlock())
                return -1;

            if (!Core.Me.HasAura(AurasDefine.Enshrouded))
                return -2;

            // 双附体时,神秘环如果即将冷却好,或者已经可以用了,先不打这些GCD
            if (DataBinding.Instance.DoubleEnshroudPrefer &&
                SpellsDefine.ArcaneCircle.Cooldown.TotalMilliseconds < ConstValue.ReaperDoubleEnshroudMinCheckTime)
                return -3;

            if (ActionResourceManager.Reaper.LemureShroud == 0)
                return -4;

            // 本来需要打90大招,但是因为在移动,所以不打了.
            if (ActionResourceManager.Reaper.LemureShroud < 2
                && SpellsDefine.Communio.IsUnlock()
                && MovementManager.IsMoving)
                return -5;

            return 0;
        }

        public async Task<SpellEntity> Run()
        {
            var spell = ReaperSpellHelper.GetEnshroudGCDSpell(Core.Me.CurrentTarget);
            if (spell == null)
                return null;
            if (spell == SpellsDefine.Communio) MovementManager.MoveStop();

            if (await spell.DoGCD())
            {
                AIRoot.GetBattleData<BattleData>().LimitAbility = true;
                return spell;
            }

            return null;
        }
    }
}