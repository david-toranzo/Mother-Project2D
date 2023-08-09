using Common;
using Patterns.StateMachine;
using UnityEngine;

namespace Runtime.Character2D
{
    public class StateBlocking : StateBaseMove
    {
        [Header("References")]
        [SerializeField] protected CharacterStateReference _characterStateReference;

        protected CharacterUnity2D _character;
        protected HealthPlayerController _healthPlayerController;

        private CharacterAnimation _characterAnimation;

        private void Start()
        {
            _healthPlayerController = _characterStateReference.HealthPlayerController;
            _character = _characterStateReference.CharacterUnity2D;
            _characterAnimation = _characterStateReference.CharacterAnimation;
        }

        public override void Enter() 
        {
            _healthPlayerController.SetBlockAttack(true);
            _character.ResetVelocityMove();
            _characterAnimation.BlockAnimation();
        }

        public override void Exit()
        {
            _healthPlayerController.SetBlockAttack(false);
            _characterAnimation.StopBlockAnimation();
        }

        protected override void ProcessWorkActualState() { }
    }
}
