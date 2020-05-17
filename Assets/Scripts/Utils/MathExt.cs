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
    }
}