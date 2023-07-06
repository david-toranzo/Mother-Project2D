using UnityEngine;

namespace Runtime.AICommand
{
    public class WaitRandomTimeAICommand : BaseAICommand
    {
        [SerializeField] private float _minTimeToWait = 1f;
        [SerializeField] private float _maxTimeToWait = 2f;

        private float _currentTimeToWait = 2f;
        private float _currentTime = 0;

        protected override void EnterNode()
        {
            _currentTimeToWait = Random.Range(_minTimeToWait, _maxTimeToWait);
            _currentTime = 0;
        }

        protected override StateNode ProcessWorkCommand()
        {
            _currentTime += Time.deltaTime;
            if (_currentTime >= _currentTimeToWait)
                return StateNode.Success;
            else
                return StateNode.Running;
        }
    }
}
