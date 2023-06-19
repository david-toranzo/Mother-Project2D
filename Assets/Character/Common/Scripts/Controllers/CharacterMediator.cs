using UnityEngine;

namespace Runtime.Character2D
{
    public class CharacterMediator : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;

        public void ChangeStateCharacterActive(bool newState)
        {
            _playerMovement.enabled = newState;
            _playerMovement.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            _playerMovement.GetComponent<Animator>().Play("Iddle");
        }
    }
}