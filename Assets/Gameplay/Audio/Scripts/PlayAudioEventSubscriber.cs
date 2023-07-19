using ScriptableObjects.Event;
using UnityEngine;

namespace Mother.Runtime.Audio
{
    public class PlayAudioEventSubscriber : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] private EmptyEventScriptableObject _eventScriptableObject;

        [Header("Wwise Events")]
        [SerializeField] private AK.Wwise.Event _attackCharacterSFX;


        private void Start()
        {
            _eventScriptableObject.OnEvent += MakeSoundPlay;
        }

        private void MakeSoundPlay()
        {
            _attackCharacterSFX.Post(gameObject);
        }

        private void OnDestroy()
        {
            _eventScriptableObject.OnEvent -= MakeSoundPlay;
        }
    }
}
