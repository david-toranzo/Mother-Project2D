using UnityEngine;

namespace BasicEnemy.Enemy
{
    public interface IFighter
    {
        bool CanAttack(GameObject target);
        void Attack(GameObject target);
    }
}
