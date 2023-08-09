using Runtime.InputSystem;
using ScriptableObjects.Event;
using UnityEngine;

namespace Runtime.Character2D
{
    public class StateBasicAttack : StateWalking
    {
        [Header("Input")]
        [SerializeField] private NameInput _nameInputAction;

        [Header("Data")]
        [SerializeField] private string[] _animationAttackTriggerName = { "attack" };
        [SerializeField] private string _animationAttackAirTriggerName =  "attackAir";
        [SerializeField] private float _velocityMoveAttack = 1f;
        [SerializeField] private EmptyEventScriptableObject _eventScriptableObject;

        private CharacterController2D _character2DController;
        private CharacterAnimation _characterAnimation;
        private CharacterFighter _characterFighter;

        private CharacterInput _characterInput;
        private ControlInputBool _controlInput;

        protected override void Start()
        {
            base.Start();

            _character2DController = _characterStateReference.Character2DController;
            _characterAnimation = _characterStateReference.CharacterAnimation;
            _characterFighter = _characterStateReference.CharacterFighter;
            _characterInput = _characterStateReference.CharacterInput;

            _controlInput = GetControlInputBool();
        }

        private ControlInputBool GetControlInputBool()
        {
            return _characterInput.GetControlInputByString(_nameInputAction.NameControlInput) as ControlInputBool;
        }

        public override void Enter()
        {
            _character.ResetVelocityMove();
            _eventScriptableObject.InvokeEvent();
            //_character.ChangeGravityEnabled(false);
            _controlInput.IsInputPressed = false;

            SetAnimationTrigger();
            UpdateFighterValues();
        }

        public override void Exit()
        {
            _character.ChangeGravityEnabled(true);
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

        protected override float GetSpeed()
        {
            return _velocityMoveAttack;
        }

        private void UpdateFighterValues()
        {
            _characterFighter.ResetAttacksTimes();
            _characterFighter.UpdateComboCount();
        }
    }
}
