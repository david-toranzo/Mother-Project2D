using UnityEngine;

namespace Runtime.AICommand
{
    public abstract class Node : MonoBehaviour
    {
        [HideInInspector] public StateNode state = StateNode.Running;
        [HideInInspector] public bool started = false;

        public StateNode ProcessUpdate()
        {
            if (!started)
            {
                EnterNode();
                started = true;
            }

            state = ProcessWorkCommand();

            if (state != StateNode.Running)
            {
                ExitNode();
                started = false;
            }

            return state;
        }

        public void ResetNodeWithExit()
        {
            ExitNode();
            started = false;
        }

        protected abstract void EnterNode();
        protected abstract void ExitNode();
        protected abstract StateNode ProcessWorkCommand();
    }
}
