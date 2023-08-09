using UnityEngine;

namespace Runtime.Character2D
{
    public class ForceMovingEnemyMaker : MonoBehaviour, IForceMoving
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private int _force = 2;
        [SerializeField] private bool _applyForcePercent = true;

        private int _forceToApply = 10;

        public void SetForceWithDirection(float percent, Vector2 direction)
        {
            float percentForce = _applyForcePercent ? percent : 1;

            if (percentForce < 0)
                percentForce = 0;

            _rigidbody.AddForce((_forceToApply * _force * percentForce) * direction);
        }
    }
}