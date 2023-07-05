using Patterns.StateMachine;
using UnityEngine;

namespace Runtime.Character2D
{
    public class StateBlocking : StateBaseMove
    {
        [Header("References")]
        [SerializeField] protected CharacterAnimationDragonBones _characterAnimationDragonBones;

        public override void Enter() 
        {
            Debug.Log("Enter block");
            _characterAnimationDragonBones.Block();
        }

        public override void Exit()
        {
            Debug.Log("Exit block");

            _characterAnimationDragonBones.StopBlock();
        }

        protected override void ProcessWorkActualState() { }
    }
}
