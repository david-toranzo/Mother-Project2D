using System;
using UnityEngine;

namespace Runtime.Character2D
{
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

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
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