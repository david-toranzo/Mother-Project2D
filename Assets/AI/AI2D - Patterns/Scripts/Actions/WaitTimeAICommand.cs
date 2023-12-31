using UnityEngine;

namespace Runtime.AICommand
{
    public class WaitTimeAICommand : BaseAICommand
    {
        [SerializeField] private float _timeToWait = 2f;

        private float _currentTime = 0;

        protected override void EnterNode()
        {
            _currentTime = 0;
        }

        protected override StateNode ProcessWorkCommand()
        {
            _currentTime += Time.deltaTime;
            if (_currentTime >= _timeToWait)
                return StateNode.Success;
            else
                return StateNode.Running;
        }
    }
}
