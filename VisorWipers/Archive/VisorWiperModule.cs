using System.Runtime.CompilerServices;
using TheArchive;
using TheArchive.Core;
using TheArchive.Core.Localization;
using TheArchive.Interfaces;

namespace VisorWipers.Archive
{
    internal sealed class VisorWiperModule : IArchiveModule
    {
        public ILocalizationService LocalizationService { get; set; } = null!;
        public IArchiveLogger Logger { get; set; } = null!;

        public void Init()
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Load()
        {
            ArchiveMod.RegisterArchiveModule(typeof(VisorWiperModule));
        }
    }
}