using Common;
using DragonBones;
using Runtime.Common;
using System;
using UnityEngine;

namespace BasicEnemy.Enemy
{
    public class EnemyAnimatorControllerDragonBones : MonoBehaviour, IAttackEvent
    {
        public Action OnAttack { get; set; }

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
        [SerializeField] private string _deathAnimation = "death";

        private bool _isIdle = true;
        private bool _attack = false;
        private bool _death = false;

        private void Start()
        {
            GetComponent<IHealth>().OnDie += Die;
            _armatureComponent.AddDBEventListener(EventObject.LOOP_COMPLETE, OnAnimationEventCompleted);
        }

        private void OnAnimationEventCompleted(string type, EventObject eventObject)
        {
            if (_attack && _isIdle && !_death)
            {
                TransitionToIdle();
                _attack = false;
            }
        }

        private void TransitionToIdle()
        {
            _armatureComponent.animation.timeScale = 1;
            _armatureComponent.animation.FadeIn(_idleAnimation, _timeTransition, -1);
            _isIdle = true;
        }

        public void SetAnimation(float speed)
        {
            if (_death)
                return;

            if (speed == 0 && !_isIdle)
                TransitionToIdle();
            if (speed != 0 && _isIdle)
            {
                _armatureComponent.animation.FadeIn(_walkAnimation, _timeTransition/2, -1);
                _armatureComponent.animation.timeScale = _velocityWalk;
                _isIdle = false;
            }
        }

        public void SetAttack()
        {
            if (_death)
                return;

            OnAttack?.Invoke();
            string attackAnim = UnityEngine.Random.Range(0,2) == 0 ? _attack1Animation : _attack2Animation;
            _armatureComponent.animation.FadeIn(attackAnim, _timeTransition, -1);
            _armatureComponent.animation.timeScale = _velocityAttack;
            _isIdle = true;
            _attack = true;
        }

        private void Die()
        {
            _armatureComponent.animation.Play(_deathAnimation, 1);
            _death = true;
        }
    }
}
