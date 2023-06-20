using Patterns.StateMachine;
using UnityEngine;

namespace Runtime.Character2D
{
    public class TransitionToJumpFromFalling : Transition
    {
        [Header("References")]
        [SerializeField] private CharacterJumpController _characterJumpController;

        public override bool GetProcessTransitionVerification()
        {
            return _characterJumpController.CanJump() && !_characterJumpController.IsJumping;
        }
    }
}
