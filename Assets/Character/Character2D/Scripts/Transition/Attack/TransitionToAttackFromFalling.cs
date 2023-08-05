namespace Runtime.Character2D
{
    public class TransitionToAttackFromFalling : TransitionToBasicAttack
    {
        public override bool GetProcessTransitionVerification()
        {
            return base.GetProcessTransitionVerification() && _characterFighter.CanAttackAir();
        }
    }
}
