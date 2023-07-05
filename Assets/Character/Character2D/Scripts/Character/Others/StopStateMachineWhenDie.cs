using Common;
using Patterns.StateMachine;
using UnityEngine;

namespace Runtime.Character2D
{
    public class StopStateMachineWhenDie : MonoBehaviour
    {
        [SerializeField] private HealthController _healthController;
        [SerializeField] private ControlStateMachine _controlStateMachine;

        private void Start()
        {
            _healthController.OnDie += MakeActionEvent;
        }

        private void MakeActionEvent()
        {
            _controlStateMachine.StopAllCoroutines();
        }

        private void OnDestroy()
        {
            _healthController.OnDie -= MakeActionEvent;
        }
    }
}