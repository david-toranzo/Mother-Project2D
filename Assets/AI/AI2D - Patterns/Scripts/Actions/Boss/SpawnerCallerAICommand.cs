using UnityEngine;

namespace Runtime.AICommand
{
    public class SpawnerCallerAICommand : BaseAICommand
    {
        [Header("References")]
        [SerializeField] private ObjectSpawnerByAmount _objectSpawnerByAmount;

        protected override StateNode ProcessWorkCommand()
        {
            _objectSpawnerByAmount.SpawnObjects();
            return StateNode.Success;
        }
    }
}
