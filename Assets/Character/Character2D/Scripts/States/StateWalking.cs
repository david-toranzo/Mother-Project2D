using Patterns.StateMachine;
using UnityEngine;

namespace Runtime.Character2D
{
    public class StateWalking : StateBaseMove
    {
        [Header("References")]
        [SerializeField] protected CharacterStateReference _characterStateReference;

        protected CharacterUnity2D _character;
        protected CharacterDataSO _characterDataSO;

        private const float _groundedGravity = -0.05f;

        protected virtual void Start()
        {
            _character = _characterStateReference.CharacterUnity2D;
            _characterDataSO = _characterStateReference.CharacterDataSO;
        }

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

        protected virtual float GetSpeed()
        {
            return _characterDataSO.WalkSpeed;
        }
    }
}
