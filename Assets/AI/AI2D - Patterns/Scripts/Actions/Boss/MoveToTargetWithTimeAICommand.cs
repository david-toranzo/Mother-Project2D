using UnityEngine;

namespace Runtime.AICommand
{
    public class MoveToTargetWithTimeAICommand : BaseAICommand
    {
        [Header("Time")]
        [SerializeField] private float _maxTimeToWalk = 3f;
        [SerializeField] private float _minTimeToWalk = 1f;
        [SerializeField] private float _speed = 3f;

        [Header("References")]
        [SerializeField] private BossDataController _bossDataController;

        private Rigidbody2D _objectMoveRb;
        private Transform _target;

        private Vector2 _directionMove;

        private float _timeToWait = 2f;
        private float _currentTime = 0;

        private const float _distanceToMove = 0.8f;

        private void Start()
        {
            _objectMoveRb = _bossDataController.EnemyGameObject.GetComponent<Rigidbody2D>();
            _target = _bossDataController.Target.transform;
        }

        protected override void EnterNode()
        {
            _timeToWait = Random.Range(_minTimeToWalk, _maxTimeToWalk);
            _currentTime = 0;

            Vector3 _targetPosition = _target.position;
            _directionMove = -(_objectMoveRb.transform.position - _targetPosition);
            _directionMove.y = 0;
        }

        protected override StateNode ProcessWorkCommand()
        {
            _currentTime += Time.deltaTime;

            MoveToPosition();

            if (_currentTime > _timeToWait)
                return StateNode.Success;

            return StateNode.Running;
        }

        private void MoveToPosition()
        {
            Vector2 movePositionFrame = _directionMove.normalized * (Time.deltaTime * _speed);
            _objectMoveRb.MovePosition((Vector2)_objectMoveRb.transform.position + movePositionFrame);
        }
    }
}
