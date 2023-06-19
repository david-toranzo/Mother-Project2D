using Runtime.Character2D;
using UnityEngine;

namespace Runtime.AICommand
{
    public class ChangeStatePlayerAICommand : BaseAICommand
    {
        [SerializeField] private CharacterMediator _objectToChangeState;
        [SerializeField] private bool _newState = false;

        public override void Execute()
        {
            _objectToChangeState.enabled = _newState;
            NotifyDoneExecution();
        }
    }
}
