using UnityEngine;

namespace TEDinc.UniBlocks
{
    [RequireComponent(typeof(PlayerBodyController))]
    public class PlayerMovementController : MonoBehaviour
    {
        private PlayerMoverBase playerMover;

        private void Start()
        {
            playerMover = new PlayerMoverFly(GetComponent<PlayerBodyController>());
        }

        private void FixedUpdate()
        {
            playerMover.ExecuteOnFixedUpdate();
        }
    }
}