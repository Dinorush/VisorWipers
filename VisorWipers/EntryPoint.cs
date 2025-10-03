using BepInEx;
using BepInEx.Unity.IL2CPP;
using GTFO.API;
using Il2CppInterop.Runtime.Injection;
using System.Runtime.CompilerServices;
using UnityEngine;
using VisorWipers.Vanilla;

namespace VisorWipers
{
    [BepInPlugin("Dinorush." + MODNAME, MODNAME, "1.0.0")]
    [BepInDependency(ARCHIVE_GUID, BepInDependency.DependencyFlags.SoftDependency)]
    internal sealed class EntryPoint : BasePlugin
    {
        public const string MODNAME = "VisorWipers";
        public const string ARCHIVE_GUID = "dev.AuriRex.gtfo.TheArchive";

        public override void Load()
        {
            if (IL2CPPChainloader.Instance.Plugins.ContainsKey(ARCHIVE_GUID))
            {
                Log.LogMessage($"The Archive detected. Using archive version instead...");
                LoadArchive();
                return;
            }

            Configuration.Init();
            AssetAPI.OnStartupAssetsLoaded += OnStartupAssetsLoaded;
            Log.LogMessage("Loaded " + MODNAME);
        }

        private void OnStartupAssetsLoaded()
        {
            ClassInjector.RegisterTypeInIl2Cpp<WiperHandler>();
            var go = new GameObject(MODNAME);
            Object.DontDestroyOnLoad(go);
            go.AddComponent<WiperHandler>();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void LoadArchive()
        {
            Archive.VisorWiperModule.Load();
        }
    }
}