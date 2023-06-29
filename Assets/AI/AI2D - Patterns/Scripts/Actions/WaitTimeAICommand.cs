using UnityEngine;

namespace Runtime.AICommand
{
    public class WaitTimeAICommand : BaseAICommand
    {
        [SerializeField] private float _timeToWait = 2f;

        private float _currentTimeToWait = 0;

        protected override void EnterNode()
        {
            _currentTimeToWait = 0;
        }

        protected override StateNode ProcessWorkCommand()
        {
            _currentTimeToWait += Time.deltaTime;
            if (_currentTimeToWait >= _timeToWait)
                return StateNode.Success;
            else
                return StateNode.Running;
        }
    }
}
