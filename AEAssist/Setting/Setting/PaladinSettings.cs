using PropertyChanged;

namespace AEAssist
{
    [AddINotifyPropertyChangedInterface]
    public class PaladinSettings : IBaseSetting
    {
        public PaladinSettings()
        {
            Reset();
        }

        public bool EarlyDecisionMode { get; set; }
      
        public void Reset()
        {
        }

        public void OnLoad()
        {
            
        }
    }
}