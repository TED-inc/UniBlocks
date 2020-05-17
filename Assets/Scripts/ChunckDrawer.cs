using UnityEngine;

namespace TEDinc.UniBlocks
{
    [RequireComponent(typeof(MeshRenderer), typeof(MeshFilter), typeof(MeshCollider))]
    public class ChunckDrawer : MonoBehaviour
    {
        private Vector3Int chunkIndex;
        private MeshRenderer renderer;
        private MeshFilter filter;
        private MeshCollider collider;
        

        private void Start()
        {
            //test
            chunkIndex = Vector3Int.zero;

            renderer = GetComponent<MeshRenderer>();
            filter = GetComponent<MeshFilter>();
            collider = GetComponent<MeshCollider>();

            Mesh mesh = ChunkMeshGenerator.GenerateMesh(chunkIndex);
            filter.mesh = mesh;
            collider.sharedMesh = mesh;
        }

        //private void OnDrawGizmos()
        //{
        //    Gizmos.color = Color.gray;
        //
        //    for (int x = -1; x <= CubeChunckData.chunkSize; x++)
        //        for (int z = -1; z <= CubeChunckData.chunkSize; z++)
        //            for (int y = -1; y <= CubeChunckData.chunkSize; y++)
        //                if ((x == -1 || x == CubeChunckData.chunkSize) ||
        //                    (y == -1 || y == CubeChunckData.chunkSize) ||
        //                    (z == -1 || z == CubeChunckData.chunkSize))
        //                    if (WorldChunksData.GetBlock(chunkIndex, new Vector3Int(x, y, z)) is SimpleBlockBase)
        //                        Gizmos.DrawCube(new Vector3Int(x, y, z) + Vector3.one / 2f, Vector3.one * .9f);
        //}

    }
}