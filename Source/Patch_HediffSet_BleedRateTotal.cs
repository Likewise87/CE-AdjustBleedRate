using HarmonyLib;
using RimWorld;
using Verse;

namespace CE_AdjustBleedRate.Patches
{
    [HarmonyPatch(typeof(HediffSet))]
    public static class Patch_HediffSet_BleedRateTotal
    {
        [HarmonyPatch("BleedRateTotal", MethodType.Getter)]
        [HarmonyPostfix]
        public static void Postfix(HediffSet __instance, ref float __result)
        {
            if (__result <= 0f) return;
            Pawn pawn = __instance?.pawn;
            if (pawn == null || !pawn.Downed) return;

            var factor = ModInit.Settings?.Factor ?? 0.5f;

            if (factor < 0.01f) factor = 0.01f;
            if (factor > 3.0f) factor = 3.0f;

            __result *= factor;
        }
    }
}
