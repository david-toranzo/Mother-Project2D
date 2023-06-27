using Patterns.Command;
using System;

namespace Runtime.AICommand
{
    public class RepeaterAICommand : DecoratorAICommand, ICommandDoneTask
    {
        private bool _deactiveCommand = false;

        public override void InitialConfiguration(ICommandDoneTask commandDone)
        {
            _decoratorCommand.SetCommandManager(this);
        }

        public void DoneExecutionCommand()
        {
            if (!_deactiveCommand)
                Execute();
        }

        public override void Execute()
        {
            _decoratorCommand.Execute();
        }

        private void OnDestroy()
        {
            _deactiveCommand = true;
        }

        public void StopExecuteCommand()
        {
            _deactiveCommand = true;
        }
    }
}