using System;

namespace Runtime.Common
{
    public interface IAttackEvent
    {
        public Action OnAttack { get; set; }
    }
}
