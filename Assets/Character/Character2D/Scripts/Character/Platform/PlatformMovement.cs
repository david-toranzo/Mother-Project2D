using UnityEngine;

namespace Runtime.Character2D
{
    public class PlatformMovement : MonoBehaviour
    {
        private Vector3 _lastMovement;
        private Vector3 _lastPosition;

        private void LateUpdate()
        {
        }

        public Vector3 GetLastMovement()
        { 
            return _lastMovement;
        }

        public void SetLastMovement(Vector3 lastMovement)
        {
            _lastMovement = lastMovement;
        }
    }
}
