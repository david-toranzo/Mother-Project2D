using UnityEngine;

namespace Runtime.Character2D
{
    public class StateDoubleJump : StateJump
    {
        [Header("Double jump")]
        [SerializeField] private CharacterAnimation _characterAnimation;

        public override void Enter()
        {
            base.Enter();
            _characterJumpController.IsDoubleJump = true;
            _characterAnimation.SetDoubleJumpAnimation();
        }
    }
}
