using UnityEngine;

namespace Common
{
    public class RigidbodyDieDeactivator : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private HealthController _healthController;

        private void Start()
        {
            _healthController.OnDie += DeactiveCollider;
        }

        private void DeactiveCollider()
        {
            _rigidbody2D.velocity = Vector3.zero;
            _rigidbody2D.isKinematic = true;
        }
    }
}