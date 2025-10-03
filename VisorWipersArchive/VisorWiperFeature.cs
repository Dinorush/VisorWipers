using TheArchive.Core.Attributes.Feature;
using TheArchive.Core.Attributes.Feature.Members;
using TheArchive.Core.Attributes.Feature.Settings;
using TheArchive.Core.FeaturesAPI;
using UnityEngine;

namespace VisorWipersArchive
{
    [EnableFeatureByDefault]
    public class VisorWipersFeature : Feature
    {
        public override string Name => "Visor Wipers";

        public override string Description => "Wipes the liquid and grime off your screen.";

        public override FeatureGroup Group => FeatureGroups.Hud;

        [FeatureConfig]
        public static VisorWipersSettings Settings { get; set; } = null!;

        public class VisorWipersSettings
        {
            [FSDisplayName("Wiper Keybind")]
            [FSDescription("Key used to wipe the screen.")]
            public KeyCode Key { get; set; } = KeyCode.F2;
        }

        public override void Update()
        {
            if (FocusStateManager.CurrentState != eFocusState.FPS)
                return;

            if (!Input.GetKeyDown(Settings.Key))
                return;

            WipeTheVoid.Wipe();
        }
    }
}
