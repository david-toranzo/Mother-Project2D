using Patterns.StateMachine;

namespace Runtime.Character2D
{
    public class TransitionTrue : Transition
    {
        public override bool GetProcessTransitionVerification()
        {
            return true;
        }
    }
}
