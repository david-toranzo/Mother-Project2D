using ScriptableObjects.Data;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace Runtime.Common
{
    public class SliderUIChangeNotifier : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private Slider _sliderValue;
        [SerializeField] private TextMeshProUGUI _textMeshPro;

        [Header("UI data")]
        [SerializeField] private float _sliderMin = 1;
        [SerializeField] private float _sliderMax = 1;

        [Header("Data")]
        [SerializeField] private FloatDataEventScriptableObject _floatDataEventScriptableObject;
        
        private void Start()
        {
            _sliderValue.minValue = _sliderMin;
            _sliderValue.maxValue = _sliderMax;

            _textMeshPro.text = _sliderValue.value.ToString();

            _sliderValue.onValueChanged.AddListener(delegate { ChangeValueSlider(); });
        }

        private void ChangeValueSlider()
        {
            float valueSlider = (float)Math.Round((double)_sliderValue.value, 2);

            _floatDataEventScriptableObject.InvokeEventType(valueSlider);
            _textMeshPro.text = valueSlider.ToString();
        }
    }
}
