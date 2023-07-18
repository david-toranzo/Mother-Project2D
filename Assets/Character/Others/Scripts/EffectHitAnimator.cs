using UnityEngine;

namespace Runtime.Character2D
{
    public class EffectHitAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _partycleEffect;

        private IEnemyAttacker _enemyAttacker;
        private string _nameAnimation = "Hit";

        private void Start()
        {
            _enemyAttacker = GetComponent<IEnemyAttacker>();

            _enemyAttacker.OnTouchEnemy += MakeAttack;
        }

        public void MakeAttack(Vector2 enemy)
        {
            _partycleEffect.transform.position = enemy;
            _partycleEffect.Play(_nameAnimation);
        }
    }
}