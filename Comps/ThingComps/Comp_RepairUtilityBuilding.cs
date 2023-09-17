using RimWorld;
using System.Collections.Generic;
using Verse;

namespace RepairUtilities.Comps
{
    public class Comp_RepairUtilityBuilding : ThingComp
    {
        public CompProperties_RepairUtilityBuilding Props => (CompProperties_RepairUtilityBuilding)props;

        private int ticksCounted = 0;

        public bool CanWork => (parent.GetComp<CompPowerTrader>() is not { } powerComp || powerComp.PowerOn);

        public override void CompTick()
        {
            base.CompTick();
            if (parent is Building && CanWork)
            {
                ticksCounted++;
                if (parent.Map != null && ticksCounted >= Props.ticksBetweenPulse)
                {
                    foreach (Thing thing in GenRadial.RadialDistinctThingsAround(parent.Position, parent.Map, Props.pulseRadius, true))
                    {
                        if (thing is Building && thing.Faction == parent.Faction && thing.HitPoints != thing.MaxHitPoints)
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
