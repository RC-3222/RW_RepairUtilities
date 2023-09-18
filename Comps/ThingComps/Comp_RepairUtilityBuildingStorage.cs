using RimWorld;
using System.Linq;
using Verse;

namespace RepairUtilities.Comps
{
    public class Comp_RepairUtilityBuildingStorage : ThingComp
    {
        public CompProperties_RepairUtilityBuildingStorage Props => (CompProperties_RepairUtilityBuildingStorage)props;

        private int ticksCounted = 0;

        public bool CanWork => (parent.GetComp<CompPowerTrader>() is not { PowerOn: false } powerComp);

        public override void CompTick()
        {
            base.CompTick();
            if (parent.Map != null && parent is Building_Storage storage && CanWork && storage.slotGroup.HeldThings.Any())
            {
                ticksCounted++;
                if (ticksCounted >= Props.ticksBetweenPulse)
                {
                    foreach (Thing thing in storage.slotGroup.HeldThings)
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
