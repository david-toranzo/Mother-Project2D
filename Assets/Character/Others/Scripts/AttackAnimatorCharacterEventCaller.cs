using Runtime.Common;
using System.Collections;
using UnityEngine;

namespace Runtime.Character2D
{
    public class AttackAnimatorCharacterEventCaller : MonoBehaviour
    {
        [SerializeField] private CharacterFighter _characterFighter;
        [SerializeField] private float _timeDoAttackEvent = 0.6f;

        private IAttackEvent _attackEventSubscribe;

        private void Start()
        {
            _attackEventSubscribe = GetComponent<IAttackEvent>();
            _attackEventSubscribe.OnAttack += MakeAttackAnimator;
        }

        private void MakeAttackAnimator()
        {
            StartCoroutine(DoAttackAfterTime());
        }

        private IEnumerator DoAttackAfterTime()
        {
            yield return new WaitForSeconds(_timeDoAttackEvent);

            _characterFighter.MakeAttack();
        }

        private void OnDestroy()
        {
            _attackEventSubscribe.OnAttack -= MakeAttackAnimator;
        }
    }
}
