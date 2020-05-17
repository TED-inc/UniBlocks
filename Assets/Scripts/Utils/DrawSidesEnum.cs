using System;
using UnityEngine;

namespace TEDinc.UniBlocks
{
    [Flags]
    public enum DrawSides
    {
        None = 0,
        Right = 1,
        Left = 2,
        Up = 4,
        Down = 8,
        Front = 16,
        Back = 32
    }

    public static class DrawSidesUtils
    {
        public static Vector3Int GetNormal(DrawSides drawSide)
        {
            Vector3Int normal;

            switch (drawSide)
            {
                case DrawSides.Right:
                    normal = Vector3Int.right;
                    break;
                case DrawSides.Left:
                    normal = Vector3Int.left;
                    break;
                case DrawSides.Up:
                    normal = Vector3Int.up;
                    break;
                case DrawSides.Down:
                    normal = Vector3Int.down;
                    break;
                case DrawSides.Front:
                    normal = new Vector3Int(0, 0, 1);
                    break;
                case DrawSides.Back:
                    normal = new Vector3Int(0, 0, -1);
                    break;
                default:
                    normal = Vector3Int.zero;
                    break;
            }

            return normal;
        }
    }
}