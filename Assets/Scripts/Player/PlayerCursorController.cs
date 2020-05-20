using UnityEngine;

namespace TEDinc.UniBlocks
{
    public class PlayerCursorController : MonoBehaviour
    {
        private void Update()
        {
            Cursor.visible =
                Input.mousePosition.x < 0f &&
                Input.mousePosition.y < 0f &&
                Input.mousePosition.x > Screen.height &&
                Input.mousePosition.y > Screen.width;
        }
    }
}