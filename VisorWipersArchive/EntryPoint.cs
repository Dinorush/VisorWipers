using BepInEx;
using BepInEx.Unity.IL2CPP;
using TheArchive;
using TheArchive.Core;
using TheArchive.Core.Localization;
using TheArchive.Interfaces;

namespace VisorWipersArchive
{
    [BepInPlugin("Dinorush." + MODNAME, MODNAME, "1.0.0")]
    [BepInDependency("dev.AuriRex.gtfo.TheArchive", BepInDependency.DependencyFlags.HardDependency)]
    internal sealed class EntryPoint : BasePlugin, IArchiveModule
    {
        public const string MODNAME = "VisorWipersArchive";

        public ILocalizationService LocalizationService { get; set; } = null!;
        public IArchiveLogger Logger { get; set; } = null!;

        public void Init()
        {
        }

        public override void Load()
        {
            ArchiveMod.RegisterArchiveModule(typeof(EntryPoint));
            Log.LogMessage("Loaded " + MODNAME);
        }
    }
}