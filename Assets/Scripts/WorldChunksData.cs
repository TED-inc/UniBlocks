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

        public static void SetBlock(Vector3Int worldPosition, IBlock block)
        {
            SetBlock(Vector3Int.zero, worldPosition, block);
        }

        public static void SetBlock(Vector3Int chunkIndex, Vector3Int position, IBlock block)
        {
            Vector3Int realChunkIndex = chunkIndex;
            Vector3Int realPosition = WorldToLocalPostion(position, ref realChunkIndex);
            GetChunk(realChunkIndex).SetBlock(realPosition, block);
        }

        public static IBlock GetBlock(Vector3Int chunkIndex, Vector3Int position)
        {
            Vector3Int realChunkIndex = chunkIndex;
            Vector3Int realPosition = WorldToLocalPostion(position, ref realChunkIndex);
            return GetChunk(realChunkIndex).GetBlock(realPosition);
        }

        public static Vector3Int WorldToLocalPostion(Vector3Int worldPosition, ref Vector3Int chunkIndex)
        {
            Vector3Int outbound = worldPosition - new Vector3Int(
                worldPosition.x < 0 ? ChunckData.chunkSize - 1 : 0,
                worldPosition.y < 0 ? ChunckData.chunkSize - 1 : 0,
                worldPosition.z < 0 ? ChunckData.chunkSize - 1 : 0);
            chunkIndex = chunkIndex + outbound / ChunckData.chunkSize;
            return worldPosition - (outbound / ChunckData.chunkSize) * ChunckData.chunkSize;
        }

        public static Vector3Int WorldPostionToChunkIndex(Vector3Int worldPosition)
        {
            Vector3Int outbound = worldPosition - new Vector3Int(
                worldPosition.x < 0 ? ChunckData.chunkSize - 1 : 0,
                worldPosition.y < 0 ? ChunckData.chunkSize - 1 : 0,
                worldPosition.z < 0 ? ChunckData.chunkSize - 1 : 0);
            return outbound / ChunckData.chunkSize;
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