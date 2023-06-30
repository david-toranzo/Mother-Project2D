using UnityEngine;

namespace Runtime.AICommand
{
    public class DestroyObjectAfterTime : MonoBehaviour
    {
        [SerializeField] private float _timeToDie = 1.6f;

        private void Start()
        {
            Destroy(this.gameObject, _timeToDie);
        }
    }
}
