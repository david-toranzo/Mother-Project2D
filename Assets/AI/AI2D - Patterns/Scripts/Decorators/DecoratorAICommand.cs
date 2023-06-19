using UnityEngine;

namespace Runtime.AICommand
{
    public abstract class DecoratorAICommand : BaseAICommand
    {
        [SerializeField] protected BaseAICommand _decoratorCommand;
    }
}