using Patterns.Command;

namespace Runtime.AICommand
{
    public class SequencerAICommand : CompositeAICommand
    {
        private int _commandIndex = 0;

        public override void DoneExecutionCommand()
        {
            _commandIndex++;

            if (_commandIndex < _decoratorsCommand.Length)
                _decoratorsCommand[_commandIndex].Execute();
            else
                FinishSequenceCommand();
        }

        private void FinishSequenceCommand()
        {
            _commandIndex = 0;
            NotifyDoneExecution();
        }

        public override void Execute()
        {
            _decoratorsCommand[_commandIndex].Execute();
        }
    }
}