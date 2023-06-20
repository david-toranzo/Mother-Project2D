using Patterns.StateMachine;
using UnityEngine;

namespace Runtime.Character2D
{
    public class TransitionToWalkFromAttack : Transition
    {
        [Header("Fighter")]
        [SerializeField] private CharacterFighter _characterFighter;
        [SerializeField] private AnimationClip _attackClip;
        [SerializeField] private float _velocityClip = 2;

        public override bool GetProcessTransitionVerification()
        {
            return (_attackClip.averageDuration / _velocityClip) < _characterFighter.TimeBetweenLastAttack;
        }
    }
}
