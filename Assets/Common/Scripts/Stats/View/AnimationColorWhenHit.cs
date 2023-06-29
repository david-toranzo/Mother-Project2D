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
        [SerializeField] private Color _colorDefault = Color.white;
        [SerializeField] private Color _colorHit = Color.red;
        [SerializeField] private float _secondToWait = 0.05f;
        [SerializeField] private int _cyclesChangeColor = 3;

        private int _countCycleAnim = 0;

        private void Start()
        {
            _healthController.OnSubstractHealth += MakeAnimator;
        }

        private void MakeAnimator(int value)
        {
            _countCycleAnim = 0;
            StartCoroutine(MakeAnimationChangeColor());
        }

        private IEnumerator MakeAnimationChangeColor()
        {
            while (_countCycleAnim < _cyclesChangeColor)
            {
                _spriteHit.color = _colorHit;
                yield return new WaitForSeconds(_secondToWait);
                _spriteHit.color = _colorDefault;
                yield return new WaitForSeconds(_secondToWait);

                _countCycleAnim++;
            }
        }

        private void OnDestroy()
        {
            _healthController.OnSubstractHealth -= MakeAnimator;
        }
    }
}