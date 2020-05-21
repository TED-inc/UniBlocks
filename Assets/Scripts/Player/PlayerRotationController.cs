using UnityEngine;

namespace TEDinc.UniBlocks
{
    [RequireComponent(typeof(PlayerBodyController))]
    public class PlayerRotationController : MonoBehaviour
    {
        private PlayerBodyController playerBodyController;

        private const float horizontalRotationCoefficient = 0.3f;
        private const float verticalRotationClampMax = 89f;

        private void Start()
        {
            playerBodyController = GetComponent<PlayerBodyController>();
        }

        private void Update()
        {
            playerBodyController.GetBody().localRotation = Quaternion.Euler(0f, Input.mousePosition.x * horizontalRotationCoefficient, 0f);
            playerBodyController.GetHead().localRotation = Quaternion.Euler(
                Mathf.Lerp(
                    verticalRotationClampMax,
                    -verticalRotationClampMax,
                    Mathf.InverseLerp(0f, Screen.height, Input.mousePosition.y)),
                0f, 0f);
        }
    }
}