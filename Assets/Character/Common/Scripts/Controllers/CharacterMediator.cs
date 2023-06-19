using UnityEngine;

namespace Runtime.Character2D
{
    public class CharacterMediator : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;

        public void ChangeStateCharacterActive(bool newState)
        {
            _playerMovement.enabled = newState;
        }
    }
}