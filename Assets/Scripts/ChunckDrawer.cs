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
        

        [ContextMenu("Test")]
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
    }
}