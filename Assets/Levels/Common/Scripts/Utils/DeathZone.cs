using ScriptableObjects.Event;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Runtime.Level
{
    public class DeathZone : MonoBehaviour
    {
        [SerializeField] private EmptyEventScriptableObject _eventScriptableObject;
        [SerializeField] private string playerTag = "Player";

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(playerTag))
            {
                _eventScriptableObject.InvokeEvent();
            }
        }

        private void RestartScene()
        {
            // Obtener el nombre de la escena actual
            string currentSceneName = SceneManager.GetActiveScene().name;

            // Reiniciar la escena actual
            SceneManager.LoadScene(currentSceneName);
        }
    }
}
