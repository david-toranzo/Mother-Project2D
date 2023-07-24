using ScriptableObjects.Event;
using UnityEngine;

namespace Runtime.Character2D
{
    public class CharacterMediator : MonoBehaviour
    {
        [SerializeField] private CharacterUnity2D _playerMovement;
        [SerializeField] private BoolEventScriptableObject _boolEventScriptableObject;

        private void Start()
        {
            _boolEventScriptableObject.OnTypeEvent += ChangeStateCharacterActive;
        }

        public void ChangeStateCharacterActive(bool newState)
        {
            _playerMovement.CanMove = newState;
            _playerMovement.ResetVelocityMove();
        }
    }
}