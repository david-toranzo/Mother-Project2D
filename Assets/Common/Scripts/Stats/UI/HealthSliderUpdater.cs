using UnityEngine;
using UnityEngine.UI;

namespace Common
{
    public class HealthSliderUpdater : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private HealthController _healthController;

        [Header("View")]
        [SerializeField] private Slider _sliderHealth;
        [SerializeField] private bool _activeAwakeSlider;

        private void Start()
        {
            UpdateStartValueLife();
            SubscribeMethods();
        }

        private void UpdateStartValueLife()
        {
            int startLife = _healthController.CurrentLife;

            if (_sliderHealth != null)
            {
                _sliderHealth.maxValue = startLife;
                _sliderHealth.value = startLife;

                if (!_activeAwakeSlider)
                    _sliderHealth.gameObject.SetActive(false);
            }
        }

        private void SubscribeMethods()
        {
            _healthController.OnSubstractHealth += SubtractHealthUpdateSlider;
            _healthController.OnDie += DesactiveSlider;
        }

        private void SubtractHealthUpdateSlider(int newHealth)
        {
            if (_sliderHealth != null)
            {
                _sliderHealth.gameObject.SetActive(true);
                _sliderHealth.value = newHealth;
            }
        }

        private void DesactiveSlider()
        {
            if (_sliderHealth != null)
                _sliderHealth.gameObject.SetActive(false);
        }
    }
}