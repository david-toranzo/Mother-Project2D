using UnityEngine;

namespace Runtime.AICommand
{
    public class RandomExecuterAICommand : CompositeAICommand
    {
        public override void DoneExecutionCommand()
        {
            NotifyDoneExecution();
        }

        public override void Execute()
        {
            int index = Random.Range(0, _decoratorsCommand.Length);
            _decoratorsCommand[index].Execute();
        }
    }
}