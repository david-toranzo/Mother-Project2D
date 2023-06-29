using Runtime.Character2D;
using UnityEngine;

namespace Runtime.AICommand
{
    public class ChangeStatePlayerAICommand : BaseAICommand
    {
        [SerializeField] private CharacterMediator _objectToChangeState;
        [SerializeField] private bool _newState = false;

        protected override StateNode ProcessWorkCommand()
        {
            _objectToChangeState.ChangeStateCharacterActive(_newState);
            return StateNode.Success;
        }
    }
}
