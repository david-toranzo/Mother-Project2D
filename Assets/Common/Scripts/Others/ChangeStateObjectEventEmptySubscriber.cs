using ScriptableObjects.Event;
using UnityEngine;

namespace Runtime.Common
{
    public class ChangeStateObjectEventEmptySubscriber : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] private EmptyEventScriptableObject _eventScriptableObject;

        [Header("References")]
        [SerializeField] private GameObject _objectToChangeStateActive;
        [SerializeField] private bool _newState;


        private void Start()
        {
            _eventScriptableObject.OnEvent += MakeActionEvent;
        }

        private void MakeActionEvent()
        {
            _objectToChangeStateActive.SetActive(_newState);
        }

        private void OnDestroy()
        {
            _eventScriptableObject.OnEvent -= MakeActionEvent;
        }
    }
}
