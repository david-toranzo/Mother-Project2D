using Runtime.InputSystem;
using Patterns.StateMachine;
using UnityEngine;

namespace Runtime.Character2D
{
    public class TransitionToInputActionInGround : Transition
    {
        [Header("References")]
        [SerializeField] private CharacterController2D _characterController;

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
            return _controlInput.IsInputPressed &&
                _characterController.isGrounded;
        }
    }
}
