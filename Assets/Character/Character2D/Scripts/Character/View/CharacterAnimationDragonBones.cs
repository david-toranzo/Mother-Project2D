using UnityEngine;
using DragonBones;
using Runtime.Common;
using System;

namespace Runtime.Character2D
{
    public class CharacterAnimationDragonBones : MonoBehaviour, IAttackEvent, ICharacterAnimation
    {
        public Action OnAttack { get; set; }

        [Header("References")]
        [SerializeField] private UnityArmatureComponent armatureComponent;

        [Header("Data")]
        [SerializeField] private float _timeTransition = 1f;
        [SerializeField] private float _timeScaleAttack = 1f;

        [Header("String names")]
        public string idleAnimation = "0_idle";
        public string walkAnimation = "0_run_FAST";

        public string jumpAnimation = "0_jump_loop";
        public string fallingAnimation = "0_falling";

        public string dieAnimation = "Die";
        public string blockAnimation = "0_block";

        public string attackAnimation = "Attack";

        enum State { IDLE, WALKING, FALLING, JUMPING, BLOCK, DEAD, ATTACK };
        [Header("Debug")]
        [SerializeField]
        private State state = State.IDLE;

        private bool _isGroundLastFrame = false;

        private void Start()
        {
            armatureComponent.AddDBEventListener(EventObject.LOOP_COMPLETE, OnAnimationEventCompleted);
            armatureComponent.AddEventListener("Attack", OnAnimationEventAttack);
        }

        private void OnAnimationEventCompleted(string type, EventObject eventObject)
        {
            if (state == State.DEAD || state == State.BLOCK)
                return;

            if (state == State.ATTACK)
            {
                armatureComponent.animation.FadeIn(idleAnimation, _timeTransition, -1);
                state = State.IDLE;
            }
        }

        private void OnAnimationEventAttack(string type, EventObject eventObject)
        {
            Debug.Log("Attack animations " + type);
        }

        public void RotateCharacter()
        {
            armatureComponent.FlipX = !armatureComponent.FlipX;
        }

        public void UpdateAnimation(bool _walk, bool sprint)
        {
            if (state == State.DEAD || state == State.BLOCK)
                return;

            if (_walk)
                Walk();
            else
                Idle();
        }

        public void UpdateGroundAnimation(bool isGrounded, float airOffset)
        {
            if (state == State.DEAD || state == State.BLOCK)
                return;

            if (!isGrounded && state != State.FALLING && airOffset < 0)
            {
                armatureComponent.animation.timeScale = 1f;
                armatureComponent.animation.FadeIn(fallingAnimation, _timeTransition, -1);
                state = State.FALLING;
            }
            else if (isGrounded && state != State.IDLE && state != State.WALKING && state != State.JUMPING && state != State.ATTACK) //
            {
                TransitionToIdle();
            }
            else if (state == State.JUMPING && !_isGroundLastFrame && isGrounded)
            {
                TransitionToIdle();
            }

            _isGroundLastFrame = isGrounded;
        }

        private void TransitionToIdle()
        {
            armatureComponent.animation.timeScale = 1f;
            armatureComponent.animation.FadeIn(idleAnimation, _timeTransition, -1);
            state = State.IDLE;
        }

        private void Idle()
        {
            if (state != State.DEAD && state != State.IDLE && state != State.FALLING
                && state != State.JUMPING && state != State.ATTACK)
            {
                TransitionToIdle();
            }
        }

        private void Walk()
        {
            if (state != State.DEAD && state != State.WALKING && state != State.FALLING
                && state != State.JUMPING && state != State.ATTACK)
            {
                armatureComponent.animation.timeScale = 1f;
                armatureComponent.animation.FadeIn(walkAnimation, _timeTransition, -1);
                state = State.WALKING;
            }
        }

        public void Jump()
        {
            if (state != State.DEAD && state != State.JUMPING)
            {
                armatureComponent.animation.FadeIn(jumpAnimation, _timeTransition, -1);
                state = State.JUMPING;
            }
        }

        public void Die()
        {
            if (state != State.DEAD)
            {
                armatureComponent.animation.Play(dieAnimation, 1);
                armatureComponent.animation.timeScale = 1f;
                state = State.DEAD;
            }
        }

        public void Block()
        {
            if (state != State.DEAD && state != State.BLOCK) // && state != State.ATTACK
            {
                armatureComponent.animation.timeScale = _timeScaleAttack;
                armatureComponent.animation.FadeIn(blockAnimation, _timeTransition);
                state = State.BLOCK;
            }
        }

        public void StopBlock()
        {
            if (state != State.DEAD && state == State.BLOCK)
            {
                TransitionToIdle();
            }
        }

        public void Attack(string indexAttack)
        {
            if (state != State.DEAD && state != State.ATTACK)
            {
                OnAttack?.Invoke();
                armatureComponent.animation.timeScale = _timeScaleAttack;
                armatureComponent.animation.FadeIn(indexAttack, _timeTransition);
                state = State.ATTACK;
            }
        }
    }
}