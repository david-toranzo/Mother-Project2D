using Runtime.InputSystem;
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

        [Header("Data")]
        [SerializeField] private CharacterDataSO _characterDataSO;

        private ControlInputBool _controlInput;
        private const float _multiplyJumpForce = 0.5f;

        private float _initialJumpVelocity = 0;

        private void Start()
        {
            SetupJumpParameters();
            _controlInput = GetControlInputBool();
        }

        //DELETE this, only for debug and changed the values in runtime
        private void Update()
        {
            SetupJumpParameters();
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
            //_characterAnimation.JumpAnimation();
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
