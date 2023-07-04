using UnityEngine;

namespace BasicEnemy.Enemy
{
    public abstract class Movement : MonoBehaviour
    {
        public enum LookDirection
        {
            Right, Left
        }

        [Header("MoveDistance")]
        [SerializeField] private Transform _limitLeftToMove;
        [SerializeField] private Transform _limitRightToMove;

        [Header("Move variables")]
        [SerializeField] private Transform target;
        [SerializeField] private float _speed = 2f;

        protected string stringAnimatorForwardSpeed = "forwardSpeed";
        protected Animator animator;
        protected float _lastMoveDistance = 0;

        private LookDirection _lookPlayerDirection = LookDirection.Right;

        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
        }

        public void StartMoveAction(Vector2 destination, float speedFraction)
        {
           /* if (!CanMoveTo(destination))
                return;*/

            MoveTo(destination, speedFraction);
        }

        public bool CanMoveTo(Vector2 destination)
        {
            _lastMoveDistance = 0;

            if (!IsInsideLimits(destination))
                return false;

            return true;
        }

        private bool IsInsideLimits(Vector2 destination)
        {
            return _limitLeftToMove.position.x < destination.x && destination.x < _limitRightToMove.position.x;
        }

        private void MoveTo(Vector2 destination, float SpeedFraction)
        {
            destination.y = transform.position.y;

            _lastMoveDistance = SpeedFraction * Time.deltaTime * _speed;
            transform.position = Vector2.MoveTowards(transform.position, destination, _lastMoveDistance);

            HandleRotation(destination);
        }

        private void HandleRotation(Vector2 positionToLookAt)
        {
            if (_lookPlayerDirection == LookDirection.Right && (positionToLookAt.x < transform.position.x))
            {
                transform.Rotate(0, 180, 0);
                _lookPlayerDirection = LookDirection.Left;
            }
            else if (_lookPlayerDirection == LookDirection.Left && (positionToLookAt.x > transform.position.x))
            {
                transform.Rotate(0, -180, 0);
                _lookPlayerDirection = LookDirection.Right;
            }
        }

        public void Cancel() {

        }
    }
}
