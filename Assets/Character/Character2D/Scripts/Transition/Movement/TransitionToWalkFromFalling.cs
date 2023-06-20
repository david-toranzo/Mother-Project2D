namespace Runtime.Character2D
{
    public class TransitionToWalkFromFalling : TransitionToFalling
    {
        public override bool GetProcessTransitionVerification()
        {
            return !base.GetProcessTransitionVerification();
        }
    }
}
