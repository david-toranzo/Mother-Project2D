using UnityEngine;
using Runtime.Common;
using System;
using Spine.Unity;
using Spine;

namespace Runtime.Character2D
{
    public class CharacterAnimationSpine : MonoBehaviour, IAttackEvent, ICharacterAnimation
    {
        public Action OnAttack { get; set; }

        [SerializeField] private SkeletonAnimation skeletonAnimation;
        [SerializeField] private AnimationReferenceAsset animationWalk;
        [SerializeField] private AnimationReferenceAsset animationAttack;

        public void AttackAnimation(string nameAttack)
        {
            var state = skeletonAnimation.AnimationState.SetAnimation(1, animationAttack, false);
            state.Complete += State_Complete;
        }

        private void State_Complete(TrackEntry trackEntry)
        {
            Debug.Log("Idle");
            skeletonAnimation.AnimationState.SetAnimation(1, animationWalk, true);
            trackEntry.Dispose -= State_Complete;
        }

        public void RotateCharacter()
        {
        }

        public void UpdateAnimation(bool _walk, bool sprint)
        {
            if(_walk)
                skeletonAnimation.AnimationState.SetAnimation(1, animationWalk, true);
        }

        public void UpdateGroundAnimation(bool isGrounded, float airOffset)
        {
        }
    }
}