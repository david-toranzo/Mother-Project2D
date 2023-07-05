using DragonBones;
using UnityEngine;

namespace BasicEnemy.Enemy
{
    public class EnemyAnimatorControllerDragonBones : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private UnityArmatureComponent _armatureComponent;
        [SerializeField] private float _timeTransition = 1f;

        [Header("String names")]
        [SerializeField] private string _idleAnimation = "0_idle";
        [SerializeField] private string _walkAnimation = "0_run_FAST";
        [SerializeField] private string _attack1Animation = "0_run_FAST";
        [SerializeField] private string _attack2Animation = "0_run_FAST";

        private bool _isIdle = true;
        private bool _attack = false;

        private void Start()
        {
            _armatureComponent.AddDBEventListener(EventObject.LOOP_COMPLETE, OnAnimationEventCompleted);
        }

        private void OnAnimationEventCompleted(string type, EventObject eventObject)
        {
            if (_attack && _isIdle)
            {
                _armatureComponent.animation.FadeIn(_idleAnimation, _timeTransition, -1);
                _isIdle = true;
                _attack = false;
            }
        }

        public void SetAnimation(float speed)
        {
            if (speed == 0 && !_isIdle)
            {
                _armatureComponent.animation.FadeIn(_idleAnimation, _timeTransition, -1);
                _isIdle = true;
            }
            if (speed != 0 && _isIdle)
            {
                _armatureComponent.animation.FadeIn(_walkAnimation, _timeTransition, -1);
                _isIdle = false;
            }
        }

        public void SetAttack()
        {
            _armatureComponent.animation.FadeIn(_attack1Animation, _timeTransition, -1);
            _isIdle = true;
            _attack = true;
        }
    }
}
