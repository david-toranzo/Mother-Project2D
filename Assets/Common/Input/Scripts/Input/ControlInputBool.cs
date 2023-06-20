using UnityEngine;
using UnityEngine.InputSystem;

namespace Runtime.InputSystem
{
    public class ControlInputBool : ControlInput
    {
        [Header("Input bool")]
        [SerializeField] protected bool _worksWithEvent = true;

        protected bool _isInputPressed = false;

        public virtual bool IsInputPressed { get => _isInputPressed; set => _isInputPressed = value; }

        protected override void ImplementEventInputAction(InputAction.CallbackContext context)
        {
            InvokeEventInput(context);

            if (context.started || context.performed)
                ActiveInputEvent();
            else if (context.canceled)
                InputEventCanceled();
        }

        private void InvokeEventInput(InputAction.CallbackContext context)
        {
            if (context.started && _worksWithEvent)
                OnInputEvent.Invoke();
        }

        private void ActiveInputEvent()
        {
            _isInputPressed = true;
        }

        private void InputEventCanceled()
        {
            _isInputPressed = false;
        }
    }
}
