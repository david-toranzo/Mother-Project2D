using Patterns.StateMachine;
using UnityEngine;

namespace Runtime.Character2D
{
    public class TransitionToWalkFromAttack : Transition
    {
        [Header("Fighter")]
        [SerializeField] private CharacterFighter _characterFighter;
        [SerializeField] private float _velocityClip = 0.5f;

        public override bool GetProcessTransitionVerification()
        {
            return _velocityClip < _characterFighter.TimeBetweenLastAttack;
        }
    }
}
