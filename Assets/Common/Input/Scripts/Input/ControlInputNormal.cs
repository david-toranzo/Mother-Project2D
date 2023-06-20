using UnityEngine;
using UnityEngine.InputSystem;

namespace Runtime.InputSystem
{
    public class ControlInputNormal : ControlInput
    {
        protected override void ImplementEventInputAction(InputAction.CallbackContext context)
        {
            OnInputEvent.Invoke();
        }
    }
}
