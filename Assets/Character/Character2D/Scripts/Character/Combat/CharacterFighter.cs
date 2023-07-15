using System;
using UnityEngine;

namespace Runtime.Character2D
{
    public class CharacterFighter : MonoBehaviour
    {
        public Action OnAttackFighter { get; set; }

        [SerializeField] protected float _distanceAttack = 0.5f;
        [SerializeField] protected float _timeBetweenAttack = 2.5f;

        [Header("Combo")]
        [SerializeField] protected int _maxComboSize = 3;

        private float _timeBetweenLastAttack = 0;
        private int _countCombo = 0;

        public float TimeBetweenLastAttack 
        {
            get => _timeBetweenLastAttack; 
            set => _timeBetweenLastAttack = value;
        }

        public int CountCombo { get => _countCombo; set => _countCombo = value; }

        public void UpdateComboCount()
        {
            _countCombo += 1;
            _countCombo = _countCombo % _maxComboSize;
        }

        private void Update()
        {
            UpdateTimeBetweenLastAttack();
        }

        public bool CanAttack()
        {
            return _timeBetweenLastAttack >= _timeBetweenAttack;
        }

        private void UpdateTimeBetweenLastAttack()
        {
            _timeBetweenLastAttack += Time.deltaTime;
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
