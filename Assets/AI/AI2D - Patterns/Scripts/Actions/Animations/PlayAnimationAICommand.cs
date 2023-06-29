using UnityEngine;

namespace Runtime.AICommand
{
    public class PlayAnimationAICommand : BaseAICommand
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private string _animationName = "";

        protected override StateNode ProcessWorkCommand()
        {
            _animator.Play(_animationName);
            return StateNode.Success;
        }
    }
}
