using System;
using UnityEngine;

namespace Runtime.Character2D
{
    public class CharacterFighter : MonoBehaviour
    {
        public Action OnAttackFighter { get; set; }

        [SerializeField] protected float _distanceAttack = 0.5f;
        [SerializeField] protected float _timeBetweenAttack = 2.5f;
        [SerializeField] protected float _timeBetweenAttackAir = 0.7f;

        [Header("Combo")]
        [SerializeField] protected int _maxComboSize = 3;

        private float _timeBetweenLastAttack = 0;
        private float _timeBetweenLastAttackAir = 0;
        private int _countCombo = 0;

        public float TimeBetweenLastAttack 
        {
            get => _timeBetweenLastAttack; 
            set => _timeBetweenLastAttack = value;
        }

        public float TimeBetweenLastAttackAir 
        { 
            get => _timeBetweenLastAttackAir;
            set => _timeBetweenLastAttackAir = value;
        }

        public int CountCombo { get => _countCombo; set => _countCombo = value; }

        public void UpdateComboCount()
        {
            _countCombo += 1;
            _countCombo = _countCombo % _maxComboSize;
        }

        public void ResetAttacksTimes()
        {
            _timeBetweenLastAttack = 0;
            _timeBetweenLastAttackAir = 0;
        }

        private void Update()
        {
            UpdateTimeBetweenLastAttack();
        }

        public bool CanAttack()
        {
            return _timeBetweenLastAttack >= _timeBetweenAttack;
        }

        public bool CanAttackAir()
        {
            return _timeBetweenLastAttackAir >= _timeBetweenAttackAir;
        }

        private void UpdateTimeBetweenLastAttack()
        {
            _timeBetweenLastAttack += Time.deltaTime;
            _timeBetweenLastAttackAir += Time.deltaTime;
        }

        public void MakeAttack()
        {
            OnAttackFighter?.Invoke();
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _distanceAttack);
        }
    }
}
