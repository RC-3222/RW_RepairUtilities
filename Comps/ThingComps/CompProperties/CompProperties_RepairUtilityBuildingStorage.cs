using Verse;

namespace RepairUtilities.Comps
{
    public class CompProperties_RepairUtilityBuildingStorage : CompProperties
    {
        public CompProperties_RepairUtilityBuildingStorage()
        {
            compClass = typeof(Comp_RepairUtilityBuildingStorage);
        }

        public int ticksBetweenPulse;
        public int healthPerPulse;
    }
}
