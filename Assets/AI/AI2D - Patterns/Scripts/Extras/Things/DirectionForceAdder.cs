using UnityEngine;

namespace Runtime.AICommand
{
    public class DirectionForceAdder : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private int _force = 50;

        public void SetDirectionToAddForce(Vector2 direction)
        {
            _rigidbody2D.AddForce(-direction * _force);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Destroy(this.gameObject);
        }
    }
}
