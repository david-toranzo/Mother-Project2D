using UnityEngine;

namespace Runtime.Common
{
    public class ControlCursor : MonoBehaviour
    {
#if !UNITY_IOS || !UNITY_ANDROID
        [Header("Mouse Cursor Settings")]
        [SerializeField] bool cursorLocked = true;
#endif

        private void Awake()
        {
            SetCursorState(cursorLocked);
        }

        private void Start()
        {
            Application.targetFrameRate = 80;
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            SetCursorState(cursorLocked);
        }

        public void SetCursorState(bool newState)
        {
            Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
        }
    }
}
