using David.InputSystem;
using Patterns.StateMachine;
using UnityEngine;

namespace Runtime.Character2D
{
    public class StateJump : StateBaseMove
    {
        [Header("References")]
        [SerializeField] private CharacterUnity2D _character;
        [SerializeField] protected CharacterJumpController _characterJumpController;

        [Header("Input")]
        [SerializeField] private CharacterInput _characterInput;
        [SerializeField] private NameInput _nameInputAction;

        [Header("Jump")]
        [SerializeField] private float _maxJumpHeight = 1;
        [SerializeField] private float _maxJumpTime = 0.5f;

        private ControlInputBool _controlInput;
        private const float _multiplyJumpForce = 0.5f;

        private float _initialJumpVelocity = 0;

        private void Start()
        {
            SetupJumpParameters();
            _controlInput = GetControlInputBool();
        }

        private ControlInputBool GetControlInputBool()
        {
            return _characterInput.GetControlInputByString(_nameInputAction.NameControlInput) as ControlInputBool;
        }

        private void SetupJumpParameters()
        {
            float timeToApex = _maxJumpTime / 2;
            _initialJumpVelocity = (2 * _maxJumpHeight) / timeToApex;
        }

        public override void Enter()
        {
            _characterJumpController.IsJumping = true;
            SetMoveMakeJump();
        }

        public override void Exit()
        {
            _controlInput.IsInputPressed = false;
        }

        protected override void ProcessWorkActualState()
        {
        }

        private void SetMoveMakeJump()
        {
            //_character.MakeJump(_initialJumpVelocity * _multiplyJumpForce);
            _character.Velocity = new Vector3
                (_character.Velocity.x, 
                _initialJumpVelocity * _multiplyJumpForce,
                _character.Velocity.z);

            _characterJumpController.NotifyJumpCharacter();
        }
    }
}
