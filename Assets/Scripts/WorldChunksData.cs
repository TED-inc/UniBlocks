using System.Collections.Generic;
using UnityEngine;

namespace TEDinc.UniBlocks
{
    public static class WorldChunksData
    {
        private static Dictionary<Vector3Int, ChunckData> data;

        public static IBlock GetBlock(Vector3Int worldPosition)
        {
            return GetBlock(Vector3Int.zero, worldPosition);
        }

        public static IBlock GetBlock(Vector3Int chunkIndex, Vector3Int position)
        {
            Vector3Int outbound = position - new Vector3Int(
                position.x < 0 ? ChunckData.chunkSize : 0,
                position.y < 0 ? ChunckData.chunkSize : 0,
                position.z < 0 ? ChunckData.chunkSize : 0);
            Vector3Int realChunkIndex = chunkIndex + outbound / ChunckData.chunkSize;
            Vector3Int realPosition = position - (outbound / ChunckData.chunkSize) * ChunckData.chunkSize;
            return GetChunk(realChunkIndex).GetBlock(realPosition);
        }

        public static ChunckData GetChunk(Vector3Int chunkIndex)
        {
            if (data == null)
                data = new Dictionary<Vector3Int, ChunckData>();

            if (!data.ContainsKey(chunkIndex))
            {
                ChunckData chunk = new ChunckData();
                chunk.TestFill();
                data.Add(chunkIndex, chunk);
            }

            return data[chunkIndex];
        }

        public static void ClearChunks()
        {
            data = null;
        }
    }
}