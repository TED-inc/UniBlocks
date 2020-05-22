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

        public void ActualizeDisplayedChunks(Dictionary<Vector3Int, ChunkLoadType> chunksToUpdate)
        {
            foreach (KeyValuePair<Vector3Int, ChunkLoadType> chunk in chunksToUpdate)
            {
                if (chunks.ContainsKey(chunk.Key))
                {

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
                    drawQueue.Enqueue(drawer);
                    chunks.Add(chunk.Key, drawer);
                }
            }
        }
    }
}