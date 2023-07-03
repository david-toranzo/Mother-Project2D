using UnityEngine;

namespace Runtime.Character2D
{
    public class StateDoubleJump : StateJump
    {
        public override void Enter()
        {
            base.Enter();
            _characterJumpController.IsDoubleJump = true;
            //_characterAnimation.SetDoubleJumpAnimation();
        }
    }
}
