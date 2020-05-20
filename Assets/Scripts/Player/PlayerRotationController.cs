using UnityEngine;

namespace TEDinc.UniBlocks
{
    public class PlayerRotationController : MonoBehaviour
    {
        [SerializeField]
        private Transform head;
        [SerializeField]
        private Transform body;

        private const float horizontalRotationCoefficient = 0.3f;
        private const float verticalRotationClampMax = 89f;

        private void Update()
        {
            body.localRotation = Quaternion.Euler(0f, Input.mousePosition.x * horizontalRotationCoefficient, 0f);
            head.localRotation = Quaternion.Euler(
                Mathf.Lerp(
                    verticalRotationClampMax,
                    -verticalRotationClampMax,
                    Mathf.InverseLerp(0f, Screen.height, Input.mousePosition.y)),
                0f, 0f);
        }
    }
}