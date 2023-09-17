using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace RepairUtilities.Comps
{
    public class CompProperties_RepairUtilityHediff : HediffCompProperties
    {
        public CompProperties_RepairUtilityHediff()
        {
            compClass = typeof(Comp_RepairUtilityHediff);
        }

        public int ticksBetweenPulse;
        public int healthPerPulse;
    }
}
