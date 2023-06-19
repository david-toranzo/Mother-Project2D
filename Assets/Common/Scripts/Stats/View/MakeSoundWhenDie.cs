using UnityEngine;

namespace Common
{
    public class MakeSoundWhenDie : MonoBehaviour
    {
        [SerializeField] private HealthController _healthController;
        [SerializeField] private AudioSource _audioSource;

        private void Start()
        {
            _healthController.OnDie += MakeSound;
        }

        private void MakeSound()
        {
            _audioSource.Play();
        }

        private void OnDestroy()
        {
            _healthController.OnDie -= MakeSound;
        }
    }
}