using Patterns.ServiceLocator;
using ScenesLoaderSystem;
using UnityEngine;

namespace Runtime.Level
{
    public class ActiveObjectsAfterLoadAllScenes : MonoBehaviour
    {
        [SerializeField] private GameObject _activeGoAfterTime;

        private ISceneLoader _sceneLoader;

        private void Awake()
        {
            var service = ServiceLocator.Instance;

            if (service == null)
            {
                Debug.LogError("There isnt a service locator");
                return;
            }

            _sceneLoader = service.GetService<ISceneLoader>();

            if (_sceneLoader == null)
            {
                Debug.LogError("There arent a scene loader in the service locator");
                return;
            }

            _sceneLoader.OnAllScenesAreLoaded += ActiveObjects;
        }

        private void ActiveObjects()
        {
            _activeGoAfterTime.SetActive(true);    
        }

        private void OnDestroy()
        {
            if (_sceneLoader is null)
                return;

            _sceneLoader.OnAllScenesAreLoaded -= ActiveObjects;
        }
    }
}
