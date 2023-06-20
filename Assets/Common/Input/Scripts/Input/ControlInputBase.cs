using UnityEngine;
using UnityEngine.InputSystem;

namespace Runtime.InputSystem
{
    public abstract class ControlInputBase : MonoBehaviour
    {
        [SerializeField] protected InputActionAsset _actions;
        [SerializeField] private NameInput _inputActionName;

        public string InputActionName => _inputActionName.NameControlInput;

        protected InputAction CurrentInputAction { get; set; }

        protected virtual void Awake()
        {
            InitializeInputAction();
        }

        private void InitializeInputAction()
        {
            CurrentInputAction = GetInputActionByName(_inputActionName.NameControlInput);
        }

        private InputAction GetInputActionByName(string nameInput)
        {
            return _actions.FindAction(nameInput);
        }

        private void OnEnable()
        {
            OnEnableInputAction();
        }

        private void OnDisable()
        {
            OnDisabledInputAction();
        }

        public void OnEnableInputAction()
        {
            CurrentInputAction?.Enable();
        }

        public void OnDisabledInputAction()
        {
            CurrentInputAction?.Disable();
        }
    }
}