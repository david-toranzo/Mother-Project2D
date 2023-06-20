using Patterns.StateMachine;
using UnityEngine;

namespace Runtime.Character2D
{
    public class TransitionToDoubleJump : Transition
    {
        [Header("References")]
        [SerializeField] private CharacterJumpController _characterJumpController;

        public override bool GetProcessTransitionVerification()
        {
            return _characterJumpController.CanMakeDoubleJump();
        }
    }
}
