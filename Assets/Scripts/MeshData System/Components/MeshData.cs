using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MeshData  {

    public List<Vector3> vertices = new List<Vector3>();
    public List<int> triangles = new List<int>();
    public List<Vector2> uv = new List<Vector2>();

    public MeshData ()
    {

    }

    public void Clear ()
    {
        vertices.Clear();
        triangles.Clear();
        uv.Clear();
    }

    public void AddQuad (QuadData quad, Vector2 pos)
    {
        int startingCount = vertices.Count;
        
        vertices.AddRange(quad.GetVerticies(pos));
        uv.AddRange(quad.GetUVs());
        addQuadTriangles(quad.triangles, startingCount);


    }


    void addQuadTriangles (List<int> tris, int initialVertCount)
    {
        foreach (int i in tris)
        {
            triangles.Add(initialVertCount + i);
        }
    }


}
