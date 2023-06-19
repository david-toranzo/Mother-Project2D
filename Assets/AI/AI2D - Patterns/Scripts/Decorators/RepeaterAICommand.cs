using Patterns.Command;

namespace Runtime.AICommand
{
    public class RepeaterAICommand : DecoratorAICommand, ICommandDoneTask
    {
        private bool _objectDestroyed = false;

        public override void InitialConfiguration(ICommandDoneTask commandDone)
        {
            _decoratorCommand.SetCommandManager(this);
        }

        public void DoneExecutionCommand()
        {
            if (!_objectDestroyed)
                Execute();
        }

        public override void Execute()
        {
            _decoratorCommand.Execute();
        }

        private void OnDestroy()
        {
            _objectDestroyed = true;
        }
    }
}