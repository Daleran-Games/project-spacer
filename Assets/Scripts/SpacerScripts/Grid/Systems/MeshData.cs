using UnityEngine;
using System.Collections.Generic;

namespace ProjectSpacer
{

    public class MeshData
    {

        public List<Vector3> vertices = new List<Vector3>();
        public List<int> triangles = new List<int>();
        public List<Vector2> uv = new List<Vector2>();
        public List<Color32> colors = new List<Color32>();

        public MeshData()
        {

        }

        public void Clear()
        {
            vertices.Clear();
            triangles.Clear();
            uv.Clear();
            colors.Clear();
        }

        public void AddQuad(QuadData quad, Vector2 pos)
        {
            int startingCount = vertices.Count;

            vertices.AddRange(quad.GetVerticies(pos));
            uv.AddRange(quad.GetUVs());
            addQuadTriangles(quad.GetTriangles(), startingCount);
            colors.AddRange(quad.GetColors());

        }


        void addQuadTriangles(List<int> tris, int initialVertCount)
        {
            foreach (int i in tris)
            {
                triangles.Add(initialVertCount + i);
            }
        }

        public static MeshData operator + (MeshData left, MeshData right)
        {
            MeshData _combinedData = new MeshData();
            int startingCount = left.vertices.Count;
            left.vertices.AddRange(right.vertices);
            left.uv.AddRange(right.uv);
            left.addQuadTriangles(right.triangles, startingCount);
            left.colors.AddRange(right.colors);

            return _combinedData;

        }


    }
}