using UnityEngine;

namespace Runtime.AICommand
{
    public class LogAICommand : BaseAICommand
    {
        [SerializeField] private string _messageToLog = "This is a simple log for the ai command";

        protected override StateNode ProcessWorkCommand()
        {
            Debug.Log(_messageToLog);
            return StateNode.Success;
        }
    }
}
