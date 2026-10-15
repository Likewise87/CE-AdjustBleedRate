using Verse;

namespace CE_AdjustBleedRate
{
    public class BleedRateSettings : ModSettings
    {
        public int DownedBleedPercent = 50;
        public string percentBuffer = "50";

        public float Factor => DownedBleedPercent / 100f;

        public override void ExposeData()
        {
            Scribe_Values.Look(ref DownedBleedPercent, "DownedBleedPercent", 50);
            Scribe_Values.Look(ref percentBuffer, "percentBuffer", "50");

            if (DownedBleedPercent < 1) DownedBleedPercent = 1;
            if (DownedBleedPercent > 300) DownedBleedPercent = 300;
            if (string.IsNullOrEmpty(percentBuffer)) percentBuffer = DownedBleedPercent.ToString();
        }
    }
}
