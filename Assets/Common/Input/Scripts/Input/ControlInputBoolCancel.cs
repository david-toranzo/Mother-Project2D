using System;
using UnityEngine.InputSystem;

namespace Runtime.InputSystem
{
    public class ControlInputBoolCancel : ControlInputBool
    {
        public Action OnCancelInputEvent = delegate { };

        protected override void ImplementEventInputAction(InputAction.CallbackContext context)
        {
            base.ImplementEventInputAction(context);

            if (context.canceled && _worksWithEvent)
                OnCancelInputEvent.Invoke();
        }
    }
}
