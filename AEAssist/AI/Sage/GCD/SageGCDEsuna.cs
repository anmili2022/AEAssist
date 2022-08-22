using AEAssist.Define;
using AEAssist.Helper;
using ff14bot.Enums;
using ff14bot.Managers;
using ff14bot.Objects;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AEAssist.AI.Sage.GCD
{
    public class SageGcdEsuna : IAIHandler
    {
        uint spell;
        static public uint GetSpell()
        {
            if (SpellsDefine.Esuna.IsUnlock())
                return SpellsDefine.Esuna;
            return 0;
        }
        private static int GetWeight(Character c)
        {
            switch (c.CurrentJob)
            {
                case ClassJobType.Astrologian:
                    return 9;

                case ClassJobType.Monk:
                case ClassJobType.Pugilist:
                    return 6;

                case ClassJobType.BlackMage:
                case ClassJobType.Thaumaturge:
                    return 2;

                case ClassJobType.Dragoon:
                case ClassJobType.Lancer:
                    return 5;

                case ClassJobType.Samurai:
                    return 4;

                case ClassJobType.Machinist:
                    return 3;

                case ClassJobType.Summoner:
                case ClassJobType.Arcanist:
                    return 1;

                case ClassJobType.Bard:
                case ClassJobType.Archer:
                    return 3;

                case ClassJobType.Ninja:
                case ClassJobType.Rogue:
                    return 5;

                case ClassJobType.RedMage:
                    return 1;

                case ClassJobType.Dancer:
                    return 2;

                case ClassJobType.Paladin:
                case ClassJobType.Gladiator:
                    return 9;

                case ClassJobType.Warrior:
                case ClassJobType.Marauder:
                    return 10;

                case ClassJobType.DarkKnight:
                    return 7;

                case ClassJobType.Gunbreaker:
                    return 8;

                case ClassJobType.WhiteMage:
                case ClassJobType.Conjurer:
                    return 5;

                case ClassJobType.Scholar:
                    return 9;

                case ClassJobType.Reaper:
                    return 4;

                case ClassJobType.Sage:
                    return 0;

                case ClassJobType.BlueMage:
                    return 9;
            }

            return c.CurrentJob == ClassJobType.Adventurer ? 70 : 0;
        }
        public int Check(SpellEntity lastSpell)
        {
            spell = GetSpell();
            if (spell == 0) return -1;            
            //LogHelper.Debug("NO10:" + spell.ToString());
            var skillTarget = GroupHelper.CastableAlliesWithin30.Where(a => a.HasAura(AurasDefine.Throttle) && a.CurrentHealth > 0).OrderBy(GetWeight);
            foreach (Character chara in skillTarget)
                LogHelper.Debug(Convert.ToString(chara));
            LogHelper.Debug(Convert.ToString(skillTarget.Count()));
            //var skillTarget = GroupHelper.CastableAlliesWithin30.FirstOrDefault(r => r.CurrentHealth > 0 && r.CurrentHealthPercent <= 80f && r.IsTank());
            if (skillTarget.FirstOrDefault() == null)
            {
                return -3;
            }
            return 0;

        }

        public async Task<SpellEntity> Run()
        {
            var skillTarget = GroupHelper.CastableAlliesWithin30.Where(a => a.HasAura(AurasDefine.Throttle) && a.CurrentHealth > 0).OrderBy(GetWeight);
            //var spell = new SpellEntity(SpellsDefine.Esuna, skillTarget.FirstOrDefault() as BattleCharacter);
            //await spell.DoAbility();
            foreach (Character chara in skillTarget)
            {
                if (chara.HasAura(AurasDefine.Throttle))
                {
                    var spell = new SpellEntity(SpellsDefine.Esuna, chara as BattleCharacter);
                    if (await spell.DoGCD()) return spell;
                }                
            }                
            //if (await spell.DoGCD()) return spell;
            return null;
        }
    }
}