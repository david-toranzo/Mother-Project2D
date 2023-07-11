using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Common
{
    using UnityEngine;

    public class AudioTriggerBGM : MonoBehaviour
    {
        public AudioClip clip;
        private AudioSource audioSource;
        private bool isPlaying = false;

        private void Start()
        {
            GameObject audioBGM = GameObject.FindGameObjectWithTag("AudioBGM");
            if (audioBGM != null)
            {
                audioSource = audioBGM.GetComponent<AudioSource>();
            }
            else
            {
                Debug.LogError("No se encontró ningún objeto con el tag 'AudioBGM' que tenga un componente AudioSource adjunto.");
            }

            audioSource.clip = clip;
            audioSource.loop = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (!isPlaying)
                {
                    audioSource.Play();
                    isPlaying = true;
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                StartCoroutine(StopAudioDelayed());
            }
        }

        private System.Collections.IEnumerator StopAudioDelayed()
        {
            yield return new WaitForSeconds(audioSource.clip.length);
            audioSource.Stop();
            isPlaying = false;
        }
    }
}
