using Runtime.Common;
using UnityEngine;
using ScriptableObjects.Event;

namespace Runtime.Character2D
{
    public class AttackAudioEventCaller : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] private EmptyEventScriptableObject _eventScriptableObject;

        private IAttackEvent _attackEventSubscribe;
 
        private void Start()
        {
            _attackEventSubscribe = GetComponent<IAttackEvent>();
            _attackEventSubscribe.OnAttack += MakeAttackAnimator;
        }

        private void MakeAttackAnimator()
        {
            _eventScriptableObject.InvokeEvent();
        }

        private void OnDestroy()
        {
            _attackEventSubscribe.OnAttack -= MakeAttackAnimator;
        }
    }
}