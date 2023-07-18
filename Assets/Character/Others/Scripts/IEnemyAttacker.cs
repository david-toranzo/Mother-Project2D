using System;
using UnityEngine;

namespace Runtime.Character2D
{
    public interface IEnemyAttacker
    {
        Action<Vector2> OnTouchEnemy { get; set; }

        void MakeAttack();
    }
}