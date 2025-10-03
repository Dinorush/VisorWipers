using UnityEngine;
using static GlassLiquidSystem;
using Il2Arrays = Il2CppInterop.Runtime.InteropTypes.Arrays;

namespace VisorWipersArchive
{
    public static class WipeTheVoid
    {
        private static readonly Il2Arrays.Il2CppStructArray<particleData> DefaultParticle;
        private const int ParticleCount = 1024; // Based on R6Mono

        static WipeTheVoid()
        {
            DefaultParticle = new particleData[ParticleCount];
        }

        public static void Wipe()
        {
            if (!ScreenLiquidManager.hasSystem || FocusStateManager.CurrentState != eFocusState.FPS) return;

            var system = ScreenLiquidManager.LiquidSystem;
            system.cbParticles.SetData(DefaultParticle.Cast<Il2CppSystem.Array>());
            system.particleWrap = 0;

            Graphics.SetRenderTarget(system.rtParams);
            GL.Clear(false, true, Color.clear);

            Graphics.SetRenderTarget(system.rtParams_db);
            GL.Clear(false, true, Color.clear);

            Graphics.SetRenderTarget(system.rtColor);
            GL.Clear(false, true, Color.clear);

            Graphics.SetRenderTarget(system.rtColor_db);
            GL.Clear(false, true, Color.clear);

            Graphics.SetRenderTarget(null);
        }
    }
}
