using System;
using UnityEngine;

namespace Runtime.Character2D
{
    public interface IEnemyAttacker
    {
        Action<Vector2> OnTouchEnemy { get; set; }
        Action<GameObject> OnAttackEnemyWithObject { get; set; }

        void MakeAttack();
    }
}