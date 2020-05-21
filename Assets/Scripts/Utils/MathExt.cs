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

        public static Vector3 IndependendMultiplicate(this Vector3 a, Vector3 b)
        {
            return new Vector3(
                a.x * b.x,
                a.y * b.y,
                a.z * b.z);
        }
    }
}