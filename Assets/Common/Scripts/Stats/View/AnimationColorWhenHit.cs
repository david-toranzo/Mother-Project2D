using System.Collections;
using UnityEngine;

namespace Common
{
    public class AnimationColorWhenHit : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private HealthController _healthController;
        [SerializeField] private SpriteRenderer _spriteHit;

        [Header("Data")]
        [SerializeField] private Color _colorDefault;
        [SerializeField] private Color _colorHit;
        [SerializeField] private float _secondToWait;

        private void Start()
        {
            _healthController.OnSubstractHealth += MakeAnimator;
        }

        private void MakeAnimator(int value)
        {
            StartCoroutine(MakeAnimationChangeColor());
        }

        private IEnumerator MakeAnimationChangeColor()
        {
            _spriteHit.color = _colorHit;
            yield return new WaitForSeconds(_secondToWait);
            _spriteHit.color = _colorDefault;

            yield return new WaitForSeconds(_secondToWait);

            _spriteHit.color = _colorHit;
            yield return new WaitForSeconds(_secondToWait);
            _spriteHit.color = _colorDefault;

            yield return new WaitForSeconds(_secondToWait);

            _spriteHit.color = _colorHit;
            yield return new WaitForSeconds(_secondToWait);
            _spriteHit.color = _colorDefault;
        }

        private void OnDestroy()
        {
            _healthController.OnSubstractHealth -= MakeAnimator;
        }
    }
}