using Common;
using UnityEngine;

namespace Runtime.Character2D
{
    public class SphereAreaAttacker : MonoBehaviour
    {
        [SerializeField] private CharacterFighter _characterFighter;

        [Header("Data")]
        [SerializeField] private Transform _positionToAttack;
        [SerializeField] private float _distanceAttack = 0.5f;
        [SerializeField] private int _damage = 1;
        [SerializeField] private string _tagNameToAttack;

        private IHealth _currentHealth;

        protected void Start()
        {
            _currentHealth = GetComponentInParent<IHealth>();

            _characterFighter.OnAttackFighter += MakeAttack;
        }

        public void MakeAttack()
        {
            RaycastHit2D[] hits = Physics2D.CircleCastAll(_positionToAttack.position, _distanceAttack, transform.forward, 0);

            foreach (RaycastHit2D hit in hits)
            {
                IAttackReceiver health = hit.collider.GetComponent<IAttackReceiver>();
                if (health != null && health != _currentHealth && hit.collider.tag == _tagNameToAttack)
                    health.ReceiveAttack(_damage);
            }
        }
    }
}