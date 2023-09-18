using Verse;

namespace RepairUtilities.Comps
{
    public class Comp_RepairUtilityHediff : HediffComp
    {
        public CompProperties_RepairUtilityHediff Props => (CompProperties_RepairUtilityHediff)props;

        private int ticksCounted = 0;

        public override void CompPostTick(ref float severityAdjustment)
        {
            base.CompPostTick(ref severityAdjustment);

            if (parent.pawn is { } pawn)
            {
                ticksCounted++;

                if (ticksCounted == Props.ticksBetweenPulse)
                {
                    foreach (Thing thing in pawn.apparel.WornApparel)
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

        public override void CompExposeData()
        {
            base.CompExposeData();
            Scribe_Values.Look(ref ticksCounted, "ticksCounted", 0);
        }

    }
}
