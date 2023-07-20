using UnityEngine;

namespace Runtime.Character2D
{
    public abstract class EnemyAttackerBase : MonoBehaviour
    {
        private IEnemyAttacker _enemyAttacker;

        private void Start()
        {
            _enemyAttacker = GetComponent<IEnemyAttacker>();

            _enemyAttacker.OnTouchEnemy += MakeAttack;
        }

        protected abstract void MakeAttack(Vector2 enemy);

        private void OnDestroy()
        {
            _enemyAttacker.OnTouchEnemy -= MakeAttack;
        }
    }
}