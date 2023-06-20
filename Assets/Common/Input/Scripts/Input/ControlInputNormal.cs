using UnityEngine;
using UnityEngine.InputSystem;

namespace David.InputSystem
{
    public class ControlInputNormal : ControlInput
    {
        protected override void ImplementEventInputAction(InputAction.CallbackContext context)
        {
            OnInputEvent.Invoke();
        }
    }
}
