using UnityEngine;

namespace Runtime.Character2D
{
    [CreateAssetMenu(fileName = "CharacterDataSO", menuName = "ScriptableObjects/Data/CharacterDataSO", order = 0)]
    public class CharacterDataSO : ScriptableObject
    {
        [Header("Move")]
        [SerializeField] private float _walkSpeed = 2.5f;

        [Header("Gravity")]
        [SerializeField] private float _multiplyGravityFactor = 4f;
        [SerializeField] private float _gravity = -9.8f;
        [SerializeField] private float _groundedGravity = -0.05f;

        [Header("Move in air")]
        [SerializeField] private float _walkSpeedAir = 2.5f;

        [Header("Jump")]
        [SerializeField] private float _maxJumpHeight = 1;
        [SerializeField] private float _maxJumpTime = 0.5f;

        [Header("Jump forward")]
        [SerializeField] private float _velocityJumpForward = 1;

        public float WalkSpeed { get => _walkSpeed; set => _walkSpeed = value; }

        public float MultiplyGravityFactor { get => _multiplyGravityFactor; set => _multiplyGravityFactor = value; }
        public float Gravity { get => _gravity; }
        public float GroundedGravity { get => _groundedGravity; }

        public float WalkSpeedAir { get => _walkSpeedAir; set => _walkSpeedAir = value; }

        public float MaxJumpHeight { get => _maxJumpHeight; set => _maxJumpHeight = value; }
        public float MaxJumpTime { get => _maxJumpTime; set => _maxJumpTime = value; }

        public float VelocityJumpForward { get => _velocityJumpForward; set => _velocityJumpForward = value; }
    }
}
