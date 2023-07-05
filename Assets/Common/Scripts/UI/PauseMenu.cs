using UnityEngine;

namespace Runtime.Common
{
    public class PauseGame : MonoBehaviour
    {
        public GameObject pauseMenu;
        private bool onPause;

        void Start()
        {
            pauseMenu.SetActive(false);
            onPause = false;
        }

        void Update()
        {
            if (!onPause && Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
                onPause = true;
            }
            else if (onPause && Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
                onPause = false;
            }
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
