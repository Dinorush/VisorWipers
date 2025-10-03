using System;
using UnityEngine;

namespace VisorWipers.Vanilla
{
    public sealed class WiperHandler : MonoBehaviour
    {
        public WiperHandler(IntPtr ptr) : base(ptr) { }

        private void Update()
        {
            if (FocusStateManager.CurrentState != eFocusState.FPS)
                return;

            if (!Input.GetKeyDown(Configuration.WiperKeyBind))
                return;

            WipeTheVoid.Wipe();
        }
    }
}
