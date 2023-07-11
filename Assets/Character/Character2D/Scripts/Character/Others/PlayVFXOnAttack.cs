using Runtime.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Character2D
{
    public class PlayVFXOnAttack : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particlesAttack;

        private IAttackEvent _attackEventSubscribe;
        private bool _hasPlayedParticles;

        private void Start()
        {
            _attackEventSubscribe = GetComponent<IAttackEvent>();
            _attackEventSubscribe.OnAttack += MakeAttackAnimator;
        }

        private void MakeAttackAnimator()
        {
            if (!_hasPlayedParticles)
            {
                PlayParticlesOnAttack();
                _hasPlayedParticles = true;

                StartCoroutine(ResetHasPlayedParticlesAfterDelay(1));
            }
        }

        private void PlayParticlesOnAttack()
        {
            _particlesAttack.Play();
        }

        private IEnumerator ResetHasPlayedParticlesAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            _hasPlayedParticles = false;
        }

        private void OnDestroy()
        {
            _attackEventSubscribe.OnAttack -= MakeAttackAnimator;
        }
    }
}
