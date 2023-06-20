namespace Runtime.Character2D
{
    public class TransitionToWalkFromRun : TransitionToRun
    {
        public override bool GetProcessTransitionVerification()
        {
            return !base.GetProcessTransitionVerification();
        }
    }
}
