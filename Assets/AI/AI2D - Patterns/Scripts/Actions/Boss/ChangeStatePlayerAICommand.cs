using Runtime.Character2D;
using UnityEngine;

namespace Runtime.AICommand
{
    public class ChangeStatePlayerAICommand : BaseAICommand
    {
        [SerializeField] private CharacterMediator _objectToChangeState;
        [SerializeField] private bool _newState = false;

        private void Awake()
        {
            if (_objectToChangeState == null)
                SetCharacter();
        }

        private void SetCharacter()
        {
            _objectToChangeState = FindAnyObjectByType<CharacterMediator>();
        }

        protected override StateNode ProcessWorkCommand()
        {
            if (_objectToChangeState == null)
                SetCharacter();

            _objectToChangeState.ChangeStateCharacterActive(_newState);
            return StateNode.Success;
        }
    }
}
