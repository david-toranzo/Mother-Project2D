using UnityEngine;

namespace Common
{
    public class DieAnimatorTriggerSetter : MonoBehaviour
    {
        [SerializeField] private HealthController _healthController;
        [SerializeField] private Animator _animator;
        [SerializeField] private string _nameBoolAnimatorToSet = "die";

        private void Start()
        {
            _healthController.OnDie += SetAnimatorBool;
        }

        private void SetAnimatorBool()
        {
            _animator.SetTrigger(_nameBoolAnimatorToSet); 
        }
    }
}