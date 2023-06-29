using UnityEngine;
using TMPro;

namespace Runtime.Common
{
    public class ShowFrames : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private TextMeshProUGUI _textMeshProFrames;
        [SerializeField] private TextMeshProUGUI _textMeshProTimeDeltaTime;
        [SerializeField] private int _newFrameRate = 60;

        private void Start()
        {
            Application.targetFrameRate = _newFrameRate;
        }

        private void Update()
        {
            _textMeshProFrames.text = (1/Time.deltaTime).ToString();
            _textMeshProTimeDeltaTime.text = (Time.deltaTime).ToString();
        }
    }
}
