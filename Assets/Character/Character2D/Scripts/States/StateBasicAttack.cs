using Runtime.InputSystem;
using UnityEngine;

namespace Runtime.Character2D
{
    public class StateBasicAttack : StateWalking
    {
        [Header("References")]
        [SerializeField] private CharacterController2D _character2DController;
        [SerializeField] private CharacterAnimation _characterAnimation;
        [SerializeField] private CharacterFighter _characterFighter;

        [Header("Input")]
        [SerializeField] private CharacterInput _characterInput;
        [SerializeField] private NameInput _nameInputAction;

        [Header("Data")]
        [SerializeField] private string[] _animationAttackTriggerName = { "attack" };
        [SerializeField] private string _animationAttackAirTriggerName =  "attackAir";

        private ControlInputBool _controlInput;

        private void Start()
        {
            _controlInput = GetControlInputBool();
        }

        private ControlInputBool GetControlInputBool()
        {
            return _characterInput.GetControlInputByString(_nameInputAction.NameControlInput) as ControlInputBool;
        }

        public override void Enter()
        {
            _character.ResetVelocityMove();
            _character.ChangeGravityEnabled(false);
            _controlInput.IsInputPressed = false;

            SetAnimationTrigger();
            UpdateFighterValues();
        }

        private void SetAnimationTrigger()
        {
            int index = _characterFighter.CountCombo;
            _characterAnimation.AttackAnimation(GetStringAnimator(index));
        }

        private string GetStringAnimator(int index)
        {
            return _character2DController.isGrounded ? _animationAttackTriggerName[index] : _animationAttackAirTriggerName;
        }

        private void UpdateFighterValues()
        {
            _characterFighter.TimeBetweenLastAttack = 0;
            _characterFighter.UpdateComboCount();
        }

        public override void Exit() 
        {
            _character.ChangeGravityEnabled(true);
        }
    }
}
