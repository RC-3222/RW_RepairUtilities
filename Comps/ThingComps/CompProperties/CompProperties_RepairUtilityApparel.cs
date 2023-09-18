using Verse;

namespace RepairUtilities.Comps
{
    public class CompProperties_RepairUtilityApparel : CompProperties
    {
        public CompProperties_RepairUtilityApparel()
        {
            compClass = typeof(Comp_RepairUtilityApparel);
        }

        public int ticksBetweenPulse;
        public int healthPerPulse;
    }
}
