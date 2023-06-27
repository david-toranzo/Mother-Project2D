using UnityEngine;

namespace Runtime.Character2D
{
    public class CharacterMediator : MonoBehaviour
    {
        [SerializeField] private CharacterUnity2D _playerMovement;

        public void ChangeStateCharacterActive(bool newState)
        {
            _playerMovement.CanMove = newState;
            _playerMovement.ResetVelocityMove();
        }
    }
}