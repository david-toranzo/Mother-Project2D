using UnityEngine;

namespace Runtime.AICommand
{
    public abstract class CompositeAICommand : BaseAICommand
    {
        [SerializeField] protected BaseAICommand[] _decoratorsCommand;
    }
}