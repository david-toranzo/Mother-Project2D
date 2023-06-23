using UnityEngine;
using UnityEngine.UI;

namespace Runtime.Common
{
    public class SliderUIChangeNotifier : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private Slider _sliderValue;

        //[Header("Data")]

        private void Start()
        {
            _sliderValue.onValueChanged.AddListener(delegate { ChangeValueSlider(); });
        }

        private void ChangeValueSlider()
        {

        }
    }
}
