using UnityEngine;
//using System.IO;

namespace TEDinc.UniBlocks
{
    public struct ChunckData
    {
        public const int chunkSize = 16;
        public IBlock[,,] data { get; private set; }

        public void RandomFill()
        {
            data = new IBlock[chunkSize, chunkSize, chunkSize];

            for (int i = 0; i < MathExt.Pow(chunkSize, 3); i++)
            {
                data[Random.Range(0, chunkSize), Random.Range(0, chunkSize), Random.Range(0, chunkSize)] = new StoneBlock();
            }
        }

        public IBlock GetBlock(Vector3Int position)
        {
            return data[position.x, position.y, position.z];
        }


        //public static void WriteString()
        //{
        //    string path = $"{Application.dataPath}/Resources/test.txt";
        //
        //    StreamWriter writer = new StreamWriter(path, false);
        //    SimpleBlockBase blockBase = new StoneBlock();
        //
        //    writer.Close();
        //
        //    TextAsset asset = Resources.Load(path) as TextAsset;
        //}
        //
        //public static string ReadString()
        //{
        //    string path = $"{Application.dataPath}/Resources/test.txt";
        //
        //    StreamReader reader = new StreamReader(path);
        //    string data = reader.ReadToEnd();
        //    reader.Close();
        //    return data;
        //}

    }
}