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
        vertices.AddRange(quad.GetVerticies(pos));
        uv.AddRange(quad.GetUVs());
        addQuadTriangles();
        //PrintUVs();
    }

    public void PrintUVs()
    {
        foreach(Vector2 u in uv)
        {
            Debug.Log(u);
        }
    }

    void addQuadTriangles ()
    {
            triangles.Add(vertices.Count - 4);
            triangles.Add(vertices.Count - 3);
            triangles.Add(vertices.Count - 2);
            triangles.Add(vertices.Count - 4);
            triangles.Add(vertices.Count - 2);
            triangles.Add(vertices.Count - 1);

    }


}
