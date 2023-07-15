using Patterns.StateMachine;
using UnityEngine;

namespace Runtime.Character2D
{
    public class StateCrouch : StateBaseMove
    {
        [Header("References")]
        [SerializeField] private CharacterAnimation _characterAnimation;
        [SerializeField] protected CharacterUnity2D _character;

        [Header("Cameras")]
        [SerializeField] private GameObject _firstCamera;
        [SerializeField] private GameObject _secondCameraCrouch;

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
