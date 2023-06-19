using Patterns.Command;
using Runtime.AICommand;
using UnityEngine;

namespace Runtime.AICommand
{
    public class DecisionAICommand : DecoratorAICommand, ICommandDoneTask
    {
        [SerializeField] private BaseAICommand _decoratorCommandFalseCondition;

        [Header("References")]
        [SerializeField] private DecisionBase _verificatorDecision;

        public override void InitialConfiguration(ICommandDoneTask commandDone)
        {
            _decoratorCommand.SetCommandManager(this);
            _decoratorCommandFalseCondition.SetCommandManager(this);
        }

        public void DoneExecutionCommand()
        {
            NotifyDoneExecution();
        }

        public override void Execute()
        {
            if(_verificatorDecision.GetResolutionOfDecision())
                _decoratorCommand.Execute();
            else
                _decoratorCommandFalseCondition.Execute();
        }
    }
}