using UnityEngine;

namespace Common
{
    public class ColliderDieDeactivator : MonoBehaviour
    {
        [SerializeField] private Collider2D _collider2D;
        [SerializeField] private HealthController _healthController;

        private void Start()
        {
            _healthController.OnDie += DeactiveCollider;
        }

        private void DeactiveCollider()
        {
            _collider2D.enabled = false;
        }
    }
}