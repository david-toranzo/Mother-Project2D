using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace David.InputSystem
{
    public class ControlInputFloat : ControlInput
    {
        public new Action<float> OnInputEvent = delegate { };

        protected override void ImplementEventInputAction(InputAction.CallbackContext context)
        {
            float getYReadValueScroll = context.ReadValue<Vector2>().y;
            OnInputEvent.Invoke(getYReadValueScroll);
        }
    }
}