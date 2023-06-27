using UnityEngine;

namespace Runtime.AICommand
{
    public class SpawnerCallerAICommand : BaseAICommand
    {
        [Header("References")]
        [SerializeField] private ObjectSpawnerByAmount _objectSpawnerByAmount;

        public override void Execute()
        {
            _objectSpawnerByAmount.SpawnObjects();
            NotifyDoneExecution();
        }
    }
}
