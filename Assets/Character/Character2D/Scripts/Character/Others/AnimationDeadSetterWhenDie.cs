using Common;
using UnityEngine;

namespace Runtime.Character2D
{
    public class AnimationDeadSetterWhenDie : MonoBehaviour
    {
        [SerializeField] private HealthController _healthController;
        [SerializeField] private CharacterAnimationDragonBones _characterAnimationDragonBones;

        private void Start()
        {
            _healthController.OnDie += MakeActionEvent;
        }

        private void MakeActionEvent()
        {
            _characterAnimationDragonBones.Die();
        }

        private void OnDestroy()
        {
            _healthController.OnDie -= MakeActionEvent;
        }
    }
}