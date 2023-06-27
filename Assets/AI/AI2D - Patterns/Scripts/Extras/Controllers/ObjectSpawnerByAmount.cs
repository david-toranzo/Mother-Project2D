using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime.AICommand
{
    public class ObjectSpawnerByAmount : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform[] _positionSpawn;
        [SerializeField] private GameObject _objectToSpawn;

        [Header("Data")]
        [SerializeField] private float _speedSpawn = 0.4f;
        [SerializeField] private int _countToSpawn = 6;

        private List<Transform> _spawnList = new List<Transform>();
        private int _countAlreadySpawn = 0;

        public void SpawnObjects()
        {
            if (_countAlreadySpawn != 0 && _countAlreadySpawn < _countToSpawn)
                return;

            SetAllTransformToList();

            _countAlreadySpawn = 0;
            StartCoroutine(WaitTimeToDoneExecution());
        }

        private void SetAllTransformToList()
        {
            for (int i = 0; i < _positionSpawn.Length; i++)
            {
                _spawnList.Add(_positionSpawn[i]);
            }
        }

        private IEnumerator WaitTimeToDoneExecution()
        {
            while (_countAlreadySpawn < _countToSpawn)
            {
                Transform _positionToSpawn = GetRandomTransform();
                var rock = Instantiate(_objectToSpawn, _positionToSpawn.position, _objectToSpawn.transform.rotation);

                _countAlreadySpawn++;
                yield return new WaitForSeconds(_speedSpawn);
            }
        }

        private Transform GetRandomTransform()
        {
            if(_spawnList.Count <= 0)
                SetAllTransformToList();

            var newTransform = _spawnList[Random.Range(0, _spawnList.Count)];
            _spawnList.Remove(newTransform);

            return newTransform;
        }
    }
}
