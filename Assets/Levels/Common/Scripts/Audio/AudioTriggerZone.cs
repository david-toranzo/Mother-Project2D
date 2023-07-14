using System.Collections;
using UnityEngine;

namespace Runtime.Level
{
    public class AudioTriggerZone : MonoBehaviour
    {
        private AudioManagerBGM audioManager;

        private void Start()
        {
            SetAudioManager();
            if (audioManager == null)
            {
                Debug.LogError("No se encontró el AudioManager en la escena.");
                return;
            }
        }

        private void SetAudioManager()
        {
            audioManager = GameObject.FindObjectOfType<AudioManagerBGM>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                if (audioManager is null)
                    SetAudioManager();

                StartCoroutine(TriggerEnterCoroutine());
            }
        }

        private IEnumerator TriggerEnterCoroutine()
        {
            if (audioManager is null)
                SetAudioManager();

            audioManager.HandleTriggerEnter(gameObject.layer);

            while (audioManager.IsPlaying())
            {
                yield return null;
            }

            audioManager.HandleTriggerExit(gameObject.layer);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                if (audioManager is null)
                    SetAudioManager();

                audioManager.HandleTriggerExit(gameObject.layer);
            }
        }
    }
}
