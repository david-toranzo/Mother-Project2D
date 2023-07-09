using UnityEngine;

namespace Common
{
    public class ObjectDieDeactivator : MonoBehaviour
    {
        [SerializeField] private GameObject _gameObjectToDeactive;
        [SerializeField] private HealthController _healthController;
        [SerializeField] private bool _newState;

        private void Start()
        {
            _healthController.OnDie += DeactiveCollider;
        }

        private void DeactiveCollider()
        {
            _gameObjectToDeactive.SetActive(_newState);
        }
    }
}