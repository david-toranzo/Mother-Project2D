using Patterns.StateMachine;
using UnityEngine;

namespace Runtime.Character2D
{
    public class TransitionToFalling : Transition
    {
        [Header("Falling")]
        [SerializeField] private CharacterController2D _characterController;

        public override bool GetProcessTransitionVerification()
        {
            return !_characterController.isGrounded;
        }
    }
}
