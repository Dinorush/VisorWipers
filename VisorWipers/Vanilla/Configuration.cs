using BepInEx.Configuration;
using BepInEx;
using System.IO;
using GTFO.API.Utilities;
using UnityEngine;

namespace VisorWipers.Vanilla
{
    internal static class Configuration
    {
        private static ConfigEntry<KeyCode> _wiperKeyBind = null!;
        public static KeyCode WiperKeyBind => _wiperKeyBind.Value;

        private static ConfigFile _configFile = null!;

        internal static void Init()
        {
            _configFile = new ConfigFile(Path.Combine(Paths.ConfigPath, EntryPoint.MODNAME + ".cfg"), saveOnInit: true);

            string section = "Keybinds";
            _wiperKeyBind = _configFile.Bind(section, "Wiper Keybind", KeyCode.F2, "The keybind for your visor wipers.\nPressing it wipes the screen of liquids and grime.");

            LiveEditListener listener = LiveEdit.CreateListener(Paths.ConfigPath, EntryPoint.MODNAME + ".cfg", false);
            listener.FileChanged += OnFileChanged;
        }

        private static void OnFileChanged(LiveEditEventArgs _) => _configFile.Reload();
    }
}
