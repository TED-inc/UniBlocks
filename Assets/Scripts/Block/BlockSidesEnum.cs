using System;
using UnityEngine;

namespace TEDinc.UniBlocks
{
    [Flags]
    public enum BlockSides
    {
        None = 0,
        Right = 1,
        Left = 2,
        Up = 4,
        Down = 8,
        Front = 16,
        Back = 32
    }

    public static class BlockSidesUtils
    {
        public static Vector3Int GetNormal(BlockSides drawSide)
        {
            Vector3Int normal;

            switch (drawSide)
            {
                case BlockSides.Right:
                    normal = Vector3Int.right;
                    break;
                case BlockSides.Left:
                    normal = Vector3Int.left;
                    break;
                case BlockSides.Up:
                    normal = Vector3Int.up;
                    break;
                case BlockSides.Down:
                    normal = Vector3Int.down;
                    break;
                case BlockSides.Front:
                    normal = new Vector3Int(0, 0, 1);
                    break;
                case BlockSides.Back:
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