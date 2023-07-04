using UnityEngine;

namespace BasicEnemy.Enemy
{
    public class EnemyMovement : Movement
    {
        [SerializeField] private EnemyAnimatorControllerDragonBones _enemyAnimatorIdleWalk;

        private void Update()
        {
            UpdateAnimation();
        }

        protected void UpdateAnimation()
        {
            float speedAnimator = _lastMoveDistance != 0 ? 1 : 0;
            _enemyAnimatorIdleWalk.SetAnimation(speedAnimator);
            //animator.SetFloat(stringAnimatorForwardSpeed, speedAnimator);
        }
    }
}
