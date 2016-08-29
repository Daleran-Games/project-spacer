using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuadData
{

    Vector3[] vertices = new Vector3[4];
    int[] triangles = new int[6];
    Vector2[] uv = new Vector2[4];

    float zLayer = 0f;
    bool isBuilt = false;

    public MeshLayer layer = MeshLayer.ENTITY;
    public Direction direction = Direction.UP;
    public TileShape shape = TileShape.FLAT;
    public bool flipped = false;
    public Vector2Int atlasCoord;
    
    public QuadData(MeshLayer ml, TileShape sh, Vector2Int ac, Direction dir, bool fl)
    {
        layer = ml;
        shape = sh;
        atlasCoord = ac;
        direction = dir;
        flipped = fl;
        BuildQuad();
    }

    public void BuildQuad()
    {
        zLayer = GV.GetZFromMeshLayer(layer);
        BuildVertices();
        BuildTriangles();
        BuildUV();
        isBuilt = true;
    }

    public void BuildQuad(Direction dir, bool fl)
    {
        direction = dir;
        flipped = fl;

        zLayer = GV.GetZFromMeshLayer(layer);
        BuildVertices();
        BuildTriangles();
        BuildUV();
        isBuilt = true;
    }

    void BuildVertices()
    {

        ApplyShape();
        ApplyRotationAndFlip();
    }

    void ApplyShape ()
    {
        switch (shape)
        {
            case TileShape.FLAT:
                vertices[0] = new Vector3(-GV.halfTileSize, -GV.halfTileSize, zLayer);
                vertices[1] = new Vector3(-GV.halfTileSize, +GV.halfTileSize, zLayer);
                vertices[2] = new Vector3(+GV.halfTileSize, +GV.halfTileSize, zLayer);
                vertices[3] = new Vector3(+GV.halfTileSize, -GV.halfTileSize, zLayer);
                break;
            case TileShape.CORNER:
                vertices[0] = new Vector3(-GV.halfTileSize, -GV.halfTileSize, zLayer);
                vertices[1] = new Vector3(0f, 0f, zLayer);
                vertices[2] = new Vector3(+GV.halfTileSize, +GV.halfTileSize, zLayer);
                vertices[3] = new Vector3(+GV.halfTileSize, -GV.halfTileSize, zLayer);
                break;
            case TileShape.WALL:
                vertices[0] = new Vector3(+GV.halfTileSize, +GV.halfTileSize, zLayer + GV.tileSize);
                vertices[1] = new Vector3(+GV.halfTileSize, +GV.halfTileSize, zLayer);
                vertices[2] = new Vector3(-GV.halfTileSize, +GV.halfTileSize, zLayer);
                vertices[3] = new Vector3(-GV.halfTileSize, +GV.halfTileSize, zLayer + GV.tileSize);
                break;
            case TileShape.WALL_CORNER:
                vertices[0] = new Vector3(+GV.halfTileSize, +GV.halfTileSize, zLayer + GV.tileSize);
                vertices[1] = new Vector3(+GV.halfTileSize, +GV.halfTileSize, zLayer);
                vertices[2] = new Vector3(-GV.halfTileSize, -GV.halfTileSize, zLayer);
                vertices[3] = new Vector3(-GV.halfTileSize, -GV.halfTileSize, zLayer + GV.tileSize);
                break;
            case TileShape.CORNER_UP:
                vertices[0] = new Vector3(-GV.halfTileSize, -GV.halfTileSize, zLayer - GV.tileSize);
                vertices[1] = new Vector3(-GV.halfTileSize, +GV.halfTileSize, zLayer - GV.tileSize);
                vertices[2] = new Vector3(+GV.halfTileSize, +GV.halfTileSize, zLayer - GV.tileSize);
                vertices[3] = new Vector3(+GV.halfTileSize, -GV.halfTileSize, zLayer);
                break;
            case TileShape.CORNER_DOWN:
                vertices[0] = new Vector3(-GV.halfTileSize, -GV.halfTileSize, zLayer + GV.tileSize);
                vertices[1] = new Vector3(-GV.halfTileSize, +GV.halfTileSize, zLayer + GV.tileSize);
                vertices[2] = new Vector3(+GV.halfTileSize, +GV.halfTileSize, zLayer + GV.tileSize);
                vertices[3] = new Vector3(+GV.halfTileSize, -GV.halfTileSize, zLayer);
                break;
            case TileShape.SLOPE_UP:
                vertices[0] = new Vector3(-GV.halfTileSize, -GV.halfTileSize, zLayer);
                vertices[1] = new Vector3(-GV.halfTileSize, +GV.halfTileSize, zLayer - GV.tileSize);
                vertices[2] = new Vector3(+GV.halfTileSize, +GV.halfTileSize, zLayer - GV.tileSize);
                vertices[3] = new Vector3(+GV.halfTileSize, -GV.halfTileSize, zLayer);
                break;
            case TileShape.SLOPE_DOWN:
                vertices[0] = new Vector3(-GV.halfTileSize, -GV.halfTileSize, zLayer);
                vertices[1] = new Vector3(-GV.halfTileSize, +GV.halfTileSize, zLayer + GV.tileSize);
                vertices[2] = new Vector3(+GV.halfTileSize, +GV.halfTileSize, zLayer + GV.tileSize);
                vertices[3] = new Vector3(+GV.halfTileSize, -GV.halfTileSize, zLayer);
                break;
            case TileShape.INVERSE_UP:
                vertices[0] = new Vector3(-GV.halfTileSize, -GV.halfTileSize, zLayer);
                vertices[1] = new Vector3(-GV.halfTileSize, +GV.halfTileSize, zLayer - GV.tileSize);
                vertices[2] = new Vector3(+GV.halfTileSize, +GV.halfTileSize, zLayer);
                vertices[3] = new Vector3(+GV.halfTileSize, -GV.halfTileSize, zLayer);
                break;
            case TileShape.INVERSE_DOWN:
                vertices[0] = new Vector3(-GV.halfTileSize, -GV.halfTileSize, zLayer);
                vertices[1] = new Vector3(-GV.halfTileSize, +GV.halfTileSize, zLayer + GV.tileSize);
                vertices[2] = new Vector3(+GV.halfTileSize, +GV.halfTileSize, zLayer);
                vertices[3] = new Vector3(+GV.halfTileSize, -GV.halfTileSize, zLayer);
                break;
            default:
                Debug.LogError("PS ERROR: " + shape.ToString() + " not a valid shape. Setting to default FLAT.");
                vertices[0] = new Vector3(-GV.halfTileSize, -GV.halfTileSize, zLayer);
                vertices[1] = new Vector3(-GV.halfTileSize, +GV.halfTileSize, zLayer);
                vertices[2] = new Vector3(+GV.halfTileSize, +GV.halfTileSize, zLayer);
                vertices[3] = new Vector3(+GV.halfTileSize, -GV.halfTileSize, zLayer);
                break;
        }
    }

    void ApplyRotationAndFlip()
    {
        Vector3[] oldVerts = (Vector3[])vertices.Clone();

        switch (direction)
        {
            case Direction.UP:
                //Tile Should already be up
                break;
            case Direction.RIGHT:
                vertices[0] = new Vector3(oldVerts[0].x, oldVerts[0].y + GV.tileSize, oldVerts[0].z);
                vertices[1] = new Vector3(oldVerts[1].x + GV.tileSize, oldVerts[1].y, oldVerts[1].z);
                vertices[2] = new Vector3(oldVerts[2].x, oldVerts[2].y - GV.tileSize, oldVerts[2].z);
                vertices[3] = new Vector3(oldVerts[3].x - GV.tileSize, oldVerts[3].y, oldVerts[3].z);
                break;
            case Direction.LEFT:
                vertices[0] = new Vector3(oldVerts[0].x + GV.tileSize, oldVerts[0].y, oldVerts[0].z);
                vertices[1] = new Vector3(oldVerts[1].x, oldVerts[1].y - GV.tileSize, oldVerts[1].z);
                vertices[2] = new Vector3(oldVerts[2].x - GV.tileSize, oldVerts[2].y, oldVerts[2].z);
                vertices[3] = new Vector3(oldVerts[3].x, oldVerts[3].y + GV.tileSize, oldVerts[3].z);
                break;
            case Direction.DOWN:
                vertices[0] = new Vector3(oldVerts[0].x + GV.tileSize, oldVerts[0].y + GV.tileSize, oldVerts[0].z);
                vertices[1] = new Vector3(oldVerts[1].x + GV.tileSize, oldVerts[1].y - GV.tileSize, oldVerts[1].z);
                vertices[2] = new Vector3(oldVerts[2].x - GV.tileSize, oldVerts[2].y - GV.tileSize, oldVerts[2].z);
                vertices[3] = new Vector3(oldVerts[3].x - GV.tileSize, oldVerts[3].y + GV.tileSize, oldVerts[3].z);
                break;
            default:
                Debug.LogError("PS ERROR: " + direction.ToString() + " not a valid direction. Setting to default UP.");
                //Tile should already be up
                break;
        }

    }

    void BuildTriangles()
    {

            triangles[0] = 0;
            triangles[1] = 1;
            triangles[2] = 2;
            triangles[3] = 0;
            triangles[4] = 2;
            triangles[5] = 3;

    }

    void BuildUV ()
    {
        if (flipped == false)
        {
            uv[0] = new Vector2(atlasCoord.x * GV.uvTileSize + GV.uvError, atlasCoord.y * GV.uvTileSize + GV.uvError);
            uv[1] = new Vector2(atlasCoord.x * GV.uvTileSize + GV.uvError, atlasCoord.y * GV.uvTileSize + GV.uvTileSize - GV.uvError);
            uv[2] = new Vector2(atlasCoord.x * GV.uvTileSize + GV.uvTileSize - GV.uvError, atlasCoord.y * GV.uvTileSize + GV.uvTileSize - GV.uvError);
            uv[3] = new Vector2(atlasCoord.x * GV.uvTileSize + GV.uvTileSize - GV.uvError, atlasCoord.y * GV.uvTileSize + GV.uvError);
        } else if (flipped == true)
        {
            uv[0] = new Vector2(atlasCoord.x * GV.uvTileSize + GV.uvTileSize - GV.uvError, atlasCoord.y * GV.uvTileSize + GV.uvError);
            uv[1] = new Vector2(atlasCoord.x * GV.uvTileSize + GV.uvTileSize - GV.uvError, atlasCoord.y * GV.uvTileSize + GV.uvTileSize - GV.uvError);
            uv[2] = new Vector2(atlasCoord.x * GV.uvTileSize + GV.uvError, atlasCoord.y * GV.uvTileSize + GV.uvTileSize - GV.uvError);
            uv[3] = new Vector2(atlasCoord.x * GV.uvTileSize + GV.uvError, atlasCoord.y * GV.uvTileSize + GV.uvError);
        }

    }

    public List<Vector3> GetVerticies (Vector3 pos)
    {
        if (isBuilt == false)
        {
            Debug.LogError("PS ERROR: Quad not yet built. Build quad first");
            return null;
        }
        List<Vector3> vertList = new List<Vector3>();

        vertList.Add(vertices[0] + pos);
        vertList.Add(vertices[1] + pos);
        vertList.Add(vertices[2] + pos);
        vertList.Add(vertices[3] + pos);

        return vertList;
    }

    public List<Vector2> GetUVs()
    {
        if (isBuilt == false)
        {
            Debug.LogError("PS ERROR: Quad not yet built. Build quad first");
            return null;
        }
        List<Vector2> uvList = new List<Vector2>();

        uvList.Add(uv[0]);
        uvList.Add(uv[1]);
        uvList.Add(uv[2]);
        uvList.Add(uv[3]);

        return uvList;
    }

}
