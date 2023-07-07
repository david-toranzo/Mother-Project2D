using Runtime.Common;
using UnityEngine;

namespace Runtime.Character2D
{
    public class AttackAudioEventCaller : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;

        private IAttackEvent _attackEventSubscribe;

        private void Start()
        {
            _attackEventSubscribe = GetComponent<IAttackEvent>();
            _attackEventSubscribe.OnAttack += MakeAttackAnimator;
        }

        private void MakeAttackAnimator()
        {
            _audioSource.PlayOneShot(_audioClip);
        }

        private void OnDestroy()
        {
            _attackEventSubscribe.OnAttack -= MakeAttackAnimator;
        }
    }
}
