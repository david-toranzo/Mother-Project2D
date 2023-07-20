using UnityEngine;

namespace Runtime.Character2D
{
    public interface IForceMoving
    {
        void SetForceWithDirection(float percent, Vector2 direction);
    }
}