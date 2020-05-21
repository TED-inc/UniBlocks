using UnityEngine;

namespace TEDinc.UniBlocks
{
    public class PlayerCursorController : MonoBehaviour
    {
        [SerializeField]
        private LineRenderer lineRenderer;

        private const float hitDistance = 5f;
        RaycastHit hit;

        private void Start()
        {
            lineRenderer.positionCount = 4;
        }

        private void Update()
        {
            ShowCursorIfNecessary();
            SelectLookAtBlock();

            void ShowCursorIfNecessary()
            {
                Cursor.visible =
                    Input.mousePosition.x < 0f &&
                    Input.mousePosition.y < 0f &&
                    Input.mousePosition.x > Screen.height &&
                    Input.mousePosition.y > Screen.width;
            }

            void SelectLookAtBlock()
            {
                Ray ray = Camera.main.ScreenPointToRay(Camera.main.pixelRect.size / 2f);
 
                if (Physics.Raycast(ray, out hit, hitDistance));
                    if (hit.collider is MeshCollider)
                        DrawSelector();

                void DrawSelector()
                {
                    Mesh hitMesh = (hit.collider as MeshCollider).sharedMesh;

                    if (GetVertexIndex(0) == GetVertexIndex(1) - 1) //if first triangle
                    {
                        SetLinePostion(index: 0, vertexIndex: 0);
                        SetLinePostion(index: 1, vertexIndex: 1);
                        SetLinePostion(index: 2, vertexIndex: 5);
                        SetLinePostion(index: 3, vertexIndex: 2);
                    }
                    else
                    {
                        SetLinePostion(index: 0, vertexIndex: -3);
                        SetLinePostion(index: 1, vertexIndex: 1);
                        SetLinePostion(index: 2, vertexIndex: 2);
                        SetLinePostion(index: 3, vertexIndex: 0);
                    }



                    void SetLinePostion(int index, int vertexIndex)
                    {
                        lineRenderer.SetPosition(index, 
                            hit.transform.position + 
                            hitMesh.vertices[GetVertexIndex(vertexIndex)] + 
                            hit.normal * 0.01f);
                    }

                    int GetVertexIndex(int subIndex)
                    {
                        return hitMesh.triangles[(hit.triangleIndex) * 3 + subIndex];
                    }
                }
            }
        }

        private void OnDrawGizmos()
        {
            

            
        }
    }
}