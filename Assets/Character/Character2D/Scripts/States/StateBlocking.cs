using Common;
using Patterns.StateMachine;
using UnityEngine;

namespace Runtime.Character2D
{
    public class StateBlocking : StateBaseMove
    {
        [Header("References")]
        [SerializeField] private CharacterAnimation _characterAnimation;
        [SerializeField] protected CharacterUnity2D _character;
        [SerializeField] protected HealthPlayerController _healthPlayerController;

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
