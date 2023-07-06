using System;
using UnityEngine;

namespace Common
{
    public class HealthController : MonoBehaviour, IHealth
    {
        [SerializeField] private int _startLife = 5;
        [SerializeField] private float _timeTakeDamage = 0.3f;

        public Action OnDie { get; set; }
        public Action<int> OnSubstractHealth { get; set; }

        private int _currentLife;
        private float _lastTimeTakeDamage;

        public int CurrentLife { get => _currentLife; set => _currentLife = value; }

        private void Awake()
        {
            _currentLife = _startLife;
        }

        private void Update()
        {
            _lastTimeTakeDamage += Time.deltaTime;
        }

        public bool IsDead() => _currentLife <= 0;

        public virtual void ReceiveAttack(int healthToSubstract)
        {
            if (IsDead())
                return;

            if (_lastTimeTakeDamage < _timeTakeDamage)
                return;

            _currentLife = Mathf.Max(_currentLife - healthToSubstract, 0);
            _lastTimeTakeDamage = 0;

            if (IsDead())
                Die();
            else
                OnSubstractHealth?.Invoke(_currentLife);
        }

        private void Die()
        {
            OnDie?.Invoke();
        }
    }
}