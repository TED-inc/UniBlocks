using System;
using UnityEngine;

namespace TEDinc.UniBlocks
{
    public static class MathExt
    {
        public static int Pow(int f, int p)
        {
            int result = 1;

            for (int i = 0; i < p; i++)
                result *= f;

            return result;
        }

        public static Vector3Int DivideToFloor(this Vector3 v, int round)
        {
            return new Vector3Int(
                (int)Math.Floor(v.x / round),
                (int)Math.Floor(v.y / round),
                (int)Math.Floor(v.z / round));
        }

        public static Vector3Int FloorTo(this Vector3 v, int round)
        {
            return v.DivideToFloor(round) * round;
        }
    }
}