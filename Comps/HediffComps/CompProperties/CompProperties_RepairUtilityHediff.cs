using Verse;

namespace RepairUtilities.Comps
{
    public class CompProperties_RepairUtilityHediff : HediffCompProperties
    {
        public CompProperties_RepairUtilityHediff()
        {
            compClass = typeof(Comp_RepairUtilityHediff);
        }

        public int ticksBetweenPulse;
        public int healthPerPulse;
    }
}
