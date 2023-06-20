using UnityEngine;

namespace Runtime.Common
{
    public class CollisionObjectActivatorWithTag : MonoBehaviour
    {
        [SerializeField] private string _tagToDetect;
        [SerializeField] private GameObject _objectToActive;
        [SerializeField] private bool _newState;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == _tagToDetect)
                _objectToActive.SetActive(_newState);
        }
    }
}