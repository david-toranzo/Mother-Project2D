using System;

namespace Common
{
    public interface IDead
    {
        public Action OnDie { get; set; }
        bool IsDead();
    }
}