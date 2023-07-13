using ScriptableObjects.Event;
using UnityEngine;

namespace Mother.Runtime.Audio
{
    public class PlayAudioEventSubscriber : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] private EmptyEventScriptableObject _eventScriptableObject;

        [Header("References")]
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;


        private void Start()
        {
            _eventScriptableObject.OnEvent += MakeSoundPlay;
        }

        private void MakeSoundPlay()
        {
            _audioSource.PlayOneShot(_audioClip);
        }

        private void OnDestroy()
        {
            _eventScriptableObject.OnEvent -= MakeSoundPlay;
        }
    }
}
