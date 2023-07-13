using System;
using System.Collections;
using UnityEngine;

namespace Runtime.Level
{
    public class AudioManagerBGM : MonoBehaviour
    {
        public AudioClip audioClip00;
        public AudioClip audioClip01;
        public AudioClip audioClip02;
        private AudioSource audioSource;
        private string currentLayer = "BGMLoop00";
        private bool isPlaying = false;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();

            if (audioSource == null)
                throw new Exception("No se encontró un objeto con el tag 'AudioBGM' o no tiene un componente AudioSource adjunto.");
        }

        public bool IsPlaying()
        {
            return isPlaying;
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                HandleTriggerEnter(other.gameObject.layer);
            }
        }

        public void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                HandleTriggerExit(other.gameObject.layer);
            }
        }

        public void HandleTriggerEnter(int layer)
        {
            if (layer != LayerMask.NameToLayer(currentLayer) && !isPlaying)
            {
                StartCoroutine(ChangeBGM(layer));
            }
        }

        private IEnumerator ChangeBGM(int layer)
        {
            isPlaying = true;

            if (layer == LayerMask.NameToLayer("BGMLoop00"))
            {
                audioSource.clip = audioClip00;
                audioSource.loop = true;
            }
            else if (layer == LayerMask.NameToLayer("BGMLoop01"))
            {
                audioSource.clip = audioClip01;
                audioSource.loop = false;
            }
            else if (layer == LayerMask.NameToLayer("BGMLoop02"))
            {
                audioSource.clip = audioClip02;
                audioSource.loop = false;
            }

            audioSource.Play();

            yield return new WaitForSeconds(audioSource.clip.length);

            isPlaying = false;
            currentLayer = LayerMask.LayerToName(layer);
        }

        public void HandleTriggerExit(int layer)
        {
            if (layer == LayerMask.NameToLayer(currentLayer) && !isPlaying)
            {
                currentLayer = LayerMask.LayerToName(layer);
            }
        }
    }
}
