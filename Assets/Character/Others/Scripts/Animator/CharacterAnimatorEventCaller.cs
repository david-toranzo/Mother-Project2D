using ScriptableObjects.Event;
using UnityEngine;

namespace Runtime.Character2D
{
    public class CharacterAnimatorEventCaller : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private CharacterFighter _characterFighter;

        [Header("Data")]
        [SerializeField] private EmptyEventScriptableObject _eventScriptableObject;

        public void MakeAttackAnimator()
        {
            _characterFighter.MakeAttack();
        }

        public void MovementFeetTouchGround()
        {
            _eventScriptableObject.InvokeEvent();
        }
    }
}
