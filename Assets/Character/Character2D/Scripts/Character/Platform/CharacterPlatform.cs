using UnityEngine;

namespace Runtime.Character2D
{
    public class CharacterPlatform : MonoBehaviour
    {
        [SerializeField] private CharacterUnity2D _characterUnity;

        private PlatformMovement _lastPlatformMovement;

        private void Update()
        {
            if (_lastPlatformMovement is null)
                return;

            _characterUnity.VelocityPlatform = _lastPlatformMovement.GetLastMovement();
        }

        public void SetPlatform(PlatformMovement platformMovement)
        {
            _lastPlatformMovement = platformMovement;
        }

        public void RemovePlatform()
        {
            _lastPlatformMovement = null;
            _characterUnity.VelocityPlatform = Vector3.zero;
        }
    }
}
