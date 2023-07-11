using UnityEngine;

namespace BasicEnemy.Enemy
{
    public class EnemyMovement : Movement
    {
        [SerializeField] private EnemyAnimatorControllerDragonBones _enemyAnimatorIdleWalk;

        private void Update()
        {
            UpdateAnimation();

            _lastMoveDistance = 0;
        }

        protected void UpdateAnimation()
        {
            float speedAnimator = _lastMoveDistance != 0 ? 1 : 0;
            _enemyAnimatorIdleWalk.SetAnimation(speedAnimator);
            //animator.SetFloat(stringAnimatorForwardSpeed, speedAnimator);
        }
    }
}
