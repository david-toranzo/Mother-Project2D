using UnityEngine;
using UnityEngine.InputSystem;

namespace Runtime.InputSystem
{
    [CreateAssetMenu(fileName = "CharacterInputData", 
        menuName = "ScriptableObjects/InputData/CharacterInputData", order = 1)]
    public class CharacterInputData : ScriptableObject
    {
        protected InputActionAsset _actions;

        [SerializeField] private NameInput _mouseLookInput;
        [SerializeField] private NameInput _movementInput;
        [SerializeField] private NameInput _sprintInput;
        [SerializeField] private NameInput _jumpInput;
        [SerializeField] private NameInput _nameInputActionSwitchPerson;
        [SerializeField] private NameInput _nameInputLock;
        [SerializeField] private NameInput _nameInputUnlock;
        [SerializeField] private NameInput _nameInputCharacterLook;
        [SerializeField] private NameInput _scrollButtonInput;

        [SerializeField] protected bool _isUseGamepad = false;

        #region INPUTS

        public bool IsUseGamepad => _isUseGamepad;

        public NameInput SwitchInput => _nameInputActionSwitchPerson;

        public NameInput NameInputLock => _nameInputLock;

        public NameInput NameInputUnlock => _nameInputUnlock;

        public NameInput NameInputCharacterLook => _nameInputCharacterLook;

        public NameInput NameInputSprint => _sprintInput;

        public NameInput NameInputScrollButton => _scrollButtonInput;

        public NameInput NameInputJump => _jumpInput;

        public NameInput NameInputMouseLook => _mouseLookInput;

        public NameInput NameInputMovement => _movementInput;

        #endregion
    }
}
