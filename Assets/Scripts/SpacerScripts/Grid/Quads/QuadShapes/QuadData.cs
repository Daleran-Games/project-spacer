using UnityEngine;
using System.Collections.Generic;
using DalLib.Math;

namespace ProjectSpacer
{

    public class QuadData
    {

        protected List<Vector3> vertices = new List<Vector3>();
        protected List<int> triangles = new List<int>();
        protected List<Vector2> uv = new List<Vector2>();
        protected List<Color32> colors = new List<Color32>();

        protected float zLayer = 0f;
        protected bool isBuilt = false;

        protected MeshLayer layer = MeshLayer.ENTITY;
        protected Direction direction = Direction.Up;
        protected QuadShape shape = QuadShape.FLAT;
        protected bool flipped = false;
        protected bool colorable = false;
        protected Vector2Int atlasCoord = Vector2Int.zero;
        protected Color32 color = GV.defaultTileColor;

        public QuadData()
        {
            BuildQuad(layer, shape, atlasCoord,direction,flipped,colorable,color);
        }

        public QuadData(MeshLayer quadLayer, QuadShape quadShape, Vector2Int quadTileAtlasCoord, Direction quadDirection, bool flipUV, bool isColorable, Color32 quadColor)
        {
            BuildQuad(quadLayer, quadShape, quadTileAtlasCoord, quadDirection, flipUV, isColorable, quadColor);
        }

        protected virtual void BuildQuad(MeshLayer quadLayer, QuadShape quadShape, Vector2Int quadTileAtlasCoord, Direction quadDirection, bool flipUV, bool isColorable, Color32 quadColor)
        {
            Clear();

            layer = quadLayer;
            shape = quadShape;
            atlasCoord = quadTileAtlasCoord;
            direction = quadDirection;
            flipped = flipUV;
            colorable = isColorable;

            if (colorable == true)
                color = quadColor;

            zLayer = GV.GetZFromMeshLayer(layer);
            BuildVertices();
            ApplyDirection(direction);
            BuildTriangles();
            BuildUV(flipped);
            BuildColors();
            isBuilt = true;
        }

        protected virtual void BuildVertices()
        {
            vertices.Add(new Vector3(-GV.halfTileSize, -GV.halfTileSize, zLayer));
            vertices.Add(new Vector3(-GV.halfTileSize, +GV.halfTileSize, zLayer));
            vertices.Add(new Vector3(+GV.halfTileSize, +GV.halfTileSize, zLayer));
            vertices.Add(new Vector3(+GV.halfTileSize, -GV.halfTileSize, zLayer));

        }

        public virtual void Rotate (bool right)
        {

            if (isBuilt == false)
            {
                Debug.LogError("PS ERROR: Quad not yet built. Build quad first");
            }
            else
            {
                SwitchDirection(right);
                if (right == true)
                {

                    vertices[0] = new Vector3(vertices[0].x, vertices[0].y + GV.tileSize, vertices[0].z);
                    vertices[1] = new Vector3(vertices[1].x + GV.tileSize, vertices[1].y, vertices[1].z);
                    vertices[2] = new Vector3(vertices[2].x, vertices[2].y - GV.tileSize, vertices[2].z);
                    vertices[3] = new Vector3(vertices[3].x - GV.tileSize, vertices[3].y, vertices[3].z);
                }
                else
                {
                    vertices[0] = new Vector3(vertices[0].x + GV.tileSize, vertices[0].y, vertices[0].z);
                    vertices[1] = new Vector3(vertices[1].x, vertices[1].y - GV.tileSize, vertices[1].z);
                    vertices[2] = new Vector3(vertices[2].x - GV.tileSize, vertices[2].y, vertices[2].z);
                    vertices[3] = new Vector3(vertices[3].x, vertices[3].y + GV.tileSize, vertices[3].z);
                }
            }

        }

        protected virtual void SwitchDirection(bool right)
        {

            switch (direction)
            {
                case Direction.Up:
                    if (right == true)
                        direction = Direction.Right;
                    else
                        direction = Direction.Left;
                    break;
                case Direction.Right:
                    if (right == true)
                        direction = Direction.Down;
                    else
                        direction = Direction.Up;
                    break;
                case Direction.Left:
                    if (right == true)
                        direction = Direction.Up;
                    else
                        direction = Direction.Down;
                    break;
                case Direction.Down:
                    if (right == true)
                        direction = Direction.Left;
                    else
                        direction = Direction.Right;
                    break;
                default:
                    Debug.LogError("PS ERROR: " + direction.ToString() + " not a valid direction.");
                    break;
            }
        }

