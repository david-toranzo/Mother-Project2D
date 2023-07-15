using System;

namespace Common
{
    public interface IHealth : IDead, IAttackReceiver
    {
        int CurrentLife { get; set; }
    }
    public interface IAttackReceiver
    {
        public Action<int> OnSubstractHealth { get; set; }

        public void ReceiveAttack(int damageAttack);
    }
}