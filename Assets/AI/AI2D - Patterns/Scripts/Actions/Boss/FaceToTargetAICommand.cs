using UnityEngine;

namespace Runtime.AICommand
{
    public class FaceToTargetAICommand : BaseAICommand
    {
        [Header("References")]
        [SerializeField] private BossDataController _bossDataController;

        private Transform _objectRotate;
        private Transform _target;

        private void Start()
        {
            _objectRotate = _bossDataController.EnemyGameObject.transform;
            _target = _bossDataController.Target.transform;
        }

        protected override StateNode ProcessWorkCommand()
        {
            if (_target is null)
            {
                _target = _bossDataController.Target.transform;
            }

            if (_objectRotate.position.x > _target.position.x && _bossDataController.IsRightRotation)
                RotateObject(-180, false);
            else if (_objectRotate.position.x < _target.position.x && !_bossDataController.IsRightRotation)
                RotateObject(180, true);
            
            return StateNode.Success;
        }

        private void RotateObject(int rotateAngle, bool newStateRight)
        {
            _objectRotate.Rotate(0, rotateAngle, 0);
            _bossDataController.IsRightRotation = newStateRight;
        }
    }
}
