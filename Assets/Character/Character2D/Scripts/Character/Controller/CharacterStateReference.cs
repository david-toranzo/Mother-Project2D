using Common;
using Runtime.InputSystem;
using UnityEngine;

namespace Runtime.Character2D
{
    public class CharacterStateReference : MonoBehaviour
    {
        [Header("References character")]
        [SerializeField] private CharacterController2D _character2DController;
        [SerializeField] private CharacterUnity2D _character2D;
        [SerializeField] private HealthPlayerController _healthPlayerController;

        [Header("References character others")]
        [SerializeField] private CharacterAnimation _characterAnimation;
        [SerializeField] private CharacterFighter _characterFighter;
        [SerializeField] private CharacterJumpController _characterJumpController;
        [SerializeField] private Animator _animator;

        [Header("Input")]
        [SerializeField] private CharacterInput _characterInput;

        [Header("Data")]
        [SerializeField] private CharacterDataSO _characterDataSO;

        public CharacterController2D Character2DController { get => _character2DController; }
        public CharacterUnity2D CharacterUnity2D { get => _character2D; }
        public HealthPlayerController HealthPlayerController { get => _healthPlayerController;}
        public CharacterAnimation CharacterAnimation { get => _characterAnimation;  }
        public CharacterFighter CharacterFighter { get => _characterFighter; }
        public CharacterJumpController CharacterJumpController { get => _characterJumpController; }
        public CharacterInput CharacterInput { get => _characterInput; }
        public CharacterDataSO CharacterDataSO { get => _characterDataSO; }
        public Animator Animator { get => _animator; set => _animator = value; }
    }
}