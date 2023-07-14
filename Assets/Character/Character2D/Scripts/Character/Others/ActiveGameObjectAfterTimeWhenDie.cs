using Common;
using ScriptableObjects.Event;
using System.Collections;
using UnityEngine;

namespace Runtime.Character2D
{
    public class ActiveGameObjectAfterTimeWhenDie : MonoBehaviour
    {
        [SerializeField] private HealthController _healthController;
        [SerializeField] private EmptyEventScriptableObject _eventScriptableObject;
        [SerializeField] private float _time = 0.6f;

        private void Start()
        {
            _healthController.OnDie += MakeActionEvent;
        }

        private void MakeActionEvent()
        {
            StartCoroutine(DeadHealthController());
        }

        private IEnumerator DeadHealthController()
        {
            yield return new WaitForSeconds(_time);

            _eventScriptableObject.InvokeEvent();
        }

        private void OnDestroy()
        {
            _healthController.OnDie -= MakeActionEvent;
        }
    }
}