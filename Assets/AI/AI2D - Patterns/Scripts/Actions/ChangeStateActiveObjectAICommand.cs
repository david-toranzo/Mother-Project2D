using UnityEngine;

namespace Runtime.AICommand
{
    public class ChangeStateActiveObjectAICommand : BaseAICommand
    {
        [SerializeField] private GameObject _objectToChangeState;
        [SerializeField] private bool _newState = false;

        public override void Execute()
        {
            _objectToChangeState.SetActive(_newState);
            NotifyDoneExecution();
        }
    }
}
