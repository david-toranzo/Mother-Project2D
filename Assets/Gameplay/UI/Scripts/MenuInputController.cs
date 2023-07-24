using Runtime.InputSystem;
using System;
using UnityEngine;

namespace Mother.Runtime.UI
{
    public class MenuInputController : MonoBehaviour
    {
        public Action<Vector2> OnChangeSelect { get; set; }
        public Action OnEnterSelect { get; set; }
        public Action<bool> OnChangeStateMenu { get; set; }

        [Header("Active menu")]
        [SerializeField] private ControlInputBool _controlInputEscape;

        [Header("Inputs menu")]
        [SerializeField] private ControlInput _controlInputEnter;
        [SerializeField] private ControlInputVector2 _controlInputVector2;

        private bool _isMenuActive = false;

        private void Start()
        {
            _controlInputEnter.OnInputEvent += EnterPressNotifier;
            _controlInputEscape.OnInputEvent += ChangeStateMenuPressNotifier;
        }

        private void ChangeStateMenuPressNotifier()
        {
            _isMenuActive = !_isMenuActive;
            NotifyChangeStateMenu();
        }

        private void NotifyChangeStateMenu()
        {
            OnChangeStateMenu?.Invoke(_isMenuActive);
        }

        private void EnterPressNotifier()
        {
            OnEnterSelect?.Invoke();
        }

        private void Update()
        {
            if (!_isMenuActive)
                return;

            VerifyChangeMovementMenu();
        }

        private void VerifyChangeMovementMenu()
        {
            Vector2 movement = _controlInputVector2.GetActualValueVector2Input();
            if (movement != Vector2.zero)
                OnChangeSelect?.Invoke(movement);
        }
    }
}
