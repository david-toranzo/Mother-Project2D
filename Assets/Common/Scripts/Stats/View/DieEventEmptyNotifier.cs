using ScriptableObjects.Event;
using UnityEngine;

namespace Common
{
    public class DieEventEmptyNotifier : MonoBehaviour
    {
        [SerializeField] private HealthController _healthController;

        [Header("Data")]
        [SerializeField] private EmptyEventScriptableObject _eventScriptableObject;

        private void Start()
        {
            _healthController.OnDie += EventNotify;
        }

        private void EventNotify()
        {
            _eventScriptableObject.InvokeEvent();
        }

        private void OnDestroy()
        {
            _healthController.OnDie -= EventNotify;
        }
    }
}