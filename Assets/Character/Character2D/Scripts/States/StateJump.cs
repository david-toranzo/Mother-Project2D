using Runtime.InputSystem;
using Patterns.StateMachine;
using UnityEngine;

namespace Runtime.Character2D
{
    public class StateJump : StateBaseMove
    {
        [Header("References")]
        [SerializeField] protected CharacterStateReference _characterStateReference;

        [Header("Input")]
        [SerializeField] private NameInput _nameInputAction;


        protected CharacterJumpController _characterJumpController;

        private CharacterUnity2D _character;
        private CharacterInput _characterInput;
        private CharacterDataSO _characterDataSO;

        private ControlInputBool _controlInput;
        private const float _multiplyJumpForce = 0.5f;

        private float _initialJumpVelocity = 0;

        private void Start()
        {
            _character = _characterStateReference.CharacterUnity2D;
            _characterInput = _characterStateReference.CharacterInput;
            _characterDataSO = _characterStateReference.CharacterDataSO;
            _characterJumpController = _characterStateReference.CharacterJumpController;

            SetupJumpParameters();
            _controlInput = GetControlInputBool();
        }

        private ControlInputBool GetControlInputBool()
        {
            return _characterInput.GetControlInputByString(_nameInputAction.NameControlInput) as ControlInputBool;
        }

        private void SetupJumpParameters()
        {
            float timeToApex = _characterDataSO.MaxJumpTime / 2;
            _initialJumpVelocity = (2 * _characterDataSO.MaxJumpHeight) / timeToApex;
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
            _character.Velocity = new Vector3
                (_character.Velocity.x, 
                _initialJumpVelocity * _multiplyJumpForce,
                _character.Velocity.z);

            _characterJumpController.NotifyJumpCharacter();
        }
    }
}
