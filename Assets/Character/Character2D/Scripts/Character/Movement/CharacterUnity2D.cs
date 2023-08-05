using Runtime.InputSystem;
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

        [Header("Debug")]
        [SerializeField] private Transform _positionAttack;

        private const float _groundedGravity = -0.05f;
        private const float _velocityToMultiply = 4f;

        private Vector2 _inputMove;
        private bool _walkInput;
        private bool _canMove = true;

        private CharacterController2D _characterController;
        private ICharacterAnimation _characterAnimation;
        private ControlInputBool _controlRunInput;
        private ControlInputVector2 _controlInputMovement;
        private CharacterCollision _characterCollision;

        private Vector3 _velocity;

        private Vector3 _velocityPlatform;

        private LookDirection _lookPlayerDirection = LookDirection.Right;

        public Vector3 Velocity { get => _velocity; set => _velocity = value; }
        public Vector3 VelocityPlatform { get => _velocityPlatform; set => _velocityPlatform = value; }
        public bool CanMove { get => _canMove; set => _canMove = value; }

        private void Awake()
        {
            _characterCollision = GetComponent<CharacterCollision>();
            _characterController = GetComponent<CharacterController2D>();
            _characterAnimation = GetComponentInChildren<ICharacterAnimation>();
        }

        private void Start()
        {
            _characterCollision.OnCollisionUp += ResetVelocityMove;

            _controlRunInput = GetControlInputBool(_nameInputActionRun.NameControlInput);
            _controlInputMovement = GetControlInputVector2(_nameInputActionMovement.NameControlInput);
        }

        private void OnDestroy()
        {
            _characterCollision.OnCollisionUp -= ResetVelocityMove;
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
        }

        private void FixedUpdate()
        {
            SetMove();
        }

        private void LateUpdate()
        {
            AnimationSetup();
        }

        private void HandleRotation()
        {
            if (!_walkInput || !_canMove)
                return;

            Vector2 positionToLookAt = _inputMove;

            if (_lookPlayerDirection == LookDirection.Right && positionToLookAt.x < 0)
            {
                //TODO DELETE
                /*ChangePositionAttack();
                _characterAnimation.RotateCharacter();*/
                transform.Rotate(0, -180, 0);
                _lookPlayerDirection = LookDirection.Left;
            }
            else if (_lookPlayerDirection == LookDirection.Left && positionToLookAt.x > 0)
            {
                transform.Rotate(0, 180, 0);
                _lookPlayerDirection = LookDirection.Right;
            }
        }

        //TODO DELETE
        private void ChangePositionAttack()
        {
            _positionAttack.localPosition = new Vector3(_positionAttack.localPosition.x * (-1), _positionAttack.localPosition.y, 0);
        }

        private void SetMove()
        {
            if (!_canMove)
                return;

            _characterController.Move((_velocityToMultiply * _velocity) * Time.deltaTime); //+ _velocityPlatform); 

            _walkInput = _inputMove.x != 0;
        }

        private void AnimationSetup()
        {
            _characterAnimation.UpdateAnimation(_walkInput, _controlRunInput.IsInputPressed);
            _characterAnimation.UpdateGroundAnimation(_characterController.isGrounded, _velocity.y);
        }

        public void ResetVelocityMove()
        {
            _velocity = new Vector3(0, _velocity.y, 0);
            _inputMove = Vector2.zero;
            _walkInput = false;
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
            movementInput.y = 0;
            movementInput.Normalize();
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
