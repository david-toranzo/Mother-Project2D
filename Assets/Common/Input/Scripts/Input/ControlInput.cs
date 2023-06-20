using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace David.InputSystem
{
    public abstract class ControlInput : ControlInputBase
    {
        public Action OnInputEvent = delegate { };

        [Header("Who action'll be use")]
        [SerializeField] private bool _startedAction = true;
        [SerializeField] private bool _performedAction = true;
        [SerializeField] private bool _endAction = true;

        protected override void Awake()
        {
            base.Awake();
            SubscribeInputEvents();
        }

        protected void SubscribeInputEvents()
        {
            if(_startedAction)
                CurrentInputAction.started += ImplementEventInputAction;

            if (_performedAction)
                CurrentInputAction.performed += ImplementEventInputAction;

            if (_endAction)
                CurrentInputAction.canceled += ImplementEventInputAction;
        }

        private void OnDestroy()
        {
            DesubscribeInputEvents();
        }

        protected void DesubscribeInputEvents()
        {
            if (_startedAction)
                CurrentInputAction.started -= ImplementEventInputAction;

            if (_performedAction)
                CurrentInputAction.performed -= ImplementEventInputAction;

            if (_endAction)
                CurrentInputAction.canceled -= ImplementEventInputAction;
        }

        protected abstract void ImplementEventInputAction(InputAction.CallbackContext context);
    }
}