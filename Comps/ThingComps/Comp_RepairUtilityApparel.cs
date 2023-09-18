using RimWorld;
using Verse;

namespace RepairUtilities.Comps
{
    public class Comp_RepairUtilityApparel : ThingComp
    {
        public CompProperties_RepairUtilityApparel Props => (CompProperties_RepairUtilityApparel)props;

        private int ticksCounted = 0;

        public override void CompTick()
        {
            base.CompTick();
            if (parent is Apparel apparel && apparel.Wearer != null)
            {
                ticksCounted++;
                if (ticksCounted == Props.ticksBetweenPulse)
                {
                    foreach (Thing thing in apparel.Wearer.apparel.WornApparel)
                    {
                        if (thing.HitPoints != thing.MaxHitPoints)
                        {
                            Utils.RestoreThingHitPoints(thing, Props.healthPerPulse);
                        }
                    }
                    ticksCounted = 0;
                }
            }
        }

        public override void PostExposeData()
        {
            base.PostExposeData();
            Scribe_Values.Look(ref ticksCounted, "ticksCounted");
        }
    }
}
