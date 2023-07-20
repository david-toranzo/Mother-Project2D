using UnityEngine;

namespace Runtime.Character2D
{
    public class ForceMovingEnemyMaker : MonoBehaviour, IForceMoving
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private int _force = 2;

        private int _forceToApply = 10;

        public void SetForceWithDirection(float percent, Vector2 direction)
        {
            _rigidbody.AddForce((_forceToApply * _force * percent) * direction);
        }
    }
}