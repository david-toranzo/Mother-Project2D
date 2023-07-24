using ScriptableObjects.Event;
using System.Collections;
using UnityEngine;

namespace Mother.Runtime.UI
{
    //TODO : Delete this
    public class MenuUISelector : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private MenuInputController _InputController;
        [SerializeField] private BoolEventScriptableObject _boolEventScriptableObject;

        [Header("Data")]
        [SerializeField] private float _timeToWaitToNextChangeMovement = 0.3f;
        [SerializeField] private Vector2 _displacementSelectObject;

        [Header("UI menu")]
        [SerializeField] private GameObject _menuUI;
        [SerializeField] private RectTransform[] _buttons;
        [SerializeField] private RectTransform _buttonSelect;

        private int _indexMenuItems = 0;
        private float _lastTimeChangeMovement = 0;

        private void Start()
        {
            _InputController.OnChangeSelect += ChangeSelectUI;
            _InputController.OnEnterSelect += EnterPress;
            _InputController.OnChangeStateMenu += ChangeStateMenu;

            SetSelectObjectToPosition();
        }

        private void ChangeSelectUI(Vector2 newMove)
        {
            if (_lastTimeChangeMovement + _timeToWaitToNextChangeMovement > Time.time)
                return;

            _lastTimeChangeMovement = Time.time;

            _indexMenuItems++;
            _indexMenuItems = _indexMenuItems % _buttons.Length;

            SetSelectObjectToPosition();
        }

        private void SetSelectObjectToPosition()
        {
            _buttonSelect.anchoredPosition = _buttons[_indexMenuItems].anchoredPosition + _displacementSelectObject;
        }

        private void EnterPress()
        {
            //DELETE THIS
            switch (_indexMenuItems)
            {
                case 0:
                    ChangeStateMenu(false);
                    break;
                case 1:
                    Application.Quit();
                    break;
            }
        }

        private void ChangeStateMenu(bool newState)
        {
            _boolEventScriptableObject.InvokeEventType(!newState);
            _menuUI.SetActive(newState);
        }
    }
}
