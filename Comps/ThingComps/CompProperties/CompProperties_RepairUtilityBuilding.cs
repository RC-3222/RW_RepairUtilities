using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace RepairUtilities.Comps
{
    public class CompProperties_RepairUtilityBuilding : CompProperties
    {
        public CompProperties_RepairUtilityBuilding()
        {
            compClass = typeof(Comp_RepairUtilityHediff);
        }

        public float pulseRadius;
        public int ticksBetweenPulse;
        public int healthPerPulse;
    }
}
