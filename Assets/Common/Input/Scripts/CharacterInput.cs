using UnityEngine;
using UnityEngine.InputSystem;

namespace Runtime.InputSystem
{
    public class CharacterInput : MonoBehaviour
    {
        [SerializeField] private ControlInputBase[] _controlsInput;

        [Header("Input")]
        [Tooltip("Input actions associated with this Character\n.")]
        [SerializeField] protected InputActionAsset _actions;

        [Header("Mouse Cursor Settings")]
        [SerializeField] bool cursorLocked = true;

        #region MONOBEHAVIOUR

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
            // Enable input actions
            foreach (ControlInputBase controlInput in _controlsInput)
            {
                controlInput.OnEnableInputAction();
            }
        }

        public void OnDisabledInputAction()
        {
            // Disable input actions
            foreach (ControlInputBase controlInput in _controlsInput)
            {
                controlInput.OnDisabledInputAction();
            }
        }

        #endregion

        #region INPUT ACTIONS

        public InputActionAsset InputActionAssets => _actions;

        protected InputActionAsset Actions
        {
            get => _actions;
            private set => _actions = value;
        }

        #endregion

        #region METHODS

        public ControlInputBase GetControlInputByString(string compareString)
        {
            foreach (ControlInputBase controlInput in _controlsInput)
            {
                if (controlInput.InputActionName == compareString)
                    return controlInput;
            }
            return null;
        }

        public ControlInputBase GetControlInputBaseByString(string compareString)
        {
            foreach (ControlInputBase controlInput in _controlsInput)
            {
                if (controlInput.InputActionName == compareString)
                    return controlInput;
            }
            return null;
        }

        public InputAction GetInputActionByName(string nameInput)
        {
            return _actions.FindAction(nameInput);
        }

        public void SetInputActionAssets(InputActionAsset actions)
        {
            _actions = actions;
        }

        #endregion

        #region OTHER METHODS

        private void OnApplicationFocus(bool hasFocus)
        {
            SetCursorState(cursorLocked);
        }

        private void SetCursorState(bool newState)
        {
            Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
        }

        #endregion
    }
}