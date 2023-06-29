using UnityEngine;

namespace Runtime.AICommand
{
    public class ChangeStateActiveObjectAICommand : BaseAICommand
    {
        [SerializeField] private GameObject _objectToChangeState;
        [SerializeField] private bool _newState = false;

        protected override StateNode ProcessWorkCommand()
        {
            _objectToChangeState.SetActive(_newState);
            return StateNode.Success;
        }
    }
}
