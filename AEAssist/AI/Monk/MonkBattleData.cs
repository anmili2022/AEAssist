namespace AEAssist.AI.Monk
{
    
    public enum MonkNadiCombo
    {
        Lunar,
        Solar,
        None
    }
    
    public enum MonkBurst
    {
        Odd,
        Even,
        None
    }
    
    public class MonkBattleData : IBattleData
    {
        public MonkBurst CurrentBurst = MonkBurst.None;
        public MonkNadiCombo CurrentNadiCombo = MonkNadiCombo.None;
        public MonkNadiCombo NextNadiCombo = MonkNadiCombo.None;
        public bool RoFBH2 = false;
        public bool DoingOpener = false;

    }
}