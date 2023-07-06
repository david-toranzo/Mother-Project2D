﻿using Common;
using Patterns.StateMachine;
using UnityEngine;

namespace Runtime.Character2D
{
    public class StateBlocking : StateBaseMove
    {
        [Header("References")]
        [SerializeField] protected CharacterAnimationDragonBones _characterAnimationDragonBones;
        [SerializeField] protected CharacterUnity2D _character;
        [SerializeField] protected HealthPlayerController _healthPlayerController;

        public override void Enter() 
        {
            _healthPlayerController.SetBlockAttack(true);
            _character.ResetVelocityMove();
            _characterAnimationDragonBones.Block();
        }

        public override void Exit()
        {
            _healthPlayerController.SetBlockAttack(false);
            _characterAnimationDragonBones.StopBlock();
        }

        protected override void ProcessWorkActualState() { }
    }
}
