﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace TEDinc.UniBlocks
{
    public static class ChunkMeshGenerator
    {


        public static Mesh GenerateMesh(Vector3Int chunkIndex)
        {
            #region SetupMesh
            Mesh mesh = new Mesh();
            List<Vector3> vericies = new List<Vector3>();
            List<int> triangles = new List<int>();
            List<Vector2> uv = new List<Vector2>();
            List<Vector3> normals = new List<Vector3>();
            #endregion

            Fill();
            AssignMesh();

            return mesh;



            void Fill()
            {
                for (int x = 0; x < ChunckData.chunkSize; x++)
                    for (int z = 0; z < ChunckData.chunkSize; z++)
                        for (int y = 0; y < ChunckData.chunkSize; y++)
                        {
                            Vector3Int position = new Vector3Int(x, y, z);
                            SetBlock(
                                position,
                                GetVisibleSidesOfBlock(position));
                        }


                DrawSides GetVisibleSidesOfBlock(Vector3Int position)
                {
                    DrawSides drawSides = 0;

                    if (WorldChunksData.GetBlock(chunkIndex, position) is SimpleBlockBase)
                    {
                        foreach (Enum value in Enum.GetValues(typeof(DrawSides)))
                            if ((DrawSides)value != DrawSides.None)
                                if (!(WorldChunksData.GetBlock(chunkIndex, position + DrawSidesUtils.GetNormal((DrawSides)value)) is SimpleBlockBase))
                                    drawSides += (int)(DrawSides)value;
                    }

                    return drawSides;
                }

                void SetBlock(Vector3Int position, DrawSides drawSides)
                {
                    foreach (Enum value in Enum.GetValues(typeof(DrawSides)))
                        if ((DrawSides)value != DrawSides.None)
                            if (drawSides.HasFlag(value))
                                SetSide((DrawSides)value);



                    void SetSide(DrawSides drawSide)
                    {
                        SetUVandNormals();
                        SetTriangles();
                        SetVerticies();



                        void SetUVandNormals()
                        {
                            uv.Add(Vector2.zero);
                            uv.Add(Vector2.up);
                            uv.Add(Vector2.right);
                            uv.Add(Vector2.one);


                            for (int i = 0; i < 4; i++)
                                normals.Add(DrawSidesUtils.GetNormal(drawSide));
                        }

                        void SetTriangles()
                        {
                            //first triangle
                            triangles.Add(vericies.Count);
                            triangles.Add(vericies.Count + 1);
                            triangles.Add(vericies.Count + 2);
                            //second triangle
                            triangles.Add(vericies.Count + 2);
                            triangles.Add(vericies.Count + 1);
                            triangles.Add(vericies.Count + 3);
                        }

                        void SetVerticies()
                        {
                            switch (drawSide)
                            {
                                case DrawSides.Right:
                                    vericies.Add(position + new Vector3(1, 0, 0));
                                    vericies.Add(position + new Vector3(1, 1, 0));
                                    vericies.Add(position + new Vector3(1, 0, 1));
                                    vericies.Add(position + new Vector3(1, 1, 1));
                                    break;
                                case DrawSides.Left:
                                    vericies.Add(position + new Vector3(0, 0, 1));
                                    vericies.Add(position + new Vector3(0, 1, 1));
                                    vericies.Add(position + new Vector3(0, 0, 0));
                                    vericies.Add(position + new Vector3(0, 1, 0));
                                    break;
                                case DrawSides.Up:
                                    vericies.Add(position + new Vector3(0, 1, 1));
                                    vericies.Add(position + new Vector3(1, 1, 1));
                                    vericies.Add(position + new Vector3(0, 1, 0));
                                    vericies.Add(position + new Vector3(1, 1, 0));
                                    break;
                                case DrawSides.Down:
                                    vericies.Add(position + new Vector3(0, 0, 0));
                                    vericies.Add(position + new Vector3(1, 0, 0));
                                    vericies.Add(position + new Vector3(0, 0, 1));
                                    vericies.Add(position + new Vector3(1, 0, 1));
                                    break;
                                case DrawSides.Front:
                                    vericies.Add(position + new Vector3(1, 0, 1));
                                    vericies.Add(position + new Vector3(1, 1, 1));
                                    vericies.Add(position + new Vector3(0, 0, 1));
                                    vericies.Add(position + new Vector3(0, 1, 1));
                                    break;
                                case DrawSides.Back:
                                    vericies.Add(position + new Vector3(0, 0, 0));
                                    vericies.Add(position + new Vector3(0, 1, 0));
                                    vericies.Add(position + new Vector3(1, 0, 0));
                                    vericies.Add(position + new Vector3(1, 1, 0));
                                    break;
                            }
                        }
                    }
                }
            }

            void AssignMesh()
            {
                mesh.vertices = vericies.ToArray();
                mesh.triangles = triangles.ToArray();
                mesh.uv = uv.ToArray();
                mesh.normals = normals.ToArray();
            }
        }
    }
}