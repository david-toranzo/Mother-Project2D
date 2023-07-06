using Common;
using Runtime.Common;
using UnityEngine;

namespace BasicEnemy.Enemy
{
    public class FighterEnemy : Fighter, IFighter
    {
        [Header("Enemy")]
        [SerializeField] protected float _shoutDistanceTakeDamage = 0.8f;
        [SerializeField] private EnemyAnimatorControllerDragonBones _enemyAnimatorDragonBones;

        private GameObject _lastTarget;
        private Movement _movement;

        protected override void Start()
        {
            base.Start();
            _movement = GetComponent<Movement>();
        }

        public bool CanAttack(GameObject target)
        {
            if (target is null)
                return false;

            if (CantMoveAndIsNotInRange(target)) 
                return false;

            IHealth targetToTest = target.GetComponent<IHealth>();
            return targetToTest != null && !targetToTest.IsDead();
        }

        private bool CantMoveAndIsNotInRange(GameObject target)
        {
            return !_movement.CanMoveTo(target.transform.position)
                            && !GetIsInRange(target.transform);
        }

        public void Attack(GameObject target)
        {
            AttackBehaviour(target);
        }

        private void AttackBehaviour(GameObject target)
        {
            UpdateTimeBetweenLastAttack();

            if (_timeBetweenLastAttack >= _timeBetweenAttack)
            {
                if (!GetIsInRange(target.transform))
                {
                    GetComponent<Movement>().StartMoveAction(target.transform.position, 1);
                    return;
                }

                TriggetAttack();

                _lastTarget = target;
                _timeBetweenLastAttack = 0;
            }
        }

        public bool GetIsInRange(Transform targetTransform)
        {
            return Vector3.Distance(transform.position, targetTransform.position) < _distanceAttack;
        }

        private void TriggetAttack()
        {
            _enemyAnimatorDragonBones.SetAttack();
        }

        public override void MakeAttack()
        {
            Debug.Log("MakeAttack");
            if (Vector3.Distance(_positionToAttack.transform.position, _lastTarget.transform.position)
                < _shoutDistanceTakeDamage)
            {
                Debug.Log("MakeAttack take damage");

                IHealth targetToTest = _lastTarget.GetComponent<IHealth>();
                targetToTest.ReceiveAttack(_damage);
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_positionToAttack.transform.position, _shoutDistanceTakeDamage);
        }
    }
}
