using UnityEngine;

namespace Runtime.Character2D
{
    public class EffectHitAnimator : EnemyAttackerBase
    {
        [SerializeField] private Animator _partycleEffect;

        private string _nameAnimation = "Hit";

        protected override void MakeAttack(Vector2 enemy)
        {
            _partycleEffect.transform.position = enemy;
            _partycleEffect.Play(_nameAnimation);
        }
    }
}