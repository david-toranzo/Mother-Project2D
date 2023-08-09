using Runtime.InputSystem;
using Patterns.StateMachine;
using UnityEngine;
using Common;

namespace Runtime.Character2D
{
    public class StateJumpForward : StateBaseMove
    {
        [Header("References jump forward")]
        [SerializeField] protected CharacterStateReference _characterStateReference;

        [Header("Input")]
        [SerializeField] private NameInput _nameInputAction;

        private HealthPlayerController _healthPlayerController;
        private CharacterUnity2D _character;
        private CharacterJumpController _characterJumpController;
        private CharacterInput _characterInput;
        private CharacterDataSO _characterDataSO;
        private Animator _animator;

        private ControlInputBool _controlInput;

        private void Start()
        {
            _healthPlayerController = _characterStateReference.HealthPlayerController;
            _character = _characterStateReference.CharacterUnity2D;
            _characterJumpController = _characterStateReference.CharacterJumpController;
            _characterInput = _characterStateReference.CharacterInput;
            _characterDataSO = _characterStateReference.CharacterDataSO;
            _animator = _characterStateReference.Animator;

            _controlInput = GetControlInputBool();
        }

        private ControlInputBool GetControlInputBool()
        {
            return _characterInput.GetControlInputByString(_nameInputAction.NameControlInput) as ControlInputBool;
        }

        public override void Enter()
        {
            _animator.SetTrigger("jumpForward");

            _healthPlayerController.SetBlockAttack(true);

            _characterJumpController.NotifyJumpCharacter();
            _characterJumpController.IsJumping = true;
            _characterJumpController.LastTimeJumpForward = 0;
            SetMoveMakeJump();
        }

        public override void Exit()
        {
            _healthPlayerController.SetBlockAttack(false);

            _characterJumpController.IsJumping = false;
            _characterJumpController.LastTimeJumpForward = 0;
            _controlInput.IsInputPressed = false;
        }

        protected override void ProcessWorkActualState()
        {
            SetMoveMakeJump();
        }

        private void SetMoveMakeJump()
        {
            Vector3 velocityToApply = _character.transform.right * _characterDataSO.VelocityJumpForward;
            velocityToApply.y = _character.Velocity.y;
            _character.Velocity = velocityToApply;
        }
    }
}
