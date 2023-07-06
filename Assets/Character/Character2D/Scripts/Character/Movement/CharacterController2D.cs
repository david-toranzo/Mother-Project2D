using UnityEngine;

namespace Runtime.Character2D
{
    public struct RayRange
    {
        public RayRange(float x1, float y1, float x2, float y2, Vector2 dir)
        {
            Start = new Vector2(x1, y1);
            End = new Vector2(x2, y2);
            Dir = dir;
        }

        public readonly Vector2 Start, End, Dir;
    }
    public class CharacterController2D : MonoBehaviour
    {
        [SerializeField] private float _groundCheckRadius = 0.2f;

        [Header("References")]
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private Transform _wallCheck;
        [SerializeField] private LayerMask _whatIsGround;

        //[HideInInspector]
        public bool isGrounded = true;
        [HideInInspector] public bool Gravity = true;

        private Rigidbody2D _rigidbody2D;
        private CharacterCollision _characterCollision;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _characterCollision = GetComponent<CharacterCollision>();
        }

        private void FixedUpdate()
        {
            _characterCollision.CheckCollisionCharacter();
            CheckPlayerIsOnGround();
        }

        private void CheckPlayerIsOnGround()
        {
            isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _whatIsGround);
        }

        public void Move(Vector3 move2D)
        {
            if (Gravity)
                _rigidbody2D.MovePosition(transform.position + move2D);
            else
                _rigidbody2D.velocity = new Vector2(move2D.x, 0);
        }
    }
}