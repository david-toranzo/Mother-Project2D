using UnityEngine;

namespace Runtime.AICommand
{
    public class SpawnObjectWithDirectionAICommand : BaseAICommand
    {
        [Header("Spawner")]
        [SerializeField] private Transform _positionToSpawn;
        [SerializeField] private GameObject _objectToSpawn;

        [Header("References")]
        [SerializeField] private BossDataController _bossDataController;

        protected override StateNode ProcessWorkCommand()
        {
            var rock = Instantiate(_objectToSpawn, _positionToSpawn.position, Quaternion.identity);

            Vector2 direction = _bossDataController.GetDirectionToTarget();
            rock.GetComponent<DirectionForceAdder>().SetDirectionToAddForce(direction);
            
            return StateNode.Success;
        }
    }
}
