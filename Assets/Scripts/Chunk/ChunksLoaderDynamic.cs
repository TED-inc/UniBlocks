using System.Collections.Generic;
using UnityEngine;

namespace TEDinc.UniBlocks
{
    public class ChunksLoaderDynamic : ChunksLoaderBase
    {
        public const int chunksDrawDistance = 5;

        private Vector3Int prevFloorPosition;


        public override void Setup(WorldChunksDrawer worldDrawer)
        {
            base.Setup(worldDrawer);
            
            Dictionary<Vector3Int, ChunkLoadType> chunksToLoad = new Dictionary<Vector3Int, ChunkLoadType>();
            QualitySettings.shadowDistance = (chunksDrawDistance + 1) * ChunckData.chunkSize;

            prevFloorPosition = transform.position.DivideToFloor(ChunckData.chunkSize);
            FillChunksToLoad();

            worldDrawer.ActualizeDisplayedChunks(chunksToLoad);

            void FillChunksToLoad()
            {
                Vector3Int releativePos;
            
                for (int targetRadius = 0; targetRadius <= chunksDrawDistance; targetRadius++)
                {
                    for (int y = 0; y <= targetRadius; y = GetNextY(y))
                    {
                        int radius = 0;
                        Vector3Int offset = new Vector3Int(0, 0, -1);
            
                        releativePos = new Vector3Int(0, y, 0);
            
                        for (int i = 0; ; i++)
                        {
                            if (i == MathExt.Pow(radius * 2 + 1, 2))
                            {
                                radius++;
                                if (radius == targetRadius + 1)
                                    break;
                                releativePos = new Vector3Int(radius, y, radius);
                            }
                            else if (radius > 0)
                            {
                                SwithOffset();
                                releativePos += offset;
                            }
            
                            if (releativePos.magnitude <= targetRadius)
                                if (!chunksToLoad.ContainsKey(releativePos + prevFloorPosition))
                                    chunksToLoad.Add(releativePos + prevFloorPosition, ChunkLoadType.dynamicEnabled);
                        }
            
                        void SwithOffset()
                        {
                            if (releativePos.x == radius && releativePos.z == radius)
                                offset = new Vector3Int(0, 0, -1);
                            if (releativePos.x == radius && releativePos.z == -radius)
                                offset = new Vector3Int(-1, 0, 0);
                            if (releativePos.x == -radius && releativePos.z == -radius)
                                offset = new Vector3Int(0, 0, 1);
                            if (releativePos.x == -radius && releativePos.z == radius)
                                offset = new Vector3Int(1, 0, 0);
                        }
                    }
            
                    int GetNextY(int y)
                    {
                        if (y == 0)
                            return 1;
                        else if (y < 0)
                            return -y + 1;
                        else
                            return -y;
                    }
                }
            }
        }

        private void Update()
        {
            Vector3Int currFloorPosition = transform.position.DivideToFloor(ChunckData.chunkSize);

            //if (currFloorPosition != prevFloorPosition)
            //    worldDrawer.ActualizeDisplayedChunks(new Dictionary<Vector3Int, ChunkLoadType>());
        }
    }
}