using UnityEngine;

namespace Common
{
    public class FighterAnimatorEventCaller : MonoBehaviour
    {
        [SerializeField] private Fighter _characterFighter;

        public void MakeAttackAnimator()
        {
            _characterFighter.MakeAttack();
        }
    }
}
