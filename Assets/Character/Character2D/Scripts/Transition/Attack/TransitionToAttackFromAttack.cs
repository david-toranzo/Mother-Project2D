using David.InputSystem;
using Patterns.StateMachine;
using UnityEngine;

namespace Runtime.Character2D
{
    public class TransitionToAttackFromAttack : Transition
    {
        [Header("Fighter")]
        [SerializeField] private CharacterFighter _characterFighter;
        [SerializeField] private float _maxTimeToMakeSecondAttack = 1f;
        [SerializeField] private float _minTimeToMakeSecondAttack = 0.05f;

        [Header("Input")]
        [SerializeField] private CharacterInput _characterInput;
        [SerializeField] private NameInput _nameInputAction;

        private ControlInputBool _controlInput;

        private void Start()
        {
            _controlInput = GetControlInputBool();
        }

        private ControlInputBool GetControlInputBool()
        {
            return _characterInput.GetControlInputByString(_nameInputAction.NameControlInput) as ControlInputBool;
        }

        public override bool GetProcessTransitionVerification()
        {
            return _minTimeToMakeSecondAttack <= _characterFighter.TimeBetweenLastAttack
                && _maxTimeToMakeSecondAttack >= _characterFighter.TimeBetweenLastAttack 
                && _controlInput.IsInputPressed;
        }
    }
}
