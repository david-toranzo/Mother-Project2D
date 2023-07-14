using Common;
using UnityEngine;

namespace Runtime.Character2D
{
    public class StopAllForcesCharacterWhenDie : MonoBehaviour
    {
        [SerializeField] private HealthController _healthController;
        [SerializeField] private CharacterUnity2D _characterUnity2D;

        private void Start()
        {
            _healthController.OnDie += MakeActionEvent;
        }

        private void MakeActionEvent()
        {
            _characterUnity2D.ResetVelocityMove();
        }

        private void OnDestroy()
        {
            _healthController.OnDie -= MakeActionEvent;
        }
    }
}