using Common;
using UnityEngine;

namespace Runtime.AICommand
{
    public class AICommandDeactivatorWhenDie : MonoBehaviour
    {
        [SerializeField] private HealthController _healthController;
        [SerializeField] private RepeaterAICommand _mainRepeater;

        private void Start()
        {
            _healthController.OnDie += DeactiveCommand;
        }

        private void DeactiveCommand()
        {
            _mainRepeater.StopExecuteCommand();
        }

        private void OnDestroy()
        {
            _healthController.OnDie -= DeactiveCommand;
        }
    }
}
