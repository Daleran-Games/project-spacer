using UnityEngine;
using System.Collections.Generic;

namespace ProjectSpacer
{

    public class QuadData
    {

        public List<Vector3> vertices = new List<Vector3>();
        public List<int> triangles = new List<int>();
        public List<Vector2> uv = new List<Vector2>();

        float zLayer = 0f;
        bool isBuilt = false;

        public MeshLayer layer = MeshLayer.ENTITY;
        public Direction direction = Direction.UP;
        public QuadShape shape = QuadShape.FLAT;
        public bool flipped = false;
        public Vector2Int atlasCoord;

        public QuadData(MeshLayer ml, QuadShape sh, Vector2Int ac, Direction dir, bool fl)
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

        void BuildVertices()
        {

            ApplyShape();
            ApplyRotationAndFlip();
        }

        void ApplyShape()
        {
            switch (shape)
            {
                case QuadShape.FLAT:
                    vertices.Add(new Vector3(-GV.halfTileSize, -GV.halfTileSize, zLayer));
                    vertices.Add(new Vector3(-GV.halfTileSize, +GV.halfTileSize, zLayer));
                    vertices.Add(new Vector3(+GV.halfTileSize, +GV.halfTileSize, zLayer));
                    vertices.Add(new Vector3(+GV.halfTileSize, -GV.halfTileSize, zLayer));
                    break;
                case QuadShape.CORNER:
                    vertices.Add(new Vector3(-GV.halfTileSize, -GV.halfTileSize, zLayer));
                    vertices.Add(new Vector3(0f, 0f, zLayer));
                    vertices.Add(new Vector3(+GV.halfTileSize, +GV.halfTileSize, zLayer));
                    vertices.Add(new Vector3(+GV.halfTileSize, -GV.halfTileSize, zLayer));
                    break;
                case QuadShape.WALL:
                    vertices.Add(new Vector3(+GV.halfTileSize, +GV.halfTileSize, zLayer + GV.tileSize));
                    vertices.Add(new Vector3(+GV.halfTileSize, +GV.halfTileSize, zLayer));
                    vertices.Add(new Vector3(-GV.halfTileSize, +GV.halfTileSize, zLayer));
                    vertices.Add(new Vector3(-GV.halfTileSize, +GV.halfTileSize, zLayer + GV.tileSize));
                    break;
                case QuadShape.WALL_CORNER:
                    vertices.Add(new Vector3(+GV.halfTileSize, +GV.halfTileSize, zLayer + GV.tileSize));
                    vertices.Add(new Vector3(+GV.halfTileSize, +GV.halfTileSize, zLayer));
                    vertices.Add(new Vector3(-GV.halfTileSize, -GV.halfTileSize, zLayer));
                    vertices.Add(new Vector3(-GV.halfTileSize, -GV.halfTileSize, zLayer + GV.tileSize));
                    break;
                case QuadShape.CORNER_UP:
                    vertices.Add(new Vector3(-GV.halfTileSize, -GV.halfTileSize, zLayer - GV.tileSize));
                    vertices.Add(new Vector3(-GV.halfTileSize, +GV.halfTileSize, zLayer - GV.tileSize));
                    vertices.Add(new Vector3(+GV.halfTileSize, +GV.halfTileSize, zLayer - GV.tileSize));
                    vertices.Add(new Vector3(+GV.halfTileSize, -GV.halfTileSize, zLayer));
                    break;
                case QuadShape.CORNER_DOWN:
                    vertices.Add(new Vector3(-GV.halfTileSize, -GV.halfTileSize, zLayer + GV.tileSize));
                    vertices.Add(new Vector3(-GV.halfTileSize, +GV.halfTileSize, zLayer + GV.tileSize));
                    vertices.Add(new Vector3(+GV.halfTileSize, +GV.halfTileSize, zLayer + GV.tileSize));
                    vertices.Add(new Vector3(+GV.halfTileSize, -GV.halfTileSize, zLayer));
                    break;
                case QuadShape.SLOPE_UP:
                    vertices.Add(new Vector3(-GV.halfTileSize, -GV.halfTileSize, zLayer));
                    vertices.Add(new Vector3(-GV.halfTileSize, +GV.halfTileSize, zLayer - GV.tileSize));
                    vertices.Add(new Vector3(+GV.halfTileSize, +GV.halfTileSize, zLayer - GV.tileSize));
                    vertices.Add(new Vector3(+GV.halfTileSize, -GV.halfTileSize, zLayer));
                    break;
                case QuadShape.SLOPE_DOWN:
                    vertices.Add(new Vector3(-GV.halfTileSize, -GV.halfTileSize, zLayer));
                    vertices.Add(new Vector3(-GV.halfTileSize, +GV.halfTileSize, zLayer + GV.tileSize));
                    vertices.Add(new Vector3(+GV.halfTileSize, +GV.halfTileSize, zLayer + GV.tileSize));
                    vertices.Add(new Vector3(+GV.halfTileSize, -GV.halfTileSize, zLayer));
                    break;
                case QuadShape.INVERSE_UP:
                    vertices.Add(new Vector3(-GV.halfTileSize, -GV.halfTileSize, zLayer));
                    vertices.Add(new Vector3(-GV.halfTileSize, +GV.halfTileSize, zLayer - GV.tileSize));
                    vertices.Add(new Vector3(+GV.halfTileSize, +GV.halfTileSize, zLayer));
                    vertices.Add(new Vector3(+GV.halfTileSize, -GV.halfTileSize, zLayer));
                    vertices.Add(new Vector3(-GV.halfTileSize, -GV.halfTileSize, zLayer));
                    vertices.Add(new Vector3(+GV.halfTileSize, +GV.halfTileSize, zLayer));
                    break;
                case QuadShape.INVERSE_DOWN:
                    vertices.Add(new Vector3(-GV.halfTileSize, -GV.halfTileSize, zLayer));
                    vertices.Add(new Vector3(-GV.halfTileSize, +GV.halfTileSize, zLayer + GV.tileSize));
                    vertices.Add(new Vector3(+GV.halfTileSize, +GV.halfTileSize, zLayer));
                    vertices.Add(new Vector3(+GV.halfTileSize, -GV.halfTileSize, zLayer));
                    vertices.Add(new Vector3(-GV.halfTileSize, -GV.halfTileSize, zLayer));
                    vertices.Add(new Vector3(+GV.halfTileSize, +GV.halfTileSize, zLayer));
                    break;
                default:
                    Debug.LogError("PS ERROR: " + shape.ToString() + " not a valid shape. Setting to default FLAT.");
                    vertices.Add(new Vector3(-GV.halfTileSize, -GV.halfTileSize, zLayer));
                    vertices.Add(new Vector3(-GV.halfTileSize, +GV.halfTileSize, zLayer));
                    vertices.Add(new Vector3(+GV.halfTileSize, +GV.halfTileSize, zLayer));
                    vertices.Add(new Vector3(+GV.halfTileSize, -GV.halfTileSize, zLayer));
                    break;
            }
        }

