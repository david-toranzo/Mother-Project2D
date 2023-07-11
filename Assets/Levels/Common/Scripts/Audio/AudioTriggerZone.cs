using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Level
{
    public class AudioTriggerZone : MonoBehaviour
    {
        private AudioManagerBGM audioManager;

        private void Start()
        {
            audioManager = GameObject.FindObjectOfType<AudioManagerBGM>();
            if (audioManager == null)
            {
                Debug.LogError("No se encontró el AudioManager en la escena.");
                return;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                StartCoroutine(TriggerEnterCoroutine());
            }
        }

        private IEnumerator TriggerEnterCoroutine()
        {
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
                audioManager.HandleTriggerExit(gameObject.layer);
            }
        }
    }
}
