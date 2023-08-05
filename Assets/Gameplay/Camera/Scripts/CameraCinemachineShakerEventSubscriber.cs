using ScriptableObjects.Event;
using UnityEngine;

namespace Runtime.Camera
{
    public class CameraCinemachineShakerEventSubscriber : MonoBehaviour
    {
        [SerializeField] private EmptyEventScriptableObject[] _eventsScriptableObjectSubscriber;
        [SerializeField] private EmptyEventScriptableObject _eventShakeScriptableObject;

        private void Awake()
        {
            for (int i = 0; i < _eventsScriptableObjectSubscriber.Length; i++)
            {
                _eventsScriptableObjectSubscriber[i].OnEvent += MakeShakeEvent;
            }
        }

        private void MakeShakeEvent()
        {
            _eventShakeScriptableObject.InvokeEvent();
        }

        private void OnDestroy()
        {
            for (int i = 0; i < _eventsScriptableObjectSubscriber.Length; i++)
            {
                _eventsScriptableObjectSubscriber[i].OnEvent -= MakeShakeEvent;
            }
        }
    }
}