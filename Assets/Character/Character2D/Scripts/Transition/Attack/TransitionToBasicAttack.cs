﻿using Runtime.InputSystem;
using Patterns.StateMachine;
using UnityEngine;

namespace Runtime.Character2D
{
    public class TransitionToBasicAttack : Transition
    {
        [Header("References")]
        [SerializeField] protected CharacterFighter _characterFighter;

        [Header("Input")]
        [SerializeField] protected CharacterInput _characterInput;
        [SerializeField] protected NameInput _nameInputAction;
        
        private ControlInputBool _controlInput;

        private void Start()
        {
            _controlInput = GetControlInputBool();
        }

        private ControlInputBool GetControlInputBool()
        {
            return _characterInput.GetControlInputByString(_nameInputAction.NameControlInput) as ControlInputBool;
        }

        public override bool GetProcessTransitionVerification()
        {
            return _controlInput.IsInputPressed && _characterFighter.CanAttack();
        }
    }
}
