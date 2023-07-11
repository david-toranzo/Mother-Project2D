using UnityEngine;

namespace Runtime.Camera
{
    //TODO delete this
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private GameObject _firstCamera;
        [SerializeField] private GameObject _secondCamera;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                ChangeStateCameras(false);
            }
            else if (Input.GetKeyDown(KeyCode.M))
            {
                ChangeStateCameras(true);
            }
        }

        private void ChangeStateCameras(bool newStateFirstCamera)
        {
            _firstCamera.SetActive(newStateFirstCamera);
            _secondCamera.SetActive(!newStateFirstCamera);
        }
    }
}