        void ApplyRotationAndFlip()
        {
            switch (direction)
            {
                case Direction.UP:
                    //Tile Should already be up
                    break;
                case Direction.RIGHT:
                    vertices[0] = new Vector3(vertices[0].x, vertices[0].y + GV.tileSize, vertices[0].z);
                    vertices[1] = new Vector3(vertices[1].x + GV.tileSize, vertices[1].y, vertices[1].z);
                    vertices[2] = new Vector3(vertices[2].x, vertices[2].y - GV.tileSize, vertices[2].z);
                    vertices[3] = new Vector3(vertices[3].x - GV.tileSize, vertices[3].y, vertices[3].z);

                    if (shape == QuadShape.INVERSE_DOWN || shape == QuadShape.INVERSE_UP)
                    {
                        vertices[4] = new Vector3(vertices[4].x, vertices[4].y + GV.tileSize, vertices[4].z);
                        vertices[5] = new Vector3(vertices[5].x, vertices[5].y - GV.tileSize, vertices[5].z);
                    }

                    break;
                case Direction.LEFT:
                    vertices[0] = new Vector3(vertices[0].x + GV.tileSize, vertices[0].y, vertices[0].z);
                    vertices[1] = new Vector3(vertices[1].x, vertices[1].y - GV.tileSize, vertices[1].z);
                    vertices[2] = new Vector3(vertices[2].x - GV.tileSize, vertices[2].y, vertices[2].z);
                    vertices[3] = new Vector3(vertices[3].x, vertices[3].y + GV.tileSize, vertices[3].z);

                    if (shape == QuadShape.INVERSE_DOWN || shape == QuadShape.INVERSE_UP)
                    {
                        vertices[4] = new Vector3(vertices[4].x + GV.tileSize, vertices[4].y, vertices[4].z);
                        vertices[5] = vertices[5] = new Vector3(vertices[5].x - GV.tileSize, vertices[5].y, vertices[5].z);
                    }
                    break;
                case Direction.DOWN:
                    vertices[0] = new Vector3(vertices[0].x + GV.tileSize, vertices[0].y + GV.tileSize, vertices[0].z);
                    vertices[1] = new Vector3(vertices[1].x + GV.tileSize, vertices[1].y - GV.tileSize, vertices[1].z);
                    vertices[2] = new Vector3(vertices[2].x - GV.tileSize, vertices[2].y - GV.tileSize, vertices[2].z);
                    vertices[3] = new Vector3(vertices[3].x - GV.tileSize, vertices[3].y + GV.tileSize, vertices[3].z);

                    if (shape == QuadShape.INVERSE_DOWN || shape == QuadShape.INVERSE_UP)
                    {
                        vertices[4] = new Vector3(vertices[4].x + GV.tileSize, vertices[4].y + GV.tileSize, vertices[4].z);
                        vertices[5] = new Vector3(vertices[5].x - GV.tileSize, vertices[5].y - GV.tileSize, vertices[5].z);
                    }
                    break;
                default:
                    Debug.LogError("PS ERROR: " + direction.ToString() + " not a valid direction. Setting to default UP.");
                    //Tile should already be up
                    break;
            }


        }

