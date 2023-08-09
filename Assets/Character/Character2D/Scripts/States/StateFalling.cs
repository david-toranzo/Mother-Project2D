using Patterns.StateMachine;
using System;
using UnityEngine;

namespace Runtime.Character2D
{
    public class StateFalling : StateBaseMove
    {
        public Action OnChangeStateFalling { get; set; }

        [Header("Character")]
        [SerializeField] protected CharacterStateReference _characterStateReference;

        protected CharacterUnity2D _character;
        protected CharacterJumpController _characterJumpController;
        private CharacterDataSO _characterDataSO;

        private void Start()
        {
            _character = _characterStateReference.CharacterUnity2D;
            _characterJumpController = _characterStateReference.CharacterJumpController;
            _characterDataSO = _characterStateReference.CharacterDataSO;
        }

        public override void Enter() 
        {
            OnChangeStateFalling?.Invoke();
        }

        public override void Exit()
        {
            _characterJumpController.ResetAllValues();
            _character.Velocity = new Vector3(_character.Velocity.x, _characterDataSO.GroundedGravity, _character.Velocity.z);
            OnChangeStateFalling?.Invoke();
        }

        protected override void ProcessWorkActualState()
        {
            Vector3 velocityPrevious = _character.Velocity;
            float previousYVelocity = velocityPrevious.y;
            float newYVelocity = velocityPrevious.y + _characterDataSO.Gravity * Time.deltaTime * _characterDataSO.MultiplyGravityFactor;
            float nextYVelocity = (previousYVelocity + newYVelocity) * .5f;

            _characterJumpController.LastTimeFalling += Time.deltaTime;
            velocityPrevious = GetMoveFallingVector();

            _character.Velocity = new Vector3(velocityPrevious.x, nextYVelocity, velocityPrevious.z);
        }

        private Vector3 GetMoveFallingVector()
        {
            return _character.GetMovementVector(GetSpeed());
        }

        private float GetSpeed()
        {
            return _characterDataSO.WalkSpeed;
        }
    }
}
