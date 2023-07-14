using System.Collections;
using UnityEngine;

namespace Common
{
    public abstract class AnimationColorWhenHitBase : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] private Color _colorDefault = Color.white;
        [SerializeField] private Color _colorHit = Color.red;
        [SerializeField] private float _secondToWait = 0.05f;
        [SerializeField] private int _cyclesChangeColor = 3;

        [Header("References")]
        [SerializeField] private HealthController _healthController;

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
                SetColorAnimation(_colorHit);
                yield return new WaitForSeconds(_secondToWait);
                SetColorAnimation(_colorDefault);
                yield return new WaitForSeconds(_secondToWait);

                _countCycleAnim++;
            }
        }

        protected abstract void SetColorAnimation(Color colorToSet);

        private void OnDestroy()
        {
            _healthController.OnSubstractHealth -= MakeAnimator;
        }
    }
}