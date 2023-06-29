using System;
using UnityEngine;

namespace Common
{
    public class CollisionDetectorKiller : MonoBehaviour, ICollisionDetectorKiller
    {
        public Action OnKillerCollision { get; set; }

        [SerializeField] private string _tagToCollision;


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag != _tagToCollision)
                return;

            IHealth health = other.gameObject.GetComponent<IHealth>();
            health.ReceiveAttack(health.CurrentLife);
            OnKillerCollision.Invoke();
        }
    }
}
