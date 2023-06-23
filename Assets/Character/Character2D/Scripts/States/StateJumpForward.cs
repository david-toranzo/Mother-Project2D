using Runtime.InputSystem;
using Patterns.StateMachine;
using UnityEngine;

namespace Runtime.Character2D
{
    public class StateJumpForward : StateBaseMove
    {
        [Header("References jump forward")]
        [SerializeField] private CharacterUnity2D _character;
        [SerializeField] private CharacterJumpController _characterJumpController;
        [SerializeField] private Animator _animator;

        [Header("Input")]
        [SerializeField] private CharacterInput _characterInput;
        [SerializeField] private NameInput _nameInputAction;

        [Header("Jump forward")]
        [SerializeField] private CharacterDataSO _characterDataSO;

        private ControlInputBool _controlInput;

        private void Start()
        {
            _controlInput = GetControlInputBool();
        }

        private ControlInputBool GetControlInputBool()
        {
            return _characterInput.GetControlInputByString(_nameInputAction.NameControlInput) as ControlInputBool;
        }

        public override void Enter()
        {
            _animator.Play("JumpFront");

            _characterJumpController.NotifyJumpCharacter();
            _characterJumpController.IsJumping = true;
            _characterJumpController.LastTimeJumpForward = 0;
            SetMoveMakeJump();
        }

        public override void Exit()
        {
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
