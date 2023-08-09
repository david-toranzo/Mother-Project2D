using Patterns.StateMachine;
using UnityEngine;

namespace Runtime.Character2D
{
    public class StateCrouch : StateBaseMove
    {
        [Header("References")]
        [SerializeField] protected CharacterStateReference _characterStateReference;

        [Header("Cameras")]
        [SerializeField] private GameObject _firstCamera;
        [SerializeField] private GameObject _secondCameraCrouch;

        protected CharacterUnity2D _character;
        private CharacterAnimation _characterAnimation;

        private void Start()
        {
            _character = _characterStateReference.CharacterUnity2D;
            _characterAnimation = _characterStateReference.CharacterAnimation;
        }

        public override void Enter()
        {
            ChangeStateCameras(false);

            _character.ResetVelocityMove();
            _characterAnimation.CrouchAnimation();
        }

        public override void Exit()
        {
            ChangeStateCameras(true);

            _characterAnimation.StopCrouchAnimation();
        }

        private void ChangeStateCameras(bool newState)
        {
            _firstCamera.SetActive(newState);
            _secondCameraCrouch.SetActive(!newState);
        }

        protected override void ProcessWorkActualState() { }
    }
}
