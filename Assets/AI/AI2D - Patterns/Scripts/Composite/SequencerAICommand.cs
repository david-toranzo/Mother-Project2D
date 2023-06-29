using System;
using UnityEngine;

namespace Runtime.AICommand
{
    public class SequencerAICommand : CompositeAICommand
    {
        private int _commandInternalCount = 0;
        private StateNode _lastState = StateNode.Running;
        private bool _finishExecuteCommand = false;

        protected override void EnterNode()
        {
            _commandInternalCount = 0;
            _finishExecuteCommand = false;
        }

        protected override StateNode ProcessWorkCommand()
        {
            SetStateAndUpdateWorkCommand();
            VerifyCompleteTaskCommand();

            if (_finishExecuteCommand)
                return StateNode.Success;

            return StateNode.Running;
        }

        private void SetStateAndUpdateWorkCommand()
        {
            _lastState = _decoratorsCommand[_commandInternalCount].ProcessUpdate();
        }

        private void VerifyCompleteTaskCommand()
        {
            if (_lastState == StateNode.Running)
                return;

            if (_lastState == StateNode.Failure)
                throw new Exception("Failure state");

            _commandInternalCount++;
            _lastState = StateNode.Running;

            if (_commandInternalCount >= _decoratorsCommand.Length)
                _finishExecuteCommand = true;
        }
    }
}