        void BuildTriangles()
        {

            if (shape == QuadShape.INVERSE_DOWN || shape == QuadShape.INVERSE_UP)
            {
                triangles.Add(0);
                triangles.Add(1);
                triangles.Add(2);
                triangles.Add(4);
                triangles.Add(5);
                triangles.Add(3);
            }
            else
            {
                triangles.Add(0);
                triangles.Add(1);
                triangles.Add(2);
                triangles.Add(0);
                triangles.Add(2);
                triangles.Add(3);
            }

        }

        void BuildUV()
        {
            if (flipped == false)
            {
                uv.Add(new Vector2(atlasCoord.x * GV.uvTileSize + GV.uvError, atlasCoord.y * GV.uvTileSize + GV.uvError));
                uv.Add(new Vector2(atlasCoord.x * GV.uvTileSize + GV.uvError, atlasCoord.y * GV.uvTileSize + GV.uvTileSize - GV.uvError));
                uv.Add(new Vector2(atlasCoord.x * GV.uvTileSize + GV.uvTileSize - GV.uvError, atlasCoord.y * GV.uvTileSize + GV.uvTileSize - GV.uvError));
                uv.Add(new Vector2(atlasCoord.x * GV.uvTileSize + GV.uvTileSize - GV.uvError, atlasCoord.y * GV.uvTileSize + GV.uvError));

                if (shape == QuadShape.INVERSE_DOWN || shape == QuadShape.INVERSE_UP)
                {
                    uv.Add(new Vector2(atlasCoord.x * GV.uvTileSize + GV.uvError, atlasCoord.y * GV.uvTileSize + GV.uvError));
                    uv.Add(new Vector2(atlasCoord.x * GV.uvTileSize + GV.uvTileSize - GV.uvError, atlasCoord.y * GV.uvTileSize + GV.uvTileSize - GV.uvError));
                }
            }
            else if (flipped == true)
            {
                uv.Add(new Vector2(atlasCoord.x * GV.uvTileSize + GV.uvTileSize - GV.uvError, atlasCoord.y * GV.uvTileSize + GV.uvError));
                uv.Add(new Vector2(atlasCoord.x * GV.uvTileSize + GV.uvTileSize - GV.uvError, atlasCoord.y * GV.uvTileSize + GV.uvTileSize - GV.uvError));
                uv.Add(new Vector2(atlasCoord.x * GV.uvTileSize + GV.uvError, atlasCoord.y * GV.uvTileSize + GV.uvTileSize - GV.uvError));
                uv.Add(new Vector2(atlasCoord.x * GV.uvTileSize + GV.uvError, atlasCoord.y * GV.uvTileSize + GV.uvError));

                if (shape == QuadShape.INVERSE_DOWN || shape == QuadShape.INVERSE_UP)
                {
                    uv.Add(new Vector2(atlasCoord.x * GV.uvTileSize + GV.uvTileSize - GV.uvError, atlasCoord.y * GV.uvTileSize + GV.uvError));
                    uv.Add(new Vector2(atlasCoord.x * GV.uvTileSize + GV.uvError, atlasCoord.y * GV.uvTileSize + GV.uvTileSize - GV.uvError));
                }
            }
        }

        public List<Vector3> GetVerticies(Vector3 pos)
        {
            if (isBuilt == false)
            {
                Debug.LogError("PS ERROR: Quad not yet built. Build quad first");
                return null;
            }
            List<Vector3> vertList = new List<Vector3>();

            foreach (Vector3 v in vertices)
            {
                vertList.Add(v + pos);
            }

            return vertList;
        }

        public List<Vector2> GetUVs()
        {
            if (isBuilt == false)
            {
                Debug.LogError("PS ERROR: Quad not yet built. Build quad first");
                return null;
            }

            return uv;
        }

    }
}