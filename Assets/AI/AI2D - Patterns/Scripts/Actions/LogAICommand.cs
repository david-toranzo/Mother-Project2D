using UnityEngine;

namespace Runtime.AICommand
{
    public class LogAICommand : BaseAICommand
    {
        [SerializeField] private string _messageToLog = "This is a simple log for the ai command";

        public override void Execute()
        {
            Debug.Log(_messageToLog);
            NotifyDoneExecution();
        }
    }
}
