using UnityEngine;

namespace Runtime.InputSystem
{
    public class ControlInputVector2 : ControlInputBase
    {
        public Vector2 GetActualValueVector2Input()
        {
            if (CurrentInputAction != null)
                return CurrentInputAction.ReadValue<Vector2>();

            return Vector2.zero;
        }
    }
}
