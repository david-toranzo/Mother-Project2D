using Common;
using UnityEngine;

namespace Runtime.AICommand
{
    public class BossDataController : MonoBehaviour
    {
        [SerializeField] private GameObject _enemyController;
        [SerializeField] private GameObject _target;

        private bool _isRightRotation = false;

        public GameObject EnemyGameObject { get => _enemyController; set => _enemyController = value; }
        public GameObject Target { get => _target; set => _target = value; }
        public bool IsRightRotation { get => _isRightRotation; set => _isRightRotation = value; }

        private void Awake()
        {
            if (_target == null)
                _target = FindObjectOfType<HealthPlayerController>().gameObject;
        }

        public Vector2 GetDirectionToTarget()
        { 
            return _enemyController.transform.position - _target.transform.position;
        }
    }
}