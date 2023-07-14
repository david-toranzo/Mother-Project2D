using ScenesLoaderSystem;
using ScriptableObjects.Event;
using System.Collections;
using UnityEngine;

namespace Runtime.Common
{
    public class LoadSceneAfterTimeEventEmptySubscriber : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] private EmptyEventScriptableObject _eventScriptableObject;

        [Header("References")]
        [SerializeField] private LoadScene _loadScene;
        [SerializeField] private float _secondToWait = 1f;


        private void Start()
        {
            _eventScriptableObject.OnEvent += MakeActionEvent;
        }

        private void MakeActionEvent()
        {
            StartCoroutine(MakeAnimationChangeColor());
        }

        private IEnumerator MakeAnimationChangeColor()
        {
            yield return new WaitForSeconds(_secondToWait);

            _loadScene.Load();
        }

        private void OnDestroy()
        {
            _eventScriptableObject.OnEvent -= MakeActionEvent;
        }
    }
}
