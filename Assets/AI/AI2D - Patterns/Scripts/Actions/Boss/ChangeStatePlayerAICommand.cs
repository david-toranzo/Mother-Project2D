using ScriptableObjects.Event;
using UnityEngine;

namespace Runtime.AICommand
{
    public class ChangeStatePlayerAICommand : BaseAICommand
    {
        [SerializeField] private BoolEventScriptableObject _boolEventScriptableObject;
        [SerializeField] private bool _newState = false;

        protected override StateNode ProcessWorkCommand()
        {
            _boolEventScriptableObject.InvokeEventType(_newState);
            return StateNode.Success;
        }
    }
}
