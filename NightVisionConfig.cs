using BepInEx;
using BepInEx.Logging;
using BepInEx.Configuration;
using HarmonyLib;

namespace NightVisionConfig
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    public class NightVisionConfig : BaseUnityPlugin
    {
        public static NightVisionConfig Instance { get; private set; } = null!;
        internal new static ManualLogSource Logger { get; private set; } = null!;
        internal static Harmony? Harmony { get; set; }
        public static ConfigEntry<float> lightIntensity;
        public static ConfigEntry<float> lightRange;

        private void Awake()
        {
            lightIntensity = Config.Bind("General", "Night Vision Light Intensity", 366.9317f, "Intensity of the night vision light.");
            lightRange = Config.Bind("General", "Night Vision Light Range", 12f, "Range of the night vision light.");

            Logger = base.Logger;
            Instance = this;

            Patch();

            Logger.LogInfo($"{MyPluginInfo.PLUGIN_GUID} v{MyPluginInfo.PLUGIN_VERSION} has loaded!");
        }

        internal static void Patch()
        {
            Harmony ??= new Harmony(MyPluginInfo.PLUGIN_GUID);

            Logger.LogDebug("Patching Night Vision...");

            Harmony.PatchAll();

            Logger.LogDebug("Finished patching night vision!");
        }

        internal static void Unpatch()
        {
            Logger.LogDebug("Unpatching...");

            Harmony?.UnpatchSelf();

            Logger.LogDebug("Finished unpatching!");
        }
    }
}
