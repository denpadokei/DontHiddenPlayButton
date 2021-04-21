using HarmonyLib;
using IPA;
using System.Reflection;
using IPALogger = IPA.Logging.Logger;

namespace DontHiddenPlayButton
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        internal static Plugin Instance { get; private set; }
        internal static IPALogger Log { get; private set; }
        public const string HARMONY_ID = "DontHiddenPlayButton.denpadokei.com.github";
        private Harmony harmony;
        [Init]
        /// <summary>
        /// Called when the plugin is first loaded by IPA (either when the game starts or when the plugin is enabled if it starts disabled).
        /// [Init] methods that use a Constructor or called before regular methods like InitWithConfig.
        /// Only use [Init] with one Constructor.
        /// </summary>
        public void Init(IPALogger logger)
        {
            Instance = this;
            Log = logger;
            Log.Info("DontHiddenPlayButton initialized.");
            this.harmony = new Harmony(HARMONY_ID);
        }
        [OnStart]
        public void OnApplicationStart() => Log.Debug("OnApplicationStart");

        [OnExit]
        public void OnApplicationQuit() => Log.Debug("OnApplicationQuit");

        [OnEnable]
        public void OnEnable() => this.harmony.PatchAll(Assembly.GetExecutingAssembly());
        [OnDisable]
        public void OnDisable() => this.harmony.UnpatchAll(HARMONY_ID);
    }
}
