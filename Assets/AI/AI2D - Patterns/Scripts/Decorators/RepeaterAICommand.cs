
namespace Runtime.AICommand
{
    public class RepeaterAICommand : DecoratorAICommand
    {
        private bool _deactiveCommand = false;

        protected override StateNode ProcessWorkCommand()
        {
            if (_deactiveCommand)
                return StateNode.Success;

            var lastState = _decoratorCommand.ProcessUpdate();
            if (lastState == StateNode.Success)
                _decoratorCommand.ResetNodeWithExit();

            return StateNode.Running;
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