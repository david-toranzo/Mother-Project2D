using ScriptableObjects.Event;
using UnityEngine;

namespace Runtime.Character2D
{
    public class CharacterAttackEventNotifier : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private CharacterFighter _characterFighter;

        [Header("Data")]
        [SerializeField] private EmptyEventScriptableObject _eventScriptableObject;

        private void Start()
        {
            _characterFighter.OnAttackFighter += MakeAttack;
        }

        private void MakeAttack()
        {
            _eventScriptableObject.InvokeEvent();
        }

        private void OnDestroy()
        {
            _characterFighter.OnAttackFighter -= MakeAttack;
        }
    }
}