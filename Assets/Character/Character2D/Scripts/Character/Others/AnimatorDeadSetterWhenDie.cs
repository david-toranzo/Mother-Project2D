using Common;
using UnityEngine;

namespace Runtime.Character2D
{
    public class AnimatorDeadSetterWhenDie : MonoBehaviour
    {
        [SerializeField] private HealthController _healthController;
        [SerializeField] private Animator _animator;
        [SerializeField] private string _animatorDie = "die";

        private void Start()
        {
            _healthController.OnDie += MakeActionEvent;
        }

        private void MakeActionEvent()
        {
            _animator.SetTrigger(_animatorDie);
        }

        private void OnDestroy()
        {
            _healthController.OnDie -= MakeActionEvent;
        }
    }
}