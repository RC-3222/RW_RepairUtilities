using Verse;

namespace RepairUtilities.Comps
{
    public class CompProperties_RepairUtilityBuilding : CompProperties
    {
        public CompProperties_RepairUtilityBuilding()
        {
            compClass = typeof(Comp_RepairUtilityBuilding);
        }

        public float pulseRadius;
        public int ticksBetweenPulse;
        public int healthPerPulse;
    }
}
