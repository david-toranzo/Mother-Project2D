using UnityEngine;

namespace Common
{
    public class MakeSoundWhenHit : MonoBehaviour
    {
        [SerializeField] private HealthController _healthController;
        [SerializeField] private AudioSource _audioSource;

        private void Start()
        {
            _healthController.OnSubstractHealth += MakeSound;
        }

        private void MakeSound(int value)
        {
            _audioSource.Play();
        }

        private void OnDestroy()
        {
            _healthController.OnSubstractHealth -= MakeSound;
        }
    }
}