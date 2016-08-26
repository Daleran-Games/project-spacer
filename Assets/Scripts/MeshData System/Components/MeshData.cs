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

    public void AddQuad(Vector2 pos, Vector2Int tileUV, Orientation orient, Material atlas)
    {
        vertices.Add(new Vector3(pos.x - GlobalVariables.halfTileSize, pos.y - GlobalVariables.halfTileSize, 0f));
        vertices.Add(new Vector3(pos.x - GlobalVariables.halfTileSize, pos.y + GlobalVariables.halfTileSize, 0f));
        vertices.Add(new Vector3(pos.x + GlobalVariables.halfTileSize, pos.y + GlobalVariables.halfTileSize, 0f));
        vertices.Add(new Vector3(pos.x + GlobalVariables.halfTileSize, pos.y - GlobalVariables.halfTileSize, 0f));
        addQuadTriangles();
        addUVs(tileUV, orient, atlas);

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

    void addUVs (Vector2Int tileUV, Orientation orient, Material atlas)
    {
        float uvTileSize = (float)GlobalVariables.pixelResolution / atlas.mainTexture.height;
        

        switch (orient)
        {
            case Orientation.NORTH:
                addUVNorth(tileUV, uvTileSize);
                break;
            case Orientation.SOUTH:
                addUVSouth(tileUV, uvTileSize);
                break;
            case Orientation.EAST:
                addUVEast(tileUV, uvTileSize);
                break;
            case Orientation.WEST:
                addUVWest(tileUV, uvTileSize);
                break;
            case Orientation.FLIPPED_V:
                addUVFlipV(tileUV, uvTileSize);
                break;
            case Orientation.FLIPPED_H:
                addUVFlipH(tileUV, uvTileSize);
                break;
            default:
                Debug.LogError("PS ERROR: " + orient.ToString() + " not a valid orientation for tile rotation");
                addUVNorth(tileUV, uvTileSize);
                break;
        }


    }

    void addUVNorth (Vector2Int tileUV, float uvTileSize)
    {
        uv.Add(new Vector2(tileUV.x * uvTileSize, tileUV.y * uvTileSize));
        uv.Add(new Vector2(tileUV.x * uvTileSize, tileUV.y * uvTileSize + uvTileSize));
        uv.Add(new Vector2(tileUV.x * uvTileSize + uvTileSize, tileUV.y * uvTileSize + uvTileSize));
        uv.Add(new Vector2(tileUV.x * uvTileSize + uvTileSize, tileUV.y * uvTileSize));
    }

    void addUVSouth(Vector2Int tileUV, float uvTileSize)
    {
        uv.Add(new Vector2(tileUV.x * uvTileSize + uvTileSize, tileUV.y * uvTileSize + uvTileSize));
        uv.Add(new Vector2(tileUV.x * uvTileSize + uvTileSize, tileUV.y * uvTileSize));
        uv.Add(new Vector2(tileUV.x * uvTileSize, tileUV.y * uvTileSize));
        uv.Add(new Vector2(tileUV.x * uvTileSize, tileUV.y * uvTileSize + uvTileSize));
    }

    void addUVEast(Vector2Int tileUV, float uvTileSize)
    {
        uv.Add(new Vector2(tileUV.x * uvTileSize + uvTileSize, tileUV.y * uvTileSize));
        uv.Add(new Vector2(tileUV.x * uvTileSize, tileUV.y * uvTileSize));
        uv.Add(new Vector2(tileUV.x * uvTileSize, tileUV.y * uvTileSize + uvTileSize));
        uv.Add(new Vector2(tileUV.x * uvTileSize + uvTileSize, tileUV.y * uvTileSize + uvTileSize));
    }

    void addUVWest(Vector2Int tileUV, float uvTileSize)
    {
        uv.Add(new Vector2(tileUV.x * uvTileSize, tileUV.y * uvTileSize + uvTileSize));
        uv.Add(new Vector2(tileUV.x * uvTileSize + uvTileSize, tileUV.y * uvTileSize + uvTileSize));
        uv.Add(new Vector2(tileUV.x * uvTileSize + uvTileSize, tileUV.y * uvTileSize));
        uv.Add(new Vector2(tileUV.x * uvTileSize, tileUV.y * uvTileSize));
    }

    void addUVFlipH(Vector2Int tileUV, float uvTileSize)
    {
        uv.Add(new Vector2(tileUV.x * uvTileSize + uvTileSize, tileUV.y * uvTileSize));
        uv.Add(new Vector2(tileUV.x * uvTileSize + uvTileSize, tileUV.y * uvTileSize + uvTileSize));
        uv.Add(new Vector2(tileUV.x * uvTileSize, tileUV.y * uvTileSize + uvTileSize));
        uv.Add(new Vector2(tileUV.x * uvTileSize, tileUV.y * uvTileSize));
    }

    void addUVFlipV(Vector2Int tileUV, float uvTileSize)
    {

        uv.Add(new Vector2(tileUV.x * uvTileSize, tileUV.y * uvTileSize + uvTileSize));
        uv.Add(new Vector2(tileUV.x * uvTileSize, tileUV.y * uvTileSize));
        uv.Add(new Vector2(tileUV.x * uvTileSize + uvTileSize, tileUV.y * uvTileSize));
        uv.Add(new Vector2(tileUV.x * uvTileSize + uvTileSize, tileUV.y * uvTileSize + uvTileSize));

    }

}
