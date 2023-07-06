using Common;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runtime.Character2D
{
    public class ActiveGameObjectAfterTimeWhenDie : MonoBehaviour
    {
        [SerializeField] private HealthController _healthController;
        [SerializeField] private GameObject _objectToActive;
        [SerializeField] private float _time = 0.6f;

        private void Start()
        {
            _healthController.OnDie += MakeActionEvent;
        }

        private void MakeActionEvent()
        {
            StartCoroutine(RestartScene());
        }

        private IEnumerator RestartScene()
        {
            yield return new WaitForSeconds(_time);

            _objectToActive.SetActive(true);
        }

        private void OnDestroy()
        {
            _healthController.OnDie -= MakeActionEvent;
        }
    }
}