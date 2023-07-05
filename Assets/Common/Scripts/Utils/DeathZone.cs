using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Runtime.Common
{

    public class DeathZone : MonoBehaviour
    {
        public string playerTag = "Player";
        public GameObject deathAnimation;

        private void Start()
        {
            deathAnimation?.SetActive(false);                                                                                                                                                                                                           
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(playerTag))
            {
                deathAnimation?.SetActive(true);
                Invoke("RestartScene", 3f);
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
