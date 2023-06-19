using System.Collections;
using UnityEngine;

namespace Common
{
    public class MakeAnimationDieDestroyer : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private HealthController _healthController;

        [Header("Die data")]
        [SerializeField] private bool _destroyObject = true;
        [SerializeField] private float _secondToDie = 0.5f;

        private void Start()
        {
            _healthController.OnDie += MakeAnimation;
        }

        private void MakeAnimation()
        {
            _animator.SetTrigger("die");

            if(_destroyObject)
                StartCoroutine(DestroyObject());
        }

        private IEnumerator DestroyObject()
        { 
            yield return new WaitForSeconds(_secondToDie);
            Destroy(_healthController.gameObject);
        }
    }
}