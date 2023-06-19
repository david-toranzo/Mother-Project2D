namespace Common
{
    public interface IHealth : IDead, IAttackReceiver
    {
        int CurrentLife { get; set; }
    }
    public interface IAttackReceiver
    {
        public void ReceiveAttack(int damageAttack);
    }
}