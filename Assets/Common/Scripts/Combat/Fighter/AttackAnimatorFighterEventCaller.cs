using System;
using System.Collections;
using UnityEngine;

namespace Runtime.Common
{
    public class AttackAnimatorFighterEventCaller : MonoBehaviour
    {
        [SerializeField] private Fighter _fighter;
        [SerializeField] private float _timeDoAttackEvent = 0.6f;

        private IAttackEvent _attackEventSubscribe;

        private void Start()
        {
            _attackEventSubscribe = GetComponent<IAttackEvent>();
            _attackEventSubscribe.OnAttack += MakeAttackAnimator;
            _attackEventSubscribe.OnCancelAttack += CancelAttackAnimator;
        }

        private void CancelAttackAnimator()
        {
            StopAllCoroutines();
        }

        private void MakeAttackAnimator()
        {
            StartCoroutine(DoAttackAfterTime());
        }

        private IEnumerator DoAttackAfterTime()
        {
            yield return new WaitForSeconds(_timeDoAttackEvent);

            _fighter.MakeAttack();
        }

        private void OnDestroy()
        {
            _attackEventSubscribe.OnAttack -= MakeAttackAnimator;
        }
    }
}
