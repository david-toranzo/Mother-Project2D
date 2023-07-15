using Runtime.Common;
using ScriptableObjects.Data;
using System;
using UnityEngine;

namespace Runtime.Character2D
{
    //TODO refactor all class
    public class CharacterAnimation : MonoBehaviour, IAttackEvent, ICharacterAnimation
    {
        [SerializeField] private BoolDataScriptableObject _boolDataScriptableObject;

        private Animator _animator;

        private readonly int _forwardSpeedParamId = Animator.StringToHash("forwardSpeed");
        private readonly int _airSpeedParamId = Animator.StringToHash("air");
        private readonly int _groundParamId = Animator.StringToHash("onGround");

        public Action OnAttack { get; set; }

        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnDestroy()
        {
            _boolDataScriptableObject.SetTypeData(false);
        }

        public void UpdateAnimation(bool _walk, bool sprint)
        {
            if (_animator is null)
                return;

            if (_boolDataScriptableObject.Data)
            {
                _animator.SetFloat(_forwardSpeedParamId, 0, 0.1f, Time.deltaTime);
                return;
            }

            if (_walk && sprint)
            {
                _animator.SetFloat(_forwardSpeedParamId, 6f, 0.1f, Time.deltaTime);
                return;
            }

            if (_walk ) _animator.SetFloat(_forwardSpeedParamId, 1f, 0.1f, Time.deltaTime);
            else _animator.SetFloat(_forwardSpeedParamId, 0, 0.1f, Time.deltaTime);
        }

        public void UpdateGroundAnimation(bool isGrounded, float airOffset)
        {
            if (_animator is null)
                return;

            _animator.SetBool(_groundParamId, isGrounded);

            if (!isGrounded)
                _animator.SetFloat(_airSpeedParamId, airOffset, 0.1f, Time.deltaTime);
        }

        public void SetDoubleJumpAnimation()
        {
            _animator.SetTrigger("doubleJump");
        }

        public void RotateCharacter()
        {
        }

        public void AttackAnimation(string nameAttack)
        {
            _animator.SetTrigger(nameAttack);
        }

        public void BlockAnimation()
        {
            //_animator.SetBool("attack");
        }

        public void StopBlockAnimation()
        {
            //_animator.SetTrigger("attack");
        }
    }
}