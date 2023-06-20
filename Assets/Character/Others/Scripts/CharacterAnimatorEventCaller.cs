using UnityEngine;

namespace Runtime.Character2D
{
    public class CharacterAnimatorEventCaller : MonoBehaviour
    {
        [SerializeField] private CharacterFighter _characterFighter;

        public void MakeAttackAnimator()
        {
            _characterFighter.MakeAttack();
        }
    }
}
