using UnityEngine;
using static GlassLiquidSystem;
using Il2Arrays = Il2CppInterop.Runtime.InteropTypes.Arrays;

namespace VisorWipers
{
    public static class WipeTheVoid
    {
        private static readonly Il2CppSystem.Array DefaultParticle;
        private const int ParticleCount = 1024; // Based on R6Mono

        static WipeTheVoid()
        {
            Il2Arrays.Il2CppStructArray<particleData> il2Array = new particleData[ParticleCount];
            DefaultParticle = il2Array.Cast<Il2CppSystem.Array>();
        }

        public static void Wipe()
        {
            if (!ScreenLiquidManager.hasSystem) return;

            var system = ScreenLiquidManager.LiquidSystem;
            system.cbParticles.SetData(DefaultParticle);
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
