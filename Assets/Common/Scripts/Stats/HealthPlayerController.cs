namespace Common
{
    public class HealthPlayerController : HealthController
    {
        private bool _block;

        public bool BlockAttacks => _block;

        public override void ReceiveAttack(int healthToSubstract)
        {
            if (_block)
                return;

            base.ReceiveAttack(healthToSubstract);
        }

        public void SetBlockAttack(bool newState)
        {
            _block = newState;
        }
    }
}