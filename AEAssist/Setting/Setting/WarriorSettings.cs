using PropertyChanged;

namespace AEAssist
{
    [AddINotifyPropertyChangedInterface]
    public class WarriorSettings : IBaseSetting
    {
        public WarriorSettings()
        {
            Reset();
        }

        public bool EarlyDecisionMode { get; set; }

        public bool WarriorPrimalRend { get; set; }//蛮荒崩裂
        public bool WarriorOnslaught { get; set; }//猛攻
        public bool WarriorInnerRelease { get; set; }//原初的解放
        public bool WarriorDefenseMode { get; set; }//战士自动防御模式
        public void Reset()
        {
            WarriorPrimalRend = true;
            WarriorOnslaught = false;
            EarlyDecisionMode = false;
            WarriorDefenseMode = true;
            WarriorInnerRelease = true;
        }

        public bool WarriorRampart { get; set; } = true;//铁壁
        public bool WarriorBloodwhetting { get; set; } = true;//原初的血气
        public bool WarriorVengeance { get; set; } = true;//复仇

        public void ResetToggles()
        {
            WarriorRampart = true;
            WarriorVengeance = true;
            WarriorBloodwhetting = true;

            WarriorOnslaught = false;
        }

        public void OnLoad()
        {

        }
    }
}