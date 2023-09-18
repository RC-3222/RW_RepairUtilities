using RimWorld;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Verse;

namespace RepairUtilities.Comps
{
    public class Comp_RepairUtilityBuildingStorage : ThingComp
    {
        public CompProperties_RepairUtilityBuildingStorage Props => (CompProperties_RepairUtilityBuildingStorage)props;

        private bool shouldAutoForbid = true;

        private Texture2D cachedAutoForbidIcon;
        private Texture2D AutoForbidIcon
        {
            get
            {
                if (cachedAutoForbidIcon == null)
                {
                    cachedAutoForbidIcon = ContentFinder<Texture2D>.Get("Icons/Forbidden");
                }
                return cachedAutoForbidIcon;
            }
        }

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
                            if (shouldAutoForbid)
                            {
                                if (thing.HitPoints == thing.MaxHitPoints) thing.SetForbidden(false);
                                else thing.SetForbidden(true);
                            }
                        } else if (shouldAutoForbid) thing.SetForbidden(false); 
                    }
                    ticksCounted = 0;
                }
            }
        }

        public override IEnumerable<Gizmo> CompGetGizmosExtra()
        {
            foreach (var gizmo in base.CompGetGizmosExtra())
            {
                yield return gizmo;
            }

            if (parent.Faction == Faction.OfPlayer)
            {
                Command_Toggle AutoForbidToggle = new Command_Toggle
                {
                    icon = AutoForbidIcon,
                    defaultLabel = "RepairUtilities_EnableAutoForbid".Translate(),
                    defaultDesc = "RepairUtilities_EnableAutoForbidDesc".Translate(),
                    isActive = () => shouldAutoForbid,
                    toggleAction = () => shouldAutoForbid = !shouldAutoForbid
                };
                yield return AutoForbidToggle;
            }
        }

        public override void PostExposeData()
        {
            base.PostExposeData();
            Scribe_Values.Look(ref ticksCounted, "ticksCounted", 0);
            Scribe_Values.Look(ref shouldAutoForbid, "shouldAutoForbid", true);
        }
    }
}
