﻿using Common;
using DragonBones;
using Runtime.Common;
using System;
using UnityEngine;

namespace BasicEnemy.Enemy
{
    public class EnemyAnimatorControllerDragonBones : MonoBehaviour, IAttackEvent
    {
        public Action OnAttack { get; set; }
        public Action OnCancelAttack { get; set; }

        [Header("References")]
        [SerializeField] private UnityArmatureComponent _armatureComponent;
        [SerializeField] private float _timeTransition = 1f;
        [SerializeField] private float _velocityAttack = 2f;
        [SerializeField] private float _velocityWalk = 2f;

        [Header("String names")]
        [SerializeField] private string _idleAnimation = "0_idle";
        [SerializeField] private string _walkAnimation = "0_run_FAST";
        [SerializeField] private string _attack1Animation = "0_run_FAST";
        [SerializeField] private string _attack2Animation = "0_run_FAST";
        [SerializeField] private string _hitAnimation = "hit";
        [SerializeField] private string _deathAnimation = "death";

        enum State { IDLE, WALKING, HIT, DEAD, ATTACK };
        [Header("Debug")]
        [SerializeField]
        private State _currentState = State.IDLE;

        private bool _attack = false;

        private void Start()
        {
            GetComponent<IHealth>().OnDie += Die;
            GetComponent<IHealth>().OnSubstractHealth += OnHit;

            _armatureComponent.AddDBEventListener(EventObject.LOOP_COMPLETE, OnAnimationEventCompleted);
        }

        private void OnHit(int obj)
        {
            if (_currentState == State.DEAD)
                return;

            OnCancelAttack?.Invoke();
            _armatureComponent.animation.FadeIn(_hitAnimation, _timeTransition, -1);
            _currentState = State.HIT;
        }

        private void OnAnimationEventCompleted(string type, EventObject eventObject)
        {
            if (_attack && _currentState == State.IDLE && _currentState != State.DEAD)
            {
                TransitionToIdle();
                _attack = false;
            } 
            else if (_currentState == State.HIT)
            {
                TransitionToIdle();
            }
        }

        private void TransitionToIdle()
        {
            _armatureComponent.animation.timeScale = 1;
            _armatureComponent.animation.FadeIn(_idleAnimation, _timeTransition, -1);
            _currentState = State.IDLE;
        }

        public void SetAnimation(float speed)
        {
            if (_currentState == State.DEAD || _currentState == State.HIT)
                return;

            if (speed == 0 && _currentState != State.IDLE)
                TransitionToIdle();
            if (speed != 0 && _currentState == State.IDLE)
            {
                _armatureComponent.animation.FadeIn(_walkAnimation, _timeTransition/2, -1);
                _armatureComponent.animation.timeScale = _velocityWalk;
                _currentState = State.WALKING;
            }
        }

        public void SetAttack()
        {
            if (_currentState == State.DEAD || _currentState == State.HIT)
                return;

            OnAttack?.Invoke();
            string attackAnim = UnityEngine.Random.Range(0,2) == 0 ? _attack1Animation : _attack2Animation;
            _armatureComponent.animation.FadeIn(attackAnim, _timeTransition, -1);
            _armatureComponent.animation.timeScale = _velocityAttack;

            _currentState = State.IDLE;
            _attack = true;
        }

        private void Die()
        {
            _armatureComponent.animation.Play(_deathAnimation, 1);
            OnCancelAttack?.Invoke();
            _currentState = State.DEAD;
        }
    }
}
