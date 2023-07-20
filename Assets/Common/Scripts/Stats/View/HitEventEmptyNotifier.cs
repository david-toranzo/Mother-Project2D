using ScriptableObjects.Event;
using UnityEngine;

namespace Common
{
    public class HitEventEmptyNotifier : MonoBehaviour
    {
        [SerializeField] private HealthController _healthController;

        [Header("Data")]
        [SerializeField] private EmptyEventScriptableObject _eventScriptableObject;

        private void Start()
        {
            _healthController.OnSubstractHealth += EventNotify;
        }

        private void EventNotify(int value)
        {
            _eventScriptableObject.InvokeEvent();
        }

        private void OnDestroy()
        {
            _healthController.OnSubstractHealth -= EventNotify;
        }
    }
}