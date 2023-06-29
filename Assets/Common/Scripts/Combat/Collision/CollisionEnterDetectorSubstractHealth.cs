using UnityEngine;

namespace Common
{
    public class CollisionEnterDetectorSubstractHealth : MonoBehaviour
    {
        [SerializeField] private string _tagToCollision = "Player";
        [SerializeField] private int _healthToSubstract = 1;


        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag != _tagToCollision)
                return;

            IHealth health = other.gameObject.GetComponent<IHealth>();
            health.ReceiveAttack(_healthToSubstract);
        }
    }
}
