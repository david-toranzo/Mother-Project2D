using ScriptableObjects.Data;
using UnityEngine;

namespace Runtime.Character2D
{
    public class CharacterDataSetterWithEvents : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] private FloatDataEventScriptableObject _walkFloatDataEventScriptableObject;
        [SerializeField] private FloatDataEventScriptableObject _jumpFloatDataEventScriptableObject;
        [SerializeField] private FloatDataEventScriptableObject _fallingFloatDataEventScriptableObject;
        [SerializeField] private CharacterDataSO _characterDataSO;

        private void Start()
        {
            _walkFloatDataEventScriptableObject.OnTypeEvent += ChangeWalkCharacterData;
            _jumpFloatDataEventScriptableObject.OnTypeEvent += ChangeJumpCharacterData;
            _fallingFloatDataEventScriptableObject.OnTypeEvent += ChangeFallingCharacterData;
        }

        private void ChangeWalkCharacterData(float value)
        {
            _characterDataSO.WalkSpeed = value;
        }

        private void ChangeJumpCharacterData(float value)
        {
            _characterDataSO.MaxJumpHeight = value;
        }

        private void ChangeFallingCharacterData(float value)
        {
            _characterDataSO.MultiplyGravityFactor = value;
        }
    }
}
