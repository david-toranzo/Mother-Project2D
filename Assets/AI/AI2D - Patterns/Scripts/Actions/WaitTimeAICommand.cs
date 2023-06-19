using System.Collections;
using UnityEngine;

namespace Runtime.AICommand
{
    public class WaitTimeAICommand : BaseAICommand
    {
        [SerializeField] private float _timeToWait = 2f;

        public override void Execute()
        {
            StartCoroutine(WaitTimeToDoneExecution());
        }

        private IEnumerator WaitTimeToDoneExecution()
        {
            yield return new WaitForSeconds(_timeToWait);
            NotifyDoneExecution();
        }
    }
}
