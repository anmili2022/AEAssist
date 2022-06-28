using AEAssist.Define;
using AEAssist.Helper;
using AEAssist.Opener;
using ff14bot.Enums;
using PropertyChanged;

namespace AEAssist
{
    [AddINotifyPropertyChangedInterface]
    public class AstSettings : IBaseSetting
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
            OpenerMgr.Instance.SpecifyOpenerByName[ClassJobType.Astrologian] = AstOpener;
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
        public int AstCardWeight { get; set; } = 17;
        public int MnkCardWeight { get; set; } = 2;
        public int BlmCardWeight { get; set; } = 8;
        public int DrgCardWeight { get; set; } = 4;
        public int SamCardWeight { get; set; } = 0;
        public int MchCardWeight { get; set; } = 10;
        public int SmnCardWeight { get; set; } = 7;
        public int BrdCardWeight { get; set; } = 12;
        public int NinCardWeight { get; set; } = 3;
        public int RdmCardWeight { get; set; } = 11;
        public int DncCardWeight { get; set; } = 9;
        public int PldCardWeight { get; set; } = 16;
        public int WarCardWeight { get; set; } = 15;
        public int DrkCardWeight { get; set; } = 1;
        public int GnbCardWeight { get; set; } = 6;
        public int WhmCardWeight { get; set; } = 13;
        public int SchCardWeight { get; set; } = 14;
        public int RprCardWeight { get; set; } = 5;
        public int SgeCardWeight { get; set; } = 12;
        public int BluCardWeight { get; set; } = 18;

    }
}