        protected virtual void ApplyDirection(Direction dir)
        {

            switch (dir)
            {
                case Direction.Up:

                    break;
                case Direction.Right:
                    vertices[0] = new Vector3(vertices[0].x, vertices[0].y + GV.tileSize, vertices[0].z);
                    vertices[1] = new Vector3(vertices[1].x + GV.tileSize, vertices[1].y, vertices[1].z);
                    vertices[2] = new Vector3(vertices[2].x, vertices[2].y - GV.tileSize, vertices[2].z);
                    vertices[3] = new Vector3(vertices[3].x - GV.tileSize, vertices[3].y, vertices[3].z);
                    break;
                case Direction.Left:
                    vertices[0] = new Vector3(vertices[0].x + GV.tileSize, vertices[0].y, vertices[0].z);
                    vertices[1] = new Vector3(vertices[1].x, vertices[1].y - GV.tileSize, vertices[1].z);
                    vertices[2] = new Vector3(vertices[2].x - GV.tileSize, vertices[2].y, vertices[2].z);
                    vertices[3] = new Vector3(vertices[3].x, vertices[3].y + GV.tileSize, vertices[3].z);
                    break;
                case Direction.Down:
                    vertices[0] = new Vector3(vertices[0].x + GV.tileSize, vertices[0].y + GV.tileSize, vertices[0].z);
                    vertices[1] = new Vector3(vertices[1].x + GV.tileSize, vertices[1].y - GV.tileSize, vertices[1].z);
                    vertices[2] = new Vector3(vertices[2].x - GV.tileSize, vertices[2].y - GV.tileSize, vertices[2].z);
                    vertices[3] = new Vector3(vertices[3].x - GV.tileSize, vertices[3].y + GV.tileSize, vertices[3].z);
                    break;
                default:
                    Debug.LogError("PS ERROR: " + direction.ToString() + " not a valid direction.");
                    break;
            }
        }

        protected virtual void BuildTriangles()
        {
            triangles.Add(0);
            triangles.Add(1);
            triangles.Add(2);
            triangles.Add(0);
            triangles.Add(2);
            triangles.Add(3);
        }

        protected virtual void BuildUV(bool fl)
        {
            if (fl == false)
            {
                uv.Add(new Vector2(atlasCoord.x * GV.uvTileSize + GV.uvError, atlasCoord.y * GV.uvTileSize + GV.uvError));
                uv.Add(new Vector2(atlasCoord.x * GV.uvTileSize + GV.uvError, atlasCoord.y * GV.uvTileSize + GV.uvTileSize - GV.uvError));
                uv.Add(new Vector2(atlasCoord.x * GV.uvTileSize + GV.uvTileSize - GV.uvError, atlasCoord.y * GV.uvTileSize + GV.uvTileSize - GV.uvError));
                uv.Add(new Vector2(atlasCoord.x * GV.uvTileSize + GV.uvTileSize - GV.uvError, atlasCoord.y * GV.uvTileSize + GV.uvError));

            }
            else if (fl == true)
            {
                uv.Add(new Vector2(atlasCoord.x * GV.uvTileSize + GV.uvTileSize - GV.uvError, atlasCoord.y * GV.uvTileSize + GV.uvError));
                uv.Add(new Vector2(atlasCoord.x * GV.uvTileSize + GV.uvTileSize - GV.uvError, atlasCoord.y * GV.uvTileSize + GV.uvTileSize - GV.uvError));
                uv.Add(new Vector2(atlasCoord.x * GV.uvTileSize + GV.uvError, atlasCoord.y * GV.uvTileSize + GV.uvTileSize - GV.uvError));
                uv.Add(new Vector2(atlasCoord.x * GV.uvTileSize + GV.uvError, atlasCoord.y * GV.uvTileSize + GV.uvError));

            }
        }

        public virtual void FlipUV()
        {
            uv.Clear();
            flipped = !flipped;
            BuildUV(flipped);
        }

        protected virtual void BuildColors ()
        {
            for (int i = 0; i < vertices.Count;i++)
            {
                colors.Add(color);
            }
        }

        public virtual List<Vector3> GetVerticies(Vector3 pos)
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

        public virtual List<Vector2> GetUVs()
        {
            if (isBuilt == false)
            {
                Debug.LogError("PS ERROR: Quad not yet built. Build quad first");
                return null;
            }

            return uv;
        }

        public virtual List<int> GetTriangles()
        {
            if (isBuilt == false)
            {
                Debug.LogError("PS ERROR: Quad not yet built. Build quad first");
            }

            return triangles;
        }

        public virtual List<Color32> GetColors()
        {
            if (isBuilt == false)
            {
                Debug.LogError("PS ERROR: Quad not yet built. Build quad first");
            }

            return colors;
        }

        public void Clear()
        {
            vertices.Clear();
            triangles.Clear();
            uv.Clear();
            colors.Clear();
        }

    }
}