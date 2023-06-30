using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime.AICommand
{
    public class ActionNodeManager : MonoBehaviour
    {
        [SerializeField] private Node[] _nodes;

        private List<Node> _commandsNode;

        private WaitForFixedUpdate _waitForEndOfFrame;
        private StateNode _lastState = StateNode.Running;
        private int _commandInternalCount = 0;
        private bool _canRunCommand = true;

        private void Awake()
        {
            _waitForEndOfFrame = new WaitForFixedUpdate();
            AddAndSetNodes(_nodes);
        }

        public void AddAndSetNodes(Node[] commands)
        {
            _commandsNode = new List<Node>();

            foreach (Node nodeCommander in commands)
            {
                _commandsNode.Add(nodeCommander);
            }
        }

        public void StartMakeCommandAction()
        {
            _commandInternalCount = 0;

            StartCoroutine(ProcessWorkStateCommand());
        }

        private IEnumerator ProcessWorkStateCommand()
        {
            while (_canRunCommand)
            {
                SetStateAndUpdateWorkCommand();
                VerifyCompleteTaskCommand();
                yield return _waitForEndOfFrame;
            }
        }

        private void SetStateAndUpdateWorkCommand()
        {
            _lastState = _commandsNode[_commandInternalCount].ProcessUpdate();
        } 

        private void VerifyCompleteTaskCommand()
        {
            if (_lastState == StateNode.Running)
                return;

            if (_lastState == StateNode.Failure)
                throw new Exception("Failure state");

            _commandInternalCount++;
            _lastState = StateNode.Running;

            if (_commandInternalCount >= _commandsNode.Count)
                _canRunCommand = false;
        }
    }
}
