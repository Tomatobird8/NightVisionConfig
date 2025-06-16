using GameNetcodeStuff;
using HarmonyLib;

namespace NightVisionConfig.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    public class NightVisionPatch
    {
        [HarmonyPatch("SetNightVisionEnabled")]
        [HarmonyPostfix]
        private static void onNightVisionEnabled(ref PlayerControllerB __instance)
        {
            __instance.nightVision.range = NightVisionConfig.lightRange.Value;
            __instance.nightVision.intensity = NightVisionConfig.lightIntensity.Value;
        }
    }
}
