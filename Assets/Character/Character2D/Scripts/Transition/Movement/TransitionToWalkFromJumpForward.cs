using Patterns.StateMachine;
using UnityEngine;

namespace Runtime.Character2D
{
    public class TransitionToWalkFromJumpForward : Transition
    {
        [Header("References")]
        [SerializeField] private CharacterJumpController _characterJumpController;
        [SerializeField] private float _timeJumpForward = 1;

        public override bool GetProcessTransitionVerification()
        {
            return _characterJumpController.LastTimeJumpForward >= _timeJumpForward;
        }
    }
}
