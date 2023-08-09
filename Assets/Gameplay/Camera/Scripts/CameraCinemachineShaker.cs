using Cinemachine;
using ScriptableObjects.Event;
using System;
using System.Collections;
using UnityEngine;

namespace Runtime.Camera
{
    //TODO refactor, one responsability
    public class CameraCinemachineShaker : MonoBehaviour
    {
        [SerializeField] private float _shakeIntensity = 0.2f;
        [SerializeField] private float _shakeTime = 0.2f;
        [SerializeField] private EmptyEventScriptableObject _eventScriptableObject;

        private CinemachineBasicMultiChannelPerlin _cinemachineBasicMultiChannelPerlin;

        private void Awake()
        {
            var cinemachineVirtual = GetComponent<CinemachineVirtualCamera>();
            _cinemachineBasicMultiChannelPerlin = cinemachineVirtual
                .GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

            _eventScriptableObject.OnEvent += MakeShake;
        }

        private void OnDestroy()
        {
            _eventScriptableObject.OnEvent -= MakeShake;
        }

        private void MakeShake()
        {
            _cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = _shakeIntensity;

            StartCoroutine(ShakeTimeToStopIt());
        }

        private IEnumerator ShakeTimeToStopIt()
        {
            yield return new WaitForSeconds(_shakeTime);

            StopShake();
        }

        private void StopShake()
        {
            _cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0;
        }
    }
}