using UnityEngine;

namespace Runtime.Character2D
{
    public class EnemyReceiveAttackMoving : MonoBehaviour
    {
        [SerializeField] private Transform _transformPlayer;
        [SerializeField] private float _distanceBetweenEnemy = 2f;

        private IEnemyAttacker _enemyAttacker;

        private void Start()
        {
            _enemyAttacker = GetComponent<IEnemyAttacker>();

            _enemyAttacker.OnAttackEnemyWithObject += MakeAttack;
        }

        private void OnDestroy()
        {
            _enemyAttacker.OnAttackEnemyWithObject -= MakeAttack;
        }

        protected void MakeAttack(GameObject enemy)
        {
            float distanceToEnemy = Vector2.Distance(_transformPlayer.position, enemy.transform.position);
            float currentDistancePercent = distanceToEnemy/_distanceBetweenEnemy;

            var forceEnemy = enemy.GetComponent<IForceMoving>();
            forceEnemy.SetForceWithDirection(1-currentDistancePercent, _transformPlayer.right);
        }
    }
}