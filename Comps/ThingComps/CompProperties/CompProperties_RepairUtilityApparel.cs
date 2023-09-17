using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace RepairUtilities.Comps
{
    public class CompProperties_RepairUtilityApparel : CompProperties
    {
        public CompProperties_RepairUtilityApparel()
        {
            compClass = typeof(Comp_RepairUtilityHediff);
        }

        public int ticksBetweenPulse;
        public int healthPerPulse;
    }
}
