using Patterns.Command;
using UnityEngine;

namespace Runtime.AICommand
{
    public abstract class CompositeAICommand : BaseAICommand, ICommandDoneTask
    {
        [SerializeField] protected BaseAICommand[] _decoratorsCommand;

        public override void InitialConfiguration(ICommandDoneTask commandDone)
        {
            for (int i = 0; i < _decoratorsCommand.Length; i++)
            {
                _decoratorsCommand[i].SetCommandManager(this);
            }
        }

        public abstract void DoneExecutionCommand();
    }
}