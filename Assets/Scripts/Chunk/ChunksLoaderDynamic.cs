using System.Collections.Generic;
using UnityEngine;

namespace TEDinc.UniBlocks
{
    public class ChunksLoaderDynamic : ChunksLoaderBase
    {
        public const int chunksDrawDistance = 2;

        private Vector3Int prevFloorPosition;


        public override void Setup(WorldChunksDrawer worldDrawer)
        {
            base.Setup(worldDrawer);

            prevFloorPosition = transform.position.DivideToFloor(ChunckData.chunkSize);

            Dictionary<Vector3Int, ChunkLoadType> chunksToLoad = new Dictionary<Vector3Int, ChunkLoadType>();

            for (int x = -chunksDrawDistance; x <= chunksDrawDistance; x++)
                for (int y = -chunksDrawDistance; y <= chunksDrawDistance; y++)
                    for (int z = -chunksDrawDistance; z <= chunksDrawDistance; z++)
                        chunksToLoad.Add(new Vector3Int(x, y, z) + prevFloorPosition, ChunkLoadType.dynamicEnabled);

            worldDrawer.ActualizeDisplayedChunks(chunksToLoad);
        }

        private void Update()
        {
            Vector3Int currFloorPosition = transform.position.DivideToFloor(ChunckData.chunkSize);

            //if (currFloorPosition != prevFloorPosition)
            //    worldDrawer.ActualizeDisplayedChunks(new Dictionary<Vector3Int, ChunkLoadType>());
        }
    }
}