using Runtime.InputSystem;
using Patterns.StateMachine;
using UnityEngine;

namespace Runtime.Character2D
{
    public class TransitionToJumpForward : Transition
    {
        [Header("References")]
        [SerializeField] private CharacterController2D _characterController;
        [SerializeField] private CharacterInput _characterInput;
        [SerializeField] private NameInput _nameInputAction;

        [Header("References can jump")]
        [SerializeField] private CharacterJumpController _characterJumpController;
        [SerializeField] private float _timeJumpForward = 1;

        protected ControlInputBool _controlInput;

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
                    _characterController.isGrounded &&
                    _characterJumpController.LastTimeJumpForward >= _timeJumpForward;
        }
    }
}
