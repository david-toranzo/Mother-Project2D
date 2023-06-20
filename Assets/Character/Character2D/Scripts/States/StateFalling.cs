using Patterns.StateMachine;
using System;
using UnityEngine;

namespace Runtime.Character2D
{
    public class StateFalling : StateBaseMove
    {
        public Action OnChangeStateFalling { get; set; }

        [Header("Character")]
        [SerializeField] protected CharacterUnity2D _character;
        [SerializeField] protected CharacterJumpController _characterJumpController;

        [Header("Gravity")] 
        [SerializeField] private float _multiplyGravityFactor = 3f;
        [SerializeField] private float _gravity = -9.8f;
        [SerializeField] private float _groundedGravity = -0.05f;

        [Header("Move in air")]
        [SerializeField] private float _walkSpeed = 2.5f;

        public override void Enter() 
        {
            OnChangeStateFalling?.Invoke();
        }

        public override void Exit()
        {
            _characterJumpController.ResetAllValues();
            _character.Velocity = new Vector3(_character.Velocity.x, _groundedGravity, _character.Velocity.z);
            OnChangeStateFalling?.Invoke();
        }

        protected override void ProcessWorkActualState()
        {
            Vector3 velocityPrevious = _character.Velocity;
            float previousYVelocity = velocityPrevious.y;
            float newYVelocity = velocityPrevious.y + _gravity * Time.deltaTime * _multiplyGravityFactor;
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
            return _walkSpeed;
        }
    }
}
