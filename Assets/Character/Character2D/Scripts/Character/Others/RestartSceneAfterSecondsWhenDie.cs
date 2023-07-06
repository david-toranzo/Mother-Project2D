using Common;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runtime.Character2D
{
    public class RestartSceneAfterSecondsWhenDie : MonoBehaviour
    {
        [SerializeField] private HealthController _healthController;
        [SerializeField] private float _time = 3;

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

            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }

        private void OnDestroy()
        {
            _healthController.OnDie -= MakeActionEvent;
        }
    }
}