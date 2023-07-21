using UnityEngine;

namespace Runtime.Character2D
{
    public class EffectHitAnimator : EnemyAttackerBase
    {
        [SerializeField] private Animator[] _partycleEffects;

        private const string _nameAnimation = "Hit";
        private int _currentIndex = 0;

        protected override void MakeAttack(Vector2 enemy)
        {
            _partycleEffects[_currentIndex].transform.position = enemy;
            _partycleEffects[_currentIndex].Play(_nameAnimation);

            _currentIndex = _currentIndex + 1;
            _currentIndex = _currentIndex % _partycleEffects.Length;
        }
    }
}