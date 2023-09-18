using Verse;

namespace RepairUtilities
{
    public static class Utils
    {
        public static void RestoreThingHitPoints(Thing thing, int valueToRestore)
        {
            var delta = thing.MaxHitPoints - thing.HitPoints;
            thing.HitPoints += (valueToRestore > delta ? delta : valueToRestore);
        }
    }
}
