using System;
using UnityEngine;

namespace Common
{
    public abstract class Fighter : MonoBehaviour
    {
        public Action OnAttackFighter { get; set; }

        [Header("References")]
        [SerializeField] protected Transform _positionToAttack;

        [Header("Data")]
        [SerializeField] protected float _distanceAttack = 0.5f;
        [SerializeField] protected float _timeBetweenAttack = 2.5f;
        [SerializeField] protected int _damage = 1;
        [SerializeField] protected string _tagNameToAttack;

        protected IHealth _currentHealth;
        protected float _timeBetweenLastAttack = 0;

        protected virtual void Start()
        {
            _timeBetweenLastAttack = _timeBetweenAttack;

            _currentHealth = GetComponent<IHealth>();
        }

        protected void UpdateTimeBetweenLastAttack()
        {
            _timeBetweenLastAttack += Time.deltaTime;
        }

        public abstract void MakeAttack();
    }
}
