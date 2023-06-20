using UnityEngine;

namespace Runtime.Character2D
{
    public class CharacterMediator : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _playerMovement;

        public void ChangeStateCharacterActive(bool newState)
        {
            _playerMovement.enabled = newState;

            //TODO delete this
            _playerMovement.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            _playerMovement.GetComponent<Animator>().SetFloat("Speed", 0);
        }
    }
}