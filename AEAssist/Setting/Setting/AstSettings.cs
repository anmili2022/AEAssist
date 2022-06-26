using AEAssist.Define;
using AEAssist.Helper;
using AEAssist.Opener;
using ff14bot.Enums;
using PropertyChanged;

namespace AEAssist
{
    [AddINotifyPropertyChangedInterface]
    public class AstSettings:IBaseSetting
    {
        public AstSettings()
        {
            Reset();
        }
        public void Reset()
        {
            EarlyDecisionMode = true;
            Dot_TimeLeft = ConstValue.AuraTick;
            TTK_Aero = 30;
            AstOpener = "Default";
            
        }
        public void OnLoad()
        {
            OpenerMgr.Instance.SpecifyOpenerByName[ClassJobType.WhiteMage] = AstOpener;
            LogHelper.Info($"Ast Opener: {AstOpener}");
        }
        public int Dot_TimeLeft { get; set; } = ConstValue.AuraTick;
        public int TTK_Aero { get; set; }

        public int LucidDreamingTrigger { get; set; } = ConstValue.LucidDreamingDefaultRefresh;
        public bool LucidDreamingToggle { get; set; } = true;
        public bool SwiftResToggle { get; set; } = true;
        public bool Heal { get; set; } = true;
        public bool EarlyDecisionMode { get; set; }
        public string AstOpener { get; set; } = "Default";
        public int AstResPriority { get; set; } = 0;
        
    }
}
