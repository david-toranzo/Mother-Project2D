﻿using System;

namespace Runtime.Common
{
    public interface IAttackEvent
    {
        public Action OnAttack { get; set; }
        public Action OnCancelAttack { get; set; }

    }
}
