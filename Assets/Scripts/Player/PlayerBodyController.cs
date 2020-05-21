using UnityEngine;

namespace TEDinc.UniBlocks
{
    public class PlayerBodyController : MonoBehaviour
    {
        [SerializeField]
        private Transform head;
        [SerializeField]
        private Transform body;

        public Transform GetHead()
        {
            return head;
        }

        public Transform GetBody()
        {
            return body;
        }
    }
}