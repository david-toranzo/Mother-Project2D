using Patterns.StateMachine;
using UnityEngine;

namespace Runtime.Character2D
{
    public class StateWalking : StateBaseMove
    {
        [Header("References")]
        [SerializeField] protected CharacterUnity2D _character;

        [Header("Data")]
        [SerializeField] private CharacterDataSO _characterDataSO;

        private const float _groundedGravity = -0.05f;

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
            return _characterDataSO.WalkSpeed;
        }
    }
}
