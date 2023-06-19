﻿using Runtime.AICommand;
using UnityEngine;

namespace Runtime.AICommand
{
    public class FaceToTargetAICommand : BaseAICommand
    {
        [Header("References")]
        [SerializeField] private BossDataController _bossDataController;

        private Transform _objectRotate;
        private Transform _target;

        private bool _isRightRotation = false;

        private void Start()
        {
            _objectRotate = _bossDataController.EnemyGameObject.transform;
            _target = _bossDataController.Target.transform;
        }

        public override void Execute()
        {
            if (_objectRotate.position.x > _target.position.x && _isRightRotation)
                RotateObject(-180, false);
            else if (_objectRotate.position.x < _target.position.x && !_isRightRotation)
                RotateObject(180, true);

            NotifyDoneExecution();
        }

        private void RotateObject(int rotateAngle, bool newStateRight)
        {
            _objectRotate.Rotate(0, rotateAngle, 0);
            _isRightRotation = newStateRight;
        }
    }
}
