using Runtime.InputSystem;
using Patterns.StateMachine;
using UnityEngine;

namespace Runtime.Character2D
{
    public class TransitionToStateNonInput : Transition
    {
        [Header("Input")]
        [SerializeField] private CharacterInput _characterInput;
        [SerializeField] private NameInput _nameInputAction;

        private ControlInputBool _controlInput;

        private void Start()
        {
            _controlInput = GetControlInputBool();
        }

        private ControlInputBool GetControlInputBool()
        {
            return _characterInput.GetControlInputByString(_nameInputAction.NameControlInput) as ControlInputBool;
        }

        public override bool GetProcessTransitionVerification()
        {
            return !_controlInput.IsInputPressed;
        }
    }
}
