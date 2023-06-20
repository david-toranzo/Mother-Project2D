using UnityEngine;

namespace David.InputSystem
{
    [CreateAssetMenu(fileName = "Input", menuName = "ScriptableObjects/Data/NameInput", order = 1)]
    public class NameInput : ScriptableObject
    {
        [SerializeField] private string _nameInput;

        public string NameControlInput => _nameInput;
    }
}
