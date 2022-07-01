namespace AEAssist.AI.Samurai
{
    public enum KaeshiSpell
    {
        MidareSetsugekka,
        OgiNamikiri,
        NoUse
    }

    public class SamuraiBattleData : IBattleData
    {
        public bool Bursting = false;
        public bool EvenBursting = false;
        public KaeshiSpell KaeshiSpell = KaeshiSpell.NoUse;
        public int GCDCounts = 0;
        public int burstingShintenCount = 0;
        public long time = 0;
    }
}