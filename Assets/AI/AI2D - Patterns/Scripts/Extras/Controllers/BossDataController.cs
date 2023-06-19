using UnityEngine;

namespace Runtime.AICommand
{
    public class BossDataController : MonoBehaviour
    {
        [SerializeField] private GameObject _enemyController;
        [SerializeField] private GameObject _target;

        public GameObject EnemyGameObject { get => _enemyController; set => _enemyController = value; }
        public GameObject Target { get => _target; set => _target = value; }

        public Vector2 GetDirectionToTarget()
        { 
            return _enemyController.transform.position - _target.transform.position;
        }
    }
}