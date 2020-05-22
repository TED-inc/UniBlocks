using UnityEngine;

namespace TEDinc.UniBlocks
{
    [RequireComponent(typeof(MeshRenderer), typeof(MeshFilter), typeof(MeshCollider))]
    public class ChunckDrawer : MonoBehaviour
    {
        [SerializeField]
        private Vector3Int chunkIndex;
        private MeshRenderer renderer;
        private MeshFilter filter;
        private MeshCollider collider;
        

        public void Setup(Vector3Int chunkIndex)
        {
            this.chunkIndex = chunkIndex;
        }

        public void Draw()
        {
            renderer = GetComponent<MeshRenderer>();
            filter = GetComponent<MeshFilter>();
            collider = GetComponent<MeshCollider>();

            Mesh mesh = ChunkMeshGenerator.GenerateMesh(chunkIndex);

            filter.mesh = mesh;
            collider.sharedMesh = mesh;
        }

        [ContextMenu("TestRefresh")]
        private void RefreshChunks()
        {
            WorldChunksData.ClearChunks();
            Draw();
        }
    }
}