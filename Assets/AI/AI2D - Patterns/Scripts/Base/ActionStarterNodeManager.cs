using UnityEngine;

namespace Runtime.AICommand
{
    public class ActionStarterNodeManager : MonoBehaviour
    {
        [SerializeField] private ActionNodeManager _commandManager;

        private void Start()
        {
            _commandManager.StartMakeCommandAction();
        }
    }
}
