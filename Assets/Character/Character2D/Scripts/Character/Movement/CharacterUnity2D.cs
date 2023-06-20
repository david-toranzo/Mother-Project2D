using David.InputSystem;
using UnityEngine;

namespace Runtime.Character2D
{ 
    public class CharacterUnity2D : MonoBehaviour
    {
        public enum LookDirection
        {
            Right, Left
        }
        [SerializeField] private float _defaultVelocityY = 2.5f;

        [Header("Input")]
        [SerializeField] private CharacterInput _characterInput;
        [SerializeField] private NameInput _nameInputActionRun;
        [SerializeField] private NameInput _nameInputActionMovement;

        private const float _groundedGravity = -0.05f;
        private const float _velocityToMultiply = 4f;

        private Vector2 _inputMove;
        private bool _walkInput;

        private CharacterController2D _characterController;
        private CharacterAnimation _characterAnimation;
        private ControlInputBool _controlRunInput;
        private ControlInputVector2 _controlInputMovement;

        private Vector3 _velocity;

        private Vector3 _velocityPlatform;

        private LookDirection _lookPlayerDirection = LookDirection.Right;

        public Vector3 Velocity { get => _velocity; set => _velocity = value; }
        public Vector3 VelocityPlatform { get => _velocityPlatform; set => _velocityPlatform = value; }

        private void Awake()
        {
            _characterController = GetComponent<CharacterController2D>();
            _characterAnimation = GetComponentInChildren<CharacterAnimation>();
        }

        private void Start()
        {
            _controlRunInput = GetControlInputBool(_nameInputActionRun.NameControlInput);
            _controlInputMovement = GetControlInputVector2(_nameInputActionMovement.NameControlInput);
        }

        private ControlInputBool GetControlInputBool(string nameInput)
        {
            return _characterInput.GetControlInputByString(nameInput) as ControlInputBool;
        }

        private ControlInputVector2 GetControlInputVector2(string nameInput)
        {
            return _characterInput.GetControlInputByString(nameInput) as ControlInputVector2;
        }      

        private void Update()
        {
            HandleRotation();

            SetMove();
        }

        private void LateUpdate()
        {
            AnimationSetup();
        }

        private void HandleRotation()
        {
            if (!_walkInput)
                return;

            Vector2 positionToLookAt = _inputMove;

            if (_lookPlayerDirection == LookDirection.Right && positionToLookAt.x < 0)
            {
                transform.Rotate(0, 180, 0);
                _lookPlayerDirection = LookDirection.Left;
            }
            else if (_lookPlayerDirection == LookDirection.Left && positionToLookAt.x > 0)
            {
                transform.Rotate(0, -180, 0);
                _lookPlayerDirection = LookDirection.Right;
            }
        }

        private void SetMove()
        {
            _characterController.Move((_velocityToMultiply * _velocity) * Time.deltaTime); //+ _velocityPlatform); 

            _walkInput = _inputMove.x != 0 || _inputMove.y != 0;
        }

        private void AnimationSetup()
        {
            _characterAnimation.UpdateAnimation(_walkInput, _controlRunInput.IsInputPressed);
            _characterAnimation.UpdateGroundAnimation(_characterController.isGrounded, _velocity.y);
        }

        public void ResetVelocityMove()
        {
            _velocity = new Vector3(0, _groundedGravity, 0);
            _inputMove = Vector2.zero;
        }

        public void ChangeGravityEnabled(bool enabledGravity)
        {
            _characterController.Gravity = enabledGravity;
        }

        public Vector3 GetMovementVector(float speed)
        {
            SetInputMoveWithMoveInput();

            Vector2 currentMove = _inputMove;

            currentMove = GetSpeedMultiplyByVelocity(currentMove, speed);
            return currentMove;
        }

        private void SetInputMoveWithMoveInput()
        {
            Vector2 movementInput = _controlInputMovement.GetActualValueVector2Input();

            if(Mathf.Abs(movementInput.x) > 0)
                movementInput.x = 1 * Mathf.Sign(movementInput.x);

            if (Mathf.Abs(movementInput.y) > 0)
                movementInput.y = 1 * Mathf.Sign(movementInput.y);

            _inputMove = movementInput;
        }

        private Vector3 GetSpeedMultiplyByVelocity(Vector3 velocity, float speed)
        {
            velocity.x *= speed;
            velocity.y *= _defaultVelocityY;

            return velocity;
        }
    }
}
