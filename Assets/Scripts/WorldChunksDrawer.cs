using System.Collections.Generic;
using UnityEngine;

namespace TEDinc.UniBlocks
{
    public class WorldChunksDrawer : MonoBehaviour
    {
        [SerializeField]
        private ChunckDrawer chunckDrawerPrefab;

        private Dictionary<Vector3Int, ChunckDrawer> chunks;
        private Queue<ChunckDrawer> drawQueue;

        
        private void Start()
        {
            chunks = new Dictionary<Vector3Int, ChunckDrawer>();
            drawQueue = new Queue<ChunckDrawer>();

            foreach (Transform child in transform)
                Destroy(child.gameObject);

            foreach (Object loader in FindObjectsOfType(typeof(ChunksLoaderBase)))
                (loader as ChunksLoaderBase).Setup(this);
        }

        private void Update()
        {
            if (drawQueue.Count > 0)
                drawQueue.Dequeue().Draw();
        }



        public void SetBlock(Vector3Int worldPosition, IBlock block)
        {
            Vector3Int chunkIndex = WorldChunksData.WorldPostionToChunkIndex(worldPosition);
            Vector3Int chunkIndexRUF = WorldChunksData.WorldPostionToChunkIndex(worldPosition + Vector3Int.one);
            Vector3Int chunkIndexLDB = WorldChunksData.WorldPostionToChunkIndex(worldPosition - Vector3Int.one);
            Dictionary<Vector3Int, ChunkLoadType> chunksToRefresh = 
                new Dictionary<Vector3Int, ChunkLoadType>() {
                    { chunkIndex, ChunkLoadType.dynamicEnabled } };

            if (chunkIndex.x < chunkIndexRUF.x)
                RefreshChunkIfNeighbourBlockNotEmpty(new Vector3Int(1, 0, 0));
            if (chunkIndex.y < chunkIndexRUF.y)
                RefreshChunkIfNeighbourBlockNotEmpty(new Vector3Int(0, 1, 0));
            if (chunkIndex.z < chunkIndexRUF.z)
                RefreshChunkIfNeighbourBlockNotEmpty(new Vector3Int(0, 0, 1));
            if (chunkIndex.x > chunkIndexLDB.x)
                RefreshChunkIfNeighbourBlockNotEmpty(new Vector3Int(-1, 0, 0));
            if (chunkIndex.y > chunkIndexLDB.y)
                RefreshChunkIfNeighbourBlockNotEmpty(new Vector3Int(0, -1, 0));
            if (chunkIndex.z > chunkIndexLDB.z)
                RefreshChunkIfNeighbourBlockNotEmpty(new Vector3Int(0, 0, -1));

            WorldChunksData.SetBlock(worldPosition, block);
            ActualizeDisplayedChunks(chunksToRefresh);

            void RefreshChunkIfNeighbourBlockNotEmpty(Vector3Int offet)
            {
                if (WorldChunksData.GetBlock(worldPosition + offet) != null)
                    chunksToRefresh.Add(chunkIndex + offet, ChunkLoadType.dynamicEnabled);
            }
        }




        public void ActualizeDisplayedChunks(Dictionary<Vector3Int, ChunkLoadType> chunksToUpdate)
        {
            foreach (KeyValuePair<Vector3Int, ChunkLoadType> chunk in chunksToUpdate)
            {
                if (chunks.ContainsKey(chunk.Key))
                {
                    chunks[chunk.Key].Draw();
                    chunks[chunk.Key].gameObject.SetActive(chunk.Value != ChunkLoadType.dynamicDisabled);
                }
                else
                {
                    ChunckDrawer drawer = Instantiate<ChunckDrawer>(
                        chunckDrawerPrefab, 
                        chunk.Key * ChunckData.chunkSize,
                        Quaternion.identity, 
                        transform);
                    drawer.name = "drawer " + chunk.Key;
                    drawer.Setup(chunk.Key);
                    drawer.gameObject.SetActive(chunk.Value != ChunkLoadType.dynamicDisabled);
                    drawQueue.Enqueue(drawer);
                    chunks.Add(chunk.Key, drawer);
                }
            }
        }
    }
}