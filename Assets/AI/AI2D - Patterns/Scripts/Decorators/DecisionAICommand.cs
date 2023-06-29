using UnityEngine;

namespace Runtime.AICommand
{
    public class DecisionAICommand : DecoratorAICommand
    {
        [SerializeField] private BaseAICommand _decoratorCommandFalseCondition;

        [Header("References")]
        [SerializeField] private DecisionBase _verificatorDecision;

        private BaseAICommand _commandToExecute;

        protected override void EnterNode()
        {
            if (_verificatorDecision.GetResolutionOfDecision())
                _commandToExecute = _decoratorCommand;
            else
                _commandToExecute = _decoratorCommandFalseCondition;
        }

        protected override StateNode ProcessWorkCommand()
        {
            return _commandToExecute.ProcessUpdate();
        }
    }
}