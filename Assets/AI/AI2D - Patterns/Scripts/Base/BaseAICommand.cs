using Patterns.Command;

namespace Runtime.AICommand
{
    public abstract class BaseAICommand : BaseCommand
    {
        public override void InitialConfiguration(ICommandDoneTask commandDone)
        {
        }
    }
}