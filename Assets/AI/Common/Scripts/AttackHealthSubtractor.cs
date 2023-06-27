using Common;
using UnityEngine;

namespace Runtime.EnemyCommon
{
    public class AttackHealthSubtractor : MonoBehaviour
    {
        [SerializeField] protected float _shoutDistanceTakeDamage = 0.8f;
        [SerializeField] protected Transform _positionToAttack;
        [SerializeField] protected int _damage = 1;

        private GameObject _lastTarget;

        public void MakeAttack()
        {
            Debug.Log("MakeAttack");
            if (Vector3.Distance(_positionToAttack.transform.position, _lastTarget.transform.position)
                < _shoutDistanceTakeDamage)
            {
                Debug.Log("MakeAttack take damage");

                IHealth targetToTest = _lastTarget.GetComponent<IHealth>();
                targetToTest.ReceiveAttack(_damage);
            }
        }
    }
}
