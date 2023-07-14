using UnityEngine;

namespace Runtime.Common
{
    public class FrameRateSetter : MonoBehaviour
    {
        [SerializeField] private int _frame = 30;

        private void Start()
        {
            Application.targetFrameRate = _frame;
        }
    }
}
