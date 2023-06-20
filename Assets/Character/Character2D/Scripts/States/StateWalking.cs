using Patterns.StateMachine;
using UnityEngine;

namespace Runtime.Character2D
{
    public class StateWalking : StateBaseMove
    {
        [Header("References")]
        [SerializeField] protected CharacterUnity2D _character;

        [Header("Data walk")]
        [SerializeField] private float _walkSpeed = 2.5f;
        [SerializeField] private float _groundedGravity = -0.05f;

        public override void Enter() {}

        public override void Exit() {}

        protected override void ProcessWorkActualState()
        {
            Walking();
        }

        private void Walking()
        {            
            Vector3 movVector = _character.GetMovementVector(GetSpeed());
            movVector.y = _groundedGravity;

            _character.Velocity = movVector;
        }

        private float GetSpeed()
        {
            return _walkSpeed;
        }
    }
}
