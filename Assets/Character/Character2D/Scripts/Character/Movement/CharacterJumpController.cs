using David.InputSystem;
using System;
using UnityEngine;

namespace Runtime.Character2D
{
    public class CharacterJumpController : MonoBehaviour
    {
        public Action OnJump { get; set; }

        [Header("References")]
        [SerializeField] private CharacterController2D _characterController;

        [Header("Input")]
        [SerializeField] private CharacterInput _characterInput;
        [SerializeField] private NameInput _nameInputAction;

        [Header("Data")]
        [SerializeField] private float _timeJumpNotGrounded = 0.05f;
        [SerializeField] private float _timeToDoubleJump = 0.15f;

        private bool _isJumping = false;
        private float _lastTimeFalling = 0;
        private bool _isDoubleJump = false;
        private float _lastTimeJumpForward = 0;

        public float LastTimeFalling { get => _lastTimeFalling; set => _lastTimeFalling = value; }
        public bool IsJumping { get => _isJumping; set => _isJumping = value; }
        public bool IsDoubleJump { get => _isDoubleJump; set => _isDoubleJump = value; }
        public float LastTimeJumpForward { get => _lastTimeJumpForward; set => _lastTimeJumpForward = value; }

        private ControlInputBool _controlInput;

        private void Start()
        {
            _controlInput = GetControlInputBool();
        }

        private ControlInputBool GetControlInputBool()
        {
            return _characterInput.GetControlInputByString(_nameInputAction.NameControlInput) as ControlInputBool;
        }

        private void Update()
        {
            _lastTimeJumpForward += Time.deltaTime;
        }

        public bool CanJump()
        {
            return _controlInput.IsInputPressed && (_characterController.isGrounded
                || _lastTimeFalling < _timeJumpNotGrounded);
        }

        public bool CanMakeDoubleJump()
        {
            return _isJumping && !_isDoubleJump && _controlInput.IsInputPressed
                && !_characterController.isGrounded && _lastTimeFalling > _timeToDoubleJump;
        }

        public void NotifyJumpCharacter()
        { 
            OnJump?.Invoke();
        }

        public void ResetAllValues()
        {
            _lastTimeFalling = 0;
            _isJumping = false;
            IsDoubleJump = false;
        }
    }
}
