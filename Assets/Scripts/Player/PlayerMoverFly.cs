using UnityEngine;

namespace TEDinc.UniBlocks
{
    public class PlayerMoverFly : PlayerMoverBase
    {
        private float speed = 0.2f;
        public override void ExecuteOnFixedUpdate()
        {
            Vector3 input;

            SetFlatInput();
            RotatateFlatInput();

            playerBodyController.GetBody().localPosition += input * speed;



            void SetFlatInput()
            {
                input = Vector3.ClampMagnitude(
                    new Vector3(
                        Input.GetAxis("Frontal"),
                        Input.GetAxis("Vertical"),
                        Input.GetAxis("Horizontal")),
                    1f);
            }

            void RotatateFlatInput()
            {
                input = Quaternion.Euler(
                    0f, playerBodyController.GetBody().localRotation.eulerAngles.y, 0f)
                    * input;
            }
        }

        public PlayerMoverFly(PlayerBodyController playerBodyController) : base(playerBodyController) {}
    }
}