using Common;
using UnityEngine;

namespace Runtime.Character2D
{
    public class AddForcesObjectsWhenDie : MonoBehaviour
    {
        [SerializeField] private HealthController _healthController;
        [SerializeField] private Rigidbody2D[] _rigidbodies2D;
        [SerializeField] private Vector2 _directionForce;
        [SerializeField] private float _forceToAplly = 2;

        private void Start()
        {
            _healthController.OnDie += MakeActionEvent;
        }

        private void MakeActionEvent()
        {
            for (int i = 0; i < _rigidbodies2D.Length; i++)
            {
                _rigidbodies2D[i].isKinematic = false;
                _rigidbodies2D[i].AddForce(_directionForce * _forceToAplly);
            }
        }

        private void OnDestroy()
        {
            _healthController.OnDie -= MakeActionEvent;
        }
    }
}