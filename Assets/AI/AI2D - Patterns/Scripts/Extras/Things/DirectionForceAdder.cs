using UnityEngine;

namespace Runtime.AICommand
{
    //DELETE this script
    public class DirectionForceAdder : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private int _force = 50;
        [SerializeField] private GameObject _objectToSpawn;

        public void SetDirectionToAddForce(Vector2 direction)
        {
            _rigidbody2D.AddForce(-direction * _force);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Instantiate(_objectToSpawn, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
