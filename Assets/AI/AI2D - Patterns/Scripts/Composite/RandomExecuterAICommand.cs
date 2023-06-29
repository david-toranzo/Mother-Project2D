using UnityEngine;

namespace Runtime.AICommand
{
    public class RandomExecuterAICommand : CompositeAICommand
    {
        private int _randomIndex = 0;

        protected override void EnterNode()
        {
            _randomIndex = Random.Range(0, _decoratorsCommand.Length);
        }

        protected override StateNode ProcessWorkCommand()
        {
            return _decoratorsCommand[_randomIndex].ProcessUpdate();
        }
    }
}