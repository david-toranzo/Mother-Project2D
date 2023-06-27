using UnityEngine;

namespace Runtime.EnemyCommon
{
    public class FighterAnimatorEventCaller : MonoBehaviour
    {
        [SerializeField] private AttackHealthSubtractor _characterFighter;

        public void MakeAttackAnimator()
        {
            _characterFighter.MakeAttack();
        }
    }
}
