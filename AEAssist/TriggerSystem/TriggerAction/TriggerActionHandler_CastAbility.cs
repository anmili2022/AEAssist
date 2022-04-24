﻿using AEAssist.AI;
using AEAssist.Define;
using AETriggers.TriggerModel;

namespace AEAssist.TriggerSystem.TriggerAction
{
    public class TriggerActionHandler_CastAbility : ATriggerActionHandler<TriggerAction_CastAbility>
    {
        protected override void Handle(TriggerAction_CastAbility t)
        {
            AIRoot.GetBattleData<BattleData>().NextAbilitySpellId = new SpellEntity(t.SpellId);
        }
    }
}