using UnityEngine;
using UnityEditor;

namespace TEDinc.UniBlocks
{
    public static class UTests
    {
        [MenuItem(nameof(UTests) + "/" + nameof(WorldChunksDataTest))]
        public static void WorldChunksDataTest()
        {
            Debug.Log("Test of: " + nameof(WorldChunksData.WorldPostionToChunkIndex));
            Debug.Log(WorldChunksData.WorldPostionToChunkIndex(new Vector3Int(-12, -11, -10)) == -Vector3Int.one);
            Debug.Log(WorldChunksData.WorldPostionToChunkIndex(new Vector3Int(0, 0, 0)) == Vector3Int.zero);
            Debug.Log(WorldChunksData.WorldPostionToChunkIndex(new Vector3Int(15, 12, 10)) == Vector3Int.zero);
            Debug.Log(WorldChunksData.WorldPostionToChunkIndex(new Vector3Int(15, 16, 10)) == Vector3Int.up);
            Debug.Log(WorldChunksData.WorldPostionToChunkIndex(new Vector3Int(15, -16, 10)) == Vector3Int.down);
            Debug.Log(WorldChunksData.WorldPostionToChunkIndex(new Vector3Int(15, -17, 10)) == Vector3Int.down * 2);

            Debug.Log("Test of: " + nameof(WorldChunksData.WorldToLocalPostion));
            Vector3Int chunkIndex = new Vector3Int(-10, 15, 0);
            Vector3Int position = WorldChunksData.WorldToLocalPostion(new Vector3Int(15, -17, 10), ref chunkIndex);
            Debug.Log(chunkIndex == new Vector3Int(-10, 13, 0));
            Debug.Log(position == new Vector3Int(15, 15, 10));

            Debug.Log("Test of: " + nameof(WorldChunksData.SetBlock) +  " & " + nameof(WorldChunksData.GetBlock));
            WorldChunksData.SetBlock(Vector3Int.zero, null);
            WorldChunksData.SetBlock(Vector3Int.zero, new StoneBlock());
            Debug.Log(WorldChunksData.GetBlock(Vector3Int.zero) is StoneBlock);
        }
    }
}