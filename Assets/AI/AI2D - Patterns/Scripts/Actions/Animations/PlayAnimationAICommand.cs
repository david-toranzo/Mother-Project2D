using UnityEngine;

namespace Runtime.AICommand
{
    public class PlayAnimationAICommand : BaseAICommand
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private string _animationName = "";

        public override void Execute()
        {
            _animator.Play(_animationName);
            NotifyDoneExecution();
        }
    }
